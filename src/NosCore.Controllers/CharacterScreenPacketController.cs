﻿//  __  _  __    __   ___ __  ___ ___  
// |  \| |/__\ /' _/ / _//__\| _ \ __| 
// | | ' | \/ |`._`.| \_| \/ | v / _|  
// |_|\__|\__/ |___/ \__/\__/|_|_\___| 
// 
// Copyright (C) 2018 - NosCore
// 
// NosCore is a free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GraphQL;
using GraphQL.Client;
using JetBrains.Annotations;
using Mapster;
using Newtonsoft.Json.Linq;
using NosCore.Core;
using NosCore.Core.Encryption;
using NosCore.Core.Networking;
using NosCore.Data;
using NosCore.Data.AliveEntities;
using NosCore.Data.GraphQl;
using NosCore.Data.WebApi;
using NosCore.DAL;
using NosCore.GameObject;
using NosCore.GameObject.Networking;
using NosCore.GameObject.Services.CharacterBuilder;
using NosCore.GameObject.Services.ItemBuilder;
using NosCore.GameObject.Services.ItemBuilder.Item;
using NosCore.GameObject.Services.MapInstanceAccess;
using NosCore.Packets.ClientPackets;
using NosCore.Packets.ServerPackets;
using NosCore.Shared;
using NosCore.Shared.Enumerations.Character;
using NosCore.Shared.Enumerations.Items;
using NosCore.Shared.I18N;
using Serilog;
using NosCore.Shared.Enumerations;
using GraphQL.Common.Request;

namespace NosCore.Controllers
{
    public class CharacterScreenPacketController : PacketController
    {
        private readonly ICharacterBuilderService _characterBuilderService;
        private readonly IItemBuilderService _itemBuilderService;
        private readonly MapInstanceAccessService _mapInstanceAccessService;
        private readonly ILogger _logger = Logger.GetLoggerConfiguration().CreateLogger();

        public CharacterScreenPacketController(ICharacterBuilderService characterBuilderService,
            IItemBuilderService itemBuilderService, MapInstanceAccessService mapInstanceAccessService)
        {
            _mapInstanceAccessService = mapInstanceAccessService;
            _characterBuilderService = characterBuilderService;
            _itemBuilderService = itemBuilderService;
        }

        [UsedImplicitly]
        public CharacterScreenPacketController()
        {
        }

        /// <summary>
        ///     Char_NEW_JOB character creation character
        /// </summary>
        /// <param name="martialArtistCreatePacket"></param>
        public void CreateMartialArtist(CharNewJobPacket martialArtistCreatePacket)
        {
            //TODO add a flag on Account
            if (DaoFactory.CharacterDao.FirstOrDefault(s =>
                s.Level >= 80 && s.Account.AccountId == Session.Account.AccountId && s.State == CharacterState.Active) == null)
            {
                //Needs at least a level 80 to create a martial artist
                //TODO log
                return;
            }
            if (DaoFactory.CharacterDao.FirstOrDefault(s =>
                s.Account.AccountId == Session.Account.AccountId &&
                s.Class == (byte)CharacterClassType.MartialArtist && s.State == CharacterState.Active) != null)
            {
                //If already a martial artist, can't create another
                //TODO log
                return;
            }
            //todo add cooldown for recreate 30days

            CreateCharacter(martialArtistCreatePacket);
        }

        /// <summary>
        ///     Char_NEW character creation character
        /// </summary>
        /// <param name="characterCreatePacket"></param>
        public void CreateCharacter(CharNewPacket characterCreatePacket)
        {
            if (Session.HasCurrentMapInstance)
            {
                return;
            }

            // TODO: Hold Account Information in Authorized object
            var accountId = Session.Account.AccountId;
            var slot = characterCreatePacket.Slot;
            var characterName = characterCreatePacket.Name;
            if (DaoFactory.CharacterDao.FirstOrDefault(s =>
                s.AccountId == accountId && s.Slot == slot && s.State == CharacterState.Active) != null)
            {
                return;
            }

            var rg = new Regex(
                @"^[\u0021-\u007E\u00A1-\u00AC\u00AE-\u00FF\u4E00-\u9FA5\u0E01-\u0E3A\u0E3F-\u0E5B\u002E]*$");
            if (rg.Matches(characterName).Count == 1)
            {
                var character =
                    DaoFactory.CharacterDao.FirstOrDefault(s =>
                        s.Name == characterName && s.State == CharacterState.Active);
                if (character == null)
                {
                    var chara = new CharacterDto
                    {
                        Class = characterCreatePacket.IsMartialArtist ? CharacterClassType.MartialArtist : CharacterClassType.Adventurer,
                        Gender = characterCreatePacket.Gender,
                        HairColor = characterCreatePacket.HairColor,
                        HairStyle = characterCreatePacket.HairStyle,
                        Hp = characterCreatePacket.IsMartialArtist ? 12965 : 221,
                        JobLevel = 1,
                        Level = (byte)(characterCreatePacket.IsMartialArtist ? 81 : 1),
                        MapId = 1,
                        MapX = (short)RandomFactory.Instance.RandomNumber(78, 81),
                        MapY = (short)RandomFactory.Instance.RandomNumber(114, 118),
                        Mp = characterCreatePacket.IsMartialArtist ? 2369 : 221,
                        MaxMateCount = 10,
                        SpPoint = 10000,
                        SpAdditionPoint = 0,
                        Name = characterName,
                        Slot = slot,
                        AccountId = accountId,
                        MinilandMessage = "Welcome",
                        State = CharacterState.Active
                    };
                    DaoFactory.CharacterDao.InsertOrUpdate(ref chara);
                    LoadCharacters(null);
                }
                else
                {
                    Session.SendPacket(new InfoPacket
                    {
                        Message = Session.GetMessageFromKey(LanguageKey.ALREADY_TAKEN)
                    });
                }
            }
            else
            {
                Session.SendPacket(new InfoPacket
                {
                    Message = Session.GetMessageFromKey(LanguageKey.INVALID_CHARNAME)
                });
            }
        }

        /// <summary>
        ///     Char_DEL packet
        /// </summary>
        /// <param name="characterDeletePacket"></param>
        public void DeleteCharacter(CharacterDeletePacket characterDeletePacket)
        {
            if (Session.HasCurrentMapInstance)
            {
                return;
            }

            var account = DaoFactory.AccountDao.FirstOrDefault(s => s.AccountId.Equals(Session.Account.AccountId));
            if (account == null)
            {
                return;
            }

            if (account.Password.ToLower() == characterDeletePacket.Password.ToSha512())
            {
                var character = DaoFactory.CharacterDao.FirstOrDefault(s =>
                    s.AccountId == account.AccountId && s.Slot == characterDeletePacket.Slot
                    && s.State == CharacterState.Active);
                if (character == null)
                {
                    return;
                }

                character.State = CharacterState.Inactive;
                DaoFactory.CharacterDao.InsertOrUpdate(ref character);

                LoadCharacters(null);
            }
            else
            {
                Session.SendPacket(new InfoPacket
                {
                    Message = Session.GetMessageFromKey(LanguageKey.BAD_PASSWORD)
                });
            }
        }

        /// <summary>
        ///     Load Characters, this is the Entrypoint for the Client, Wait for 3 Packets.
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public void LoadCharacters(EntryPointPacket packet)
        {
            if (Session.Account == null)
            {
                var servers = WebApiAccess.Instance.Get<List<ChannelInfo>>(WebApiRoute.Channel)?.Where(c => c.Type == ServerType.WorldServer).ToList();
                var name = packet.Name;
                var alreadyConnnected = false;
                var connectedAccountRequest = new GraphQLRequest { Query = "{ connectedAccounts { name } }" }; //TODO filter on name
                foreach (var server in servers ?? new List<ChannelInfo>())
                {
                    var graphQlClient = new GraphQLClient($"{server.WebApi}/api/graphql");
                    var graphQlResponse = graphQlClient.PostAsync(connectedAccountRequest).Result; //TODO move to async
                    var connected = graphQlResponse.Data.connectedAccounts as JArray;
                    if (connected.Select(acc => acc.GetPropertyValue("name")).Any(acc => acc.GetValue().ToString() == name))
                    {
                        alreadyConnnected = true;
                        break;
                    }
                }

                if (alreadyConnnected)
                {
                    Session.Disconnect();
                    return;
                }

                var account = DaoFactory.AccountDao.FirstOrDefault(s => s.Name == name);

                if (account != null)
                {
                    if (account.Password.Equals(packet.Password.ToSha512(),
                        StringComparison.OrdinalIgnoreCase))
                    {
                        var accountobject = new AccountDto
                        {
                            AccountId = account.AccountId,
                            Name = account.Name,
                            Password = account.Password.ToLower(),
                            Authority = account.Authority,
                            Language = account.Language
                        };
                        SessionFactory.Instance.Sessions.FirstOrDefault(s => s.Value.SessionId == Session.SessionId)
                            .Value.RegionType = account.Language;
                        Session.InitializeAccount(accountobject);
                        //Send Account Connected
                    }
                    else
                    {
                        _logger.Error(LogLanguage.Instance.GetMessageFromKey(LogLanguageKey.INVALID_PASSWORD));
                        Session.Disconnect();
                        return;
                    }
                }
                else
                {
                    _logger.Error(LogLanguage.Instance.GetMessageFromKey(LogLanguageKey.INVALID_ACCOUNT));
                    Session.Disconnect();
                    return;
                }
            }

            var characters = DaoFactory.CharacterDao.Where(s =>
                s.AccountId == Session.Account.AccountId && s.State == CharacterState.Active);
            _logger.Information(LogLanguage.Instance.GetMessageFromKey(LogLanguageKey.ACCOUNT_ARRIVED),
                Session.Account.Name);

            // load characterlist packet for each character in Character
            Session.SendPacket(new ClistStartPacket { Type = 0 });
            foreach (var character in characters.Select(_characterBuilderService.LoadCharacter))
            {
                var equipment = new WearableInstance[16];
                /* IEnumerable<ItemInstanceDTO> inventory = DAOFactory.IteminstanceDAO.Where(s => s.CharacterId == character.CharacterId && s.Type == (byte)InventoryType.Wear);


                 foreach (ItemInstanceDTO equipmentEntry in inventory)
                 {
                     // explicit load of iteminstance
                     WearableInstance currentInstance = equipmentEntry as WearableInstance;
                     equipment[(short)currentInstance.Item.EquipmentSlot] = currentInstance;

                 }
                    */
                var petlist = new List<short?>();
                var mates = DaoFactory.MateDao.Where(s => s.CharacterId == character.CharacterId).ToList();
                for (var i = 0; i < 26; i++)
                {
                    if (mates.Count > i)
                    {
                        petlist.Add(mates[i].Skin);
                        petlist.Add(mates[i].VNum);
                    }
                    else
                    {
                        petlist.Add(-1);
                    }
                }

                // 1 1 before long string of -1.-1 = act completion
                Session.SendPacket(new ClistPacket
                {
                    Slot = character.Slot,
                    Name = character.Name,
                    Unknown = 0,
                    Gender = (byte)character.Gender,
                    HairStyle = (byte)character.HairStyle,
                    HairColor = (byte)character.HairColor,
                    Unknown1 = 0,
                    Class = (CharacterClassType)character.Class,
                    Level = character.Level,
                    HeroLevel = character.HeroLevel,
                    Equipments = new List<short?>
                    {
                        equipment[(byte) EquipmentType.Hat]?.ItemVNum ?? -1,
                        equipment[(byte) EquipmentType.Armor]?.ItemVNum ?? -1,
                        equipment[(byte) EquipmentType.WeaponSkin]?.ItemVNum ??
                        (equipment[(byte) EquipmentType.MainWeapon]?.ItemVNum ?? -1),
                        equipment[(byte) EquipmentType.SecondaryWeapon]?.ItemVNum ?? -1,
                        equipment[(byte) EquipmentType.Mask]?.ItemVNum ?? -1,
                        equipment[(byte) EquipmentType.Fairy]?.ItemVNum ?? -1,
                        equipment[(byte) EquipmentType.CostumeSuit]?.ItemVNum ?? -1,
                        equipment[(byte) EquipmentType.CostumeHat]?.ItemVNum ?? -1
                    },
                    JobLevel = character.JobLevel,
                    QuestCompletion = 1,
                    QuestPart = 1,
                    Pets = petlist,
                    Design = equipment[(byte)EquipmentType.Hat]?.Item.IsColored ?? false
                        ? equipment[(byte)EquipmentType.Hat].Design : 0,
                    Unknown3 = 0
                });
            }

            Session.SendPacket(new ClistEndPacket());
        }

        public void SelectCharacter(SelectPacket selectPacket)
        {
            try
            {
                if (Session?.Account == null || Session.HasSelectedCharacter)
                {
                    return;
                }

                var characterDto =
                    DaoFactory.CharacterDao.FirstOrDefault(s =>
                        s.AccountId == Session.Account.AccountId && s.Slot == selectPacket.Slot
                        && s.State == CharacterState.Active);
                if (characterDto == null)
                {
                    return;
                }

                var character = _characterBuilderService.LoadCharacter(characterDto);

                character.MapInstanceId = _mapInstanceAccessService.GetBaseMapInstanceIdByMapId(character.MapId);
                character.MapInstance = _mapInstanceAccessService.GetMapInstance(character.MapInstanceId);
                character.PositionX = character.MapX;
                character.PositionY = character.MapY;
                character.Direction = 2;
                character.Account = Session.Account;
                character.Group.JoinGroup(character);
                Session.SetCharacter(character);

                var inventories = DaoFactory.ItemInstanceDao.Where(s => s.CharacterId == character.CharacterId)
                    .ToList();
                inventories.ForEach(k => character.Inventory[k.Id] = _itemBuilderService.Convert(k));
#pragma warning disable CS0618
                Session.SendPackets(Session.Character.GenerateInv());
#pragma warning restore CS0618

                if (Session.Character.Hp > Session.Character.HpLoad())
                {
                    Session.Character.Hp = (int)Session.Character.HpLoad();
                }

                if (Session.Character.Mp > Session.Character.MpLoad())
                {
                    Session.Character.Mp = (int)Session.Character.MpLoad();
                }

                var relations =
                    DaoFactory.CharacterRelationDao.Where(s => s.CharacterId == Session.Character.CharacterId);
                var relationsWithCharacter =
                    DaoFactory.CharacterRelationDao.Where(s => s.RelatedCharacterId == Session.Character.CharacterId);

                var characters = DaoFactory.CharacterDao
                    .Where(s => relations.Select(v => v.RelatedCharacterId).Contains(s.CharacterId)).ToList();
                var relatedCharacters = DaoFactory.CharacterDao.Where(s =>
                    relationsWithCharacter.Select(v => v.RelatedCharacterId).Contains(s.CharacterId)).ToList();

                foreach (var relation in relations.Adapt<IEnumerable<CharacterRelation>>())
                {
                    relation.CharacterName = characters.Find(s => s.CharacterId == relation.RelatedCharacterId)?.Name;
                    Session.Character.CharacterRelations[relation.CharacterRelationId] = relation;
                }

                foreach (var relation in relationsWithCharacter.Adapt<IEnumerable<CharacterRelation>>())
                {
                    relation.CharacterName =
                        relatedCharacters.Find(s => s.CharacterId == relation.RelatedCharacterId)?.Name;
                    Session.Character.RelationWithCharacter[relation.CharacterRelationId] = relation;
                }

                Session.SendPacket(new OkPacket());
            }
            catch (Exception ex)
            {
                _logger.Error("Select character failed.", ex);
            }
        }
    }
}