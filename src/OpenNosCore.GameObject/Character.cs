﻿using OpenNosCore.Core.Logger;
using OpenNosCore.Data;
using OpenNosCore.Enum;
using OpenNosCore.Packets;
using OpenNosCore.GameObject.Helper;
using System;

namespace OpenNosCore.GameObject
{
    public class Character : CharacterDTO
    {
        public bool IsChangingMapInstance { get; set; }

        public MapInstance MapInstance { get; set; }

        public ClientSession Session { get; set; }

        public double MPLoad()
        {
            int mp = 0;
            double multiplicator = 1.0;
            return (int)((CharacterHelper.Instance.MpData[(byte)Class, Level] + mp) * multiplicator);
        }
        public double HPLoad()
        {
            double multiplicator = 1.0;
            int hp = 0;

            return (int)((CharacterHelper.Instance.HpData[(byte)Class, Level] + hp) * multiplicator);
        }

        public AtPacket GenerateAt()
        {
            return new AtPacket()
            {
                CharacterId = CharacterId,
                MapId = MapId,
                PositionX = PositionX,
                PositionY = PositionY,
                Unknown1 = 2,
                Unknown2 = 0,
                Music = MapInstance.Map.Music,
                Unknown3 = -1
            };
        }

        public CInfoPacket GenerateCInfo()
        {
            return new CInfoPacket()
            {
                Name = (Account.Authority == AuthorityType.Moderator ? $"[{Language.Instance.GetMessageFromKey("SUPPORT")}]" + Name : Name),
                Unknown1 = string.Empty,
                Unknown2 = -1,
                FamilyId = -1,
                FamilyName = string.Empty,
                CharacterId = CharacterId,
                Authority = (byte)Account.Authority,
                Gender = (byte)Gender,
                HairStyle = (byte)HairStyle,
                HairColor = (byte)HairColor,
                Class = (byte)Class,
                Icon = 1,
                Compliment = (short)(Account.Authority == AuthorityType.Moderator ? 500 : Compliment),
                Invisible = false,
                FamilyLevel = 0,
                MorphUpgrade = 0,
                ArenaWinner = false
            };
        }

        internal void SetSession(ClientSession clientSession)
        {
            throw new NotImplementedException();
        }
    }
}