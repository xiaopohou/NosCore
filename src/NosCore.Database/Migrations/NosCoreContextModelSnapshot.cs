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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NosCore.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NosCore.Database.Migrations
{
    [DbContext(typeof(NosCoreContext))]
    partial class NosCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NosCore.Database.Entities.Account", b =>
                {
                    b.Property<long>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Authority");

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<int>("Language");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("RegistrationIP")
                        .HasMaxLength(45);

                    b.Property<string>("VerificationToken")
                        .HasMaxLength(32);

                    b.HasKey("AccountId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("NosCore.Database.Entities.BazaarItem", b =>
                {
                    b.Property<long>("BazaarItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Amount");

                    b.Property<DateTime>("DateStart");

                    b.Property<short>("Duration");

                    b.Property<bool>("IsPackage");

                    b.Property<Guid>("ItemInstanceId");

                    b.Property<bool>("MedalUsed");

                    b.Property<long>("Price");

                    b.Property<long>("SellerId");

                    b.HasKey("BazaarItemId");

                    b.HasIndex("ItemInstanceId");

                    b.HasIndex("SellerId");

                    b.ToTable("BazaarItem");
                });

            modelBuilder.Entity("NosCore.Database.Entities.BCard", b =>
                {
                    b.Property<short>("BCardId")
                        .ValueGeneratedOnAdd();

                    b.Property<short?>("CardId");

                    b.Property<byte>("CastType");

                    b.Property<int>("FirstData");

                    b.Property<bool>("IsLevelDivided");

                    b.Property<bool>("IsLevelScaled");

                    b.Property<short?>("ItemVNum");

                    b.Property<short?>("NpcMonsterVNum");

                    b.Property<int>("SecondData");

                    b.Property<short?>("SkillVNum");

                    b.Property<byte>("SubType");

                    b.Property<int>("ThirdData");

                    b.Property<byte>("Type");

                    b.HasKey("BCardId");

                    b.HasIndex("CardId");

                    b.HasIndex("ItemVNum");

                    b.HasIndex("NpcMonsterVNum");

                    b.HasIndex("SkillVNum");

                    b.ToTable("BCard");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Card", b =>
                {
                    b.Property<short>("CardId");

                    b.Property<byte>("BuffType");

                    b.Property<int>("Delay");

                    b.Property<int>("Duration");

                    b.Property<int>("EffectId");

                    b.Property<byte>("Level");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<byte>("Propability");

                    b.Property<short>("TimeoutBuff");

                    b.Property<byte>("TimeoutBuffChance");

                    b.HasKey("CardId");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Character", b =>
                {
                    b.Property<long>("CharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountId");

                    b.Property<int>("Act4Dead");

                    b.Property<int>("Act4Kill");

                    b.Property<int>("Act4Points");

                    b.Property<int>("ArenaWinner");

                    b.Property<string>("Biography")
                        .HasMaxLength(255);

                    b.Property<bool>("BuffBlocked");

                    b.Property<byte>("Class");

                    b.Property<short>("Compliment");

                    b.Property<float>("Dignity");

                    b.Property<int>("Elo");

                    b.Property<bool>("EmoticonsBlocked");

                    b.Property<bool>("ExchangeBlocked");

                    b.Property<byte>("Faction");

                    b.Property<bool>("FamilyRequestBlocked");

                    b.Property<bool>("FriendRequestBlocked");

                    b.Property<byte>("Gender");

                    b.Property<long>("Gold");

                    b.Property<bool>("GroupRequestBlocked");

                    b.Property<byte>("HairColor");

                    b.Property<byte>("HairStyle");

                    b.Property<bool>("HeroChatBlocked");

                    b.Property<byte>("HeroLevel");

                    b.Property<long>("HeroXp");

                    b.Property<int>("Hp");

                    b.Property<bool>("HpBlocked");

                    b.Property<byte>("JobLevel");

                    b.Property<long>("JobLevelXp");

                    b.Property<byte>("Level");

                    b.Property<long>("LevelXp");

                    b.Property<short>("MapId");

                    b.Property<short>("MapX");

                    b.Property<short>("MapY");

                    b.Property<int>("MasterPoints");

                    b.Property<int>("MasterTicket");

                    b.Property<byte>("MaxMateCount");

                    b.Property<bool>("MinilandInviteBlocked");

                    b.Property<string>("MinilandMessage")
                        .HasMaxLength(255);

                    b.Property<short>("MinilandPoint");

                    b.Property<byte>("MinilandState");

                    b.Property<bool>("MouseAimLock");

                    b.Property<int>("Mp");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Prefix")
                        .HasMaxLength(25);

                    b.Property<bool>("QuickGetUp");

                    b.Property<long>("RagePoint");

                    b.Property<long>("Reput");

                    b.Property<byte>("Slot");

                    b.Property<int>("SpAdditionPoint");

                    b.Property<int>("SpPoint");

                    b.Property<byte>("State");

                    b.Property<int>("TalentLose");

                    b.Property<int>("TalentSurrender");

                    b.Property<int>("TalentWin");

                    b.Property<bool>("WhisperBlocked");

                    b.HasKey("CharacterId");

                    b.HasIndex("AccountId");

                    b.HasIndex("MapId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("NosCore.Database.Entities.CharacterQuest", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<long>("CharacterId");

                    b.Property<int>("FifthObjective");

                    b.Property<int>("FirstObjective");

                    b.Property<int>("FourthObjective");

                    b.Property<bool>("IsMainQuest");

                    b.Property<short>("QuestId");

                    b.Property<int>("SecondObjective");

                    b.Property<int>("ThirdObjective");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("QuestId");

                    b.ToTable("CharacterQuest");
                });

            modelBuilder.Entity("NosCore.Database.Entities.CharacterRelation", b =>
                {
                    b.Property<Guid>("CharacterRelationId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CharacterId");

                    b.Property<long>("RelatedCharacterId");

                    b.Property<short>("RelationType");

                    b.HasKey("CharacterRelationId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("RelatedCharacterId");

                    b.ToTable("CharacterRelation");
                });

            modelBuilder.Entity("NosCore.Database.Entities.CharacterSkill", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<long>("CharacterId");

                    b.Property<short>("SkillVNum");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SkillVNum");

                    b.ToTable("CharacterSkill");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Combo", b =>
                {
                    b.Property<int>("ComboId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Animation");

                    b.Property<short>("Effect");

                    b.Property<short>("Hit");

                    b.Property<short>("SkillVNum");

                    b.HasKey("ComboId");

                    b.HasIndex("SkillVNum");

                    b.ToTable("Combo");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Drop", b =>
                {
                    b.Property<short>("DropId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("DropChance");

                    b.Property<short?>("MapTypeId");

                    b.Property<short?>("MonsterVNum");

                    b.Property<short>("VNum");

                    b.HasKey("DropId");

                    b.HasIndex("MapTypeId");

                    b.HasIndex("MonsterVNum");

                    b.HasIndex("VNum");

                    b.ToTable("Drop");
                });

            modelBuilder.Entity("NosCore.Database.Entities.EquipmentOption", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<byte>("Level");

                    b.Property<byte>("Type");

                    b.Property<int>("Value");

                    b.Property<Guid>("WearableInstanceId");

                    b.HasKey("Id");

                    b.HasIndex("WearableInstanceId");

                    b.ToTable("EquipmentOption");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Family", b =>
                {
                    b.Property<long>("FamilyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FamilyExperience");

                    b.Property<byte>("FamilyFaction");

                    b.Property<byte>("FamilyHeadGender");

                    b.Property<byte>("FamilyLevel");

                    b.Property<string>("FamilyMessage")
                        .HasMaxLength(255);

                    b.Property<byte>("ManagerAuthorityType");

                    b.Property<bool>("ManagerCanGetHistory");

                    b.Property<bool>("ManagerCanInvite");

                    b.Property<bool>("ManagerCanNotice");

                    b.Property<bool>("ManagerCanShout");

                    b.Property<byte>("MaxSize");

                    b.Property<byte>("MemberAuthorityType");

                    b.Property<bool>("MemberCanGetHistory");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<byte>("WarehouseSize");

                    b.HasKey("FamilyId");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("NosCore.Database.Entities.FamilyCharacter", b =>
                {
                    b.Property<long>("FamilyCharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Authority");

                    b.Property<long>("CharacterId");

                    b.Property<string>("DailyMessage")
                        .HasMaxLength(255);

                    b.Property<int>("Experience");

                    b.Property<long>("FamilyId");

                    b.Property<byte>("Rank");

                    b.HasKey("FamilyCharacterId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("FamilyId");

                    b.ToTable("FamilyCharacter");
                });

            modelBuilder.Entity("NosCore.Database.Entities.FamilyLog", b =>
                {
                    b.Property<long>("FamilyLogId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("FamilyId");

                    b.Property<string>("FamilyLogData")
                        .HasMaxLength(255);

                    b.Property<byte>("FamilyLogType");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("FamilyLogId");

                    b.HasIndex("FamilyId");

                    b.ToTable("FamilyLog");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_ActDesc", b =>
                {
                    b.Property<int>("I18N_ActDescId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_ActDescId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_ActDesc");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_BCard", b =>
                {
                    b.Property<int>("I18N_BCardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_BCardId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_BCard");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_Card", b =>
                {
                    b.Property<int>("I18N_CardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_CardId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_Card");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_Item", b =>
                {
                    b.Property<int>("I18N_ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_ItemId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_Item");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_MapIdData", b =>
                {
                    b.Property<int>("I18N_MapIdDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_MapIdDataId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_MapIdData");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_MapPointData", b =>
                {
                    b.Property<int>("I18N_MapPointDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_MapPointDataId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_MapPointData");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_NpcMonster", b =>
                {
                    b.Property<int>("I18N_NpcMonsterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_NpcMonsterId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_NpcMonster");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_NpcMonsterTalk", b =>
                {
                    b.Property<int>("I18N_NpcMonsterTalkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_NpcMonsterTalkId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_NpcMonsterTalk");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_Quest", b =>
                {
                    b.Property<int>("I18N_QuestId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_QuestId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_Quest");
                });

            modelBuilder.Entity("NosCore.Database.Entities.I18N_Skill", b =>
                {
                    b.Property<int>("I18N_SkillId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<int>("RegionType");

                    b.Property<string>("Text");

                    b.HasKey("I18N_SkillId");

                    b.HasIndex("Key", "RegionType")
                        .IsUnique();

                    b.ToTable("I18N_Skill");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Item", b =>
                {
                    b.Property<short>("VNum");

                    b.Property<byte>("BasicUpgrade");

                    b.Property<byte>("CellonLvl");

                    b.Property<byte>("Class");

                    b.Property<short>("CloseDefence");

                    b.Property<byte>("Color");

                    b.Property<short>("Concentrate");

                    b.Property<byte>("CriticalLuckRate");

                    b.Property<short>("CriticalRate");

                    b.Property<short>("DamageMaximum");

                    b.Property<short>("DamageMinimum");

                    b.Property<byte>("DarkElement");

                    b.Property<short>("DarkResistance");

                    b.Property<short>("DefenceDodge");

                    b.Property<short>("DistanceDefence");

                    b.Property<short>("DistanceDefenceDodge");

                    b.Property<short>("Effect");

                    b.Property<int>("EffectValue");

                    b.Property<byte>("Element");

                    b.Property<short>("ElementRate");

                    b.Property<byte>("EquipmentSlot");

                    b.Property<byte>("FireElement");

                    b.Property<short>("FireResistance");

                    b.Property<bool>("Flag1");

                    b.Property<bool>("Flag2");

                    b.Property<bool>("Flag3");

                    b.Property<bool>("Flag4");

                    b.Property<bool>("Flag5");

                    b.Property<bool>("Flag6");

                    b.Property<bool>("Flag7");

                    b.Property<bool>("Flag8");

                    b.Property<bool>("Flag9");

                    b.Property<byte>("Height");

                    b.Property<short>("HitRate");

                    b.Property<short>("Hp");

                    b.Property<short>("HpRegeneration");

                    b.Property<bool>("IsColored");

                    b.Property<bool>("IsConsumable");

                    b.Property<bool>("IsDroppable");

                    b.Property<bool>("IsHeroic");

                    b.Property<bool>("IsMinilandActionable");

                    b.Property<bool>("IsSoldable");

                    b.Property<bool>("IsTradable");

                    b.Property<bool>("IsWarehouse");

                    b.Property<byte>("ItemSubType");

                    b.Property<byte>("ItemType");

                    b.Property<long>("ItemValidTime");

                    b.Property<byte>("LevelJobMinimum");

                    b.Property<byte>("LevelMinimum");

                    b.Property<byte>("LightElement");

                    b.Property<short>("LightResistance");

                    b.Property<short>("MagicDefence");

                    b.Property<byte>("MaxCellon");

                    b.Property<byte>("MaxCellonLvl");

                    b.Property<short>("MaxElementRate");

                    b.Property<byte>("MaximumAmmo");

                    b.Property<int>("MinilandObjectPoint");

                    b.Property<short>("MoreHp");

                    b.Property<short>("MoreMp");

                    b.Property<short>("Morph");

                    b.Property<short>("Mp");

                    b.Property<short>("MpRegeneration");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<long>("Price");

                    b.Property<short>("PvpDefence");

                    b.Property<byte>("PvpStrength");

                    b.Property<short>("ReduceOposantResistance");

                    b.Property<long>("ReputPrice");

                    b.Property<byte>("ReputationMinimum");

                    b.Property<byte>("SecondaryElement");

                    b.Property<byte>("Sex");

                    b.Property<byte>("SpType");

                    b.Property<byte>("Speed");

                    b.Property<byte>("Type");

                    b.Property<short>("WaitDelay");

                    b.Property<byte>("WaterElement");

                    b.Property<short>("WaterResistance");

                    b.Property<byte>("Width");

                    b.HasKey("VNum");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("NosCore.Database.Entities.ItemInstance", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<short>("Amount");

                    b.Property<long?>("BazaarItemId");

                    b.Property<long?>("BoundCharacterId");

                    b.Property<long>("CharacterId");

                    b.Property<short>("Design");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("DurabilityPoint");

                    b.Property<DateTime?>("ItemDeleteTime");

                    b.Property<short>("ItemVNum");

                    b.Property<short>("Rare");

                    b.Property<short>("Slot");

                    b.Property<byte>("Type");

                    b.Property<byte>("Upgrade");

                    b.HasKey("Id");

                    b.HasIndex("BoundCharacterId");

                    b.HasIndex("ItemVNum");

                    b.HasIndex("CharacterId", "Slot", "Type")
                        .IsUnique();

                    b.ToTable("ItemInstance");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ItemInstance");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Mail", b =>
                {
                    b.Property<long>("MailId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("AttachmentAmount");

                    b.Property<byte>("AttachmentRarity");

                    b.Property<byte>("AttachmentUpgrade");

                    b.Property<short?>("AttachmentVNum");

                    b.Property<DateTime>("Date");

                    b.Property<string>("EqPacket")
                        .HasMaxLength(255);

                    b.Property<bool>("IsOpened");

                    b.Property<bool>("IsSenderCopy");

                    b.Property<string>("Message")
                        .HasMaxLength(255);

                    b.Property<long>("ReceiverId");

                    b.Property<byte>("SenderCharacterClass");

                    b.Property<byte>("SenderGender");

                    b.Property<byte>("SenderHairColor");

                    b.Property<byte>("SenderHairStyle");

                    b.Property<long>("SenderId");

                    b.Property<short>("SenderMorphId");

                    b.Property<string>("Title")
                        .HasMaxLength(255);

                    b.HasKey("MailId");

                    b.HasIndex("AttachmentVNum");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Mail");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Map", b =>
                {
                    b.Property<short>("MapId");

                    b.Property<byte[]>("Data");

                    b.Property<int>("Music");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<bool>("ShopAllowed");

                    b.HasKey("MapId");

                    b.ToTable("Map");
                });

            modelBuilder.Entity("NosCore.Database.Entities.MapMonster", b =>
                {
                    b.Property<int>("MapMonsterId");

                    b.Property<byte>("Direction");

                    b.Property<bool>("IsDisabled");

                    b.Property<bool>("IsMoving");

                    b.Property<short>("MapId");

                    b.Property<short>("MapX");

                    b.Property<short>("MapY");

                    b.Property<short>("VNum");

                    b.HasKey("MapMonsterId");

                    b.HasIndex("MapId");

                    b.HasIndex("VNum");

                    b.ToTable("MapMonster");
                });

            modelBuilder.Entity("NosCore.Database.Entities.MapNpc", b =>
                {
                    b.Property<int>("MapNpcId");

                    b.Property<short>("Dialog");

                    b.Property<byte>("Direction");

                    b.Property<short>("Effect");

                    b.Property<short>("EffectDelay");

                    b.Property<bool>("IsDisabled");

                    b.Property<bool>("IsMoving");

                    b.Property<bool>("IsSitting");

                    b.Property<short>("MapId");

                    b.Property<short>("MapX");

                    b.Property<short>("MapY");

                    b.Property<short>("VNum");

                    b.HasKey("MapNpcId");

                    b.HasIndex("MapId");

                    b.HasIndex("VNum");

                    b.ToTable("MapNpc");
                });

            modelBuilder.Entity("NosCore.Database.Entities.MapType", b =>
                {
                    b.Property<short>("MapTypeId");

                    b.Property<string>("MapTypeName");

                    b.Property<short>("PotionDelay");

                    b.Property<long?>("RespawnMapTypeId");

                    b.Property<long?>("ReturnMapTypeId");

                    b.HasKey("MapTypeId");

                    b.HasIndex("RespawnMapTypeId");

                    b.HasIndex("ReturnMapTypeId");

                    b.ToTable("MapType");
                });

            modelBuilder.Entity("NosCore.Database.Entities.MapTypeMap", b =>
                {
                    b.Property<short>("MapTypeMapId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("MapId");

                    b.Property<short>("MapTypeId");

                    b.HasKey("MapTypeMapId");

                    b.HasIndex("MapTypeId");

                    b.HasIndex("MapId", "MapTypeId")
                        .IsUnique();

                    b.ToTable("MapTypeMap");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Mate", b =>
                {
                    b.Property<long>("MateId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Attack");

                    b.Property<bool>("CanPickUp");

                    b.Property<long>("CharacterId");

                    b.Property<byte>("Defence");

                    b.Property<byte>("Direction");

                    b.Property<long>("Experience");

                    b.Property<int>("Hp");

                    b.Property<bool>("IsSummonable");

                    b.Property<bool>("IsTeamMember");

                    b.Property<byte>("Level");

                    b.Property<short>("Loyalty");

                    b.Property<short>("MapX");

                    b.Property<short>("MapY");

                    b.Property<byte>("MateType");

                    b.Property<int>("Mp");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<short>("Skin");

                    b.Property<short>("VNum");

                    b.HasKey("MateId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("VNum");

                    b.ToTable("Mate");
                });

            modelBuilder.Entity("NosCore.Database.Entities.MinilandObject", b =>
                {
                    b.Property<long>("MinilandObjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CharacterId");

                    b.Property<Guid?>("ItemInstanceId");

                    b.Property<byte>("Level1BoxAmount");

                    b.Property<byte>("Level2BoxAmount");

                    b.Property<byte>("Level3BoxAmount");

                    b.Property<byte>("Level4BoxAmount");

                    b.Property<byte>("Level5BoxAmount");

                    b.Property<short>("MapX");

                    b.Property<short>("MapY");

                    b.HasKey("MinilandObjectId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ItemInstanceId");

                    b.ToTable("MinilandObject");
                });

            modelBuilder.Entity("NosCore.Database.Entities.NpcMonster", b =>
                {
                    b.Property<short>("NpcMonsterVNum");

                    b.Property<byte>("AmountRequired");

                    b.Property<byte>("AttackClass");

                    b.Property<byte>("AttackUpgrade");

                    b.Property<byte>("BasicArea");

                    b.Property<short>("BasicCooldown");

                    b.Property<byte>("BasicRange");

                    b.Property<short>("BasicSkill");

                    b.Property<short>("CloseDefence");

                    b.Property<short>("Concentrate");

                    b.Property<byte>("CriticalChance");

                    b.Property<short>("CriticalRate");

                    b.Property<short>("DamageMaximum");

                    b.Property<short>("DamageMinimum");

                    b.Property<short>("DarkResistance");

                    b.Property<short>("DefenceDodge");

                    b.Property<byte>("DefenceUpgrade");

                    b.Property<short>("DistanceDefence");

                    b.Property<short>("DistanceDefenceDodge");

                    b.Property<byte>("Element");

                    b.Property<short>("ElementRate");

                    b.Property<short>("FireResistance");

                    b.Property<int>("GiveDamagePercentage");

                    b.Property<byte>("HeroLevel");

                    b.Property<int>("HeroXP");

                    b.Property<bool>("IsHostile");

                    b.Property<bool>("IsPercent");

                    b.Property<int>("JobXP");

                    b.Property<byte>("Level");

                    b.Property<short>("LightResistance");

                    b.Property<short>("MagicDefence");

                    b.Property<int>("MaxHP");

                    b.Property<int>("MaxMP");

                    b.Property<byte>("MonsterType");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<bool>("NoAggresiveIcon");

                    b.Property<byte>("NoticeRange");

                    b.Property<byte>("Race");

                    b.Property<byte>("RaceType");

                    b.Property<int>("RespawnTime");

                    b.Property<byte>("Speed");

                    b.Property<int>("TakeDamages");

                    b.Property<short>("VNumRequired");

                    b.Property<short>("WaterResistance");

                    b.Property<int>("XP");

                    b.HasKey("NpcMonsterVNum");

                    b.ToTable("NpcMonster");
                });

            modelBuilder.Entity("NosCore.Database.Entities.NpcMonsterSkill", b =>
                {
                    b.Property<long>("NpcMonsterSkillId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("NpcMonsterVNum");

                    b.Property<short>("Rate");

                    b.Property<short>("SkillVNum");

                    b.HasKey("NpcMonsterSkillId");

                    b.HasIndex("NpcMonsterVNum");

                    b.HasIndex("SkillVNum");

                    b.ToTable("NpcMonsterSkill");
                });

            modelBuilder.Entity("NosCore.Database.Entities.PenaltyLog", b =>
                {
                    b.Property<int>("PenaltyLogId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountId");

                    b.Property<string>("AdminName");

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<byte>("Penalty");

                    b.Property<string>("Reason")
                        .HasMaxLength(255);

                    b.HasKey("PenaltyLogId");

                    b.HasIndex("AccountId");

                    b.ToTable("PenaltyLog");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Portal", b =>
                {
                    b.Property<int>("PortalId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("DestinationMapId");

                    b.Property<short>("DestinationX");

                    b.Property<short>("DestinationY");

                    b.Property<bool>("IsDisabled");

                    b.Property<short>("SourceMapId");

                    b.Property<short>("SourceX");

                    b.Property<short>("SourceY");

                    b.Property<short>("Type");

                    b.HasKey("PortalId");

                    b.HasIndex("DestinationMapId");

                    b.HasIndex("SourceMapId");

                    b.ToTable("Portal");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Quest", b =>
                {
                    b.Property<short>("QuestId");

                    b.Property<int?>("EndDialogId");

                    b.Property<int>("InfoId");

                    b.Property<bool>("IsDaily");

                    b.Property<byte>("LevelMax");

                    b.Property<byte>("LevelMin");

                    b.Property<long?>("NextQuestId");

                    b.Property<int>("QuestType");

                    b.Property<int?>("SpecialData");

                    b.Property<int?>("StartDialogId");

                    b.Property<short?>("TargetMap");

                    b.Property<short?>("TargetX");

                    b.Property<short?>("TargetY");

                    b.HasKey("QuestId");

                    b.ToTable("Quest");
                });

            modelBuilder.Entity("NosCore.Database.Entities.QuestObjective", b =>
                {
                    b.Property<short>("QuestObjectiveId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Data");

                    b.Property<int>("Objective");

                    b.Property<short>("QuestId");

                    b.Property<int?>("SpecialData");

                    b.HasKey("QuestObjectiveId");

                    b.HasIndex("QuestId");

                    b.ToTable("QuestObjective");
                });

            modelBuilder.Entity("NosCore.Database.Entities.QuestReward", b =>
                {
                    b.Property<long>("QuestRewardId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("Data");

                    b.Property<byte>("Design");

                    b.Property<short>("QuestId");

                    b.Property<byte>("Rarity");

                    b.Property<byte>("RewardType");

                    b.Property<byte>("Upgrade");

                    b.HasKey("QuestRewardId");

                    b.HasIndex("QuestId");

                    b.ToTable("QuestReward");
                });

            modelBuilder.Entity("NosCore.Database.Entities.QuicklistEntry", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<long>("CharacterId");

                    b.Property<short>("Morph");

                    b.Property<short>("Pos");

                    b.Property<short>("Q1");

                    b.Property<short>("Q2");

                    b.Property<short>("Slot");

                    b.Property<short>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("QuicklistEntry");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Recipe", b =>
                {
                    b.Property<short>("RecipeId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Amount");

                    b.Property<short>("ItemVNum");

                    b.Property<int>("MapNpcId");

                    b.HasKey("RecipeId");

                    b.HasIndex("ItemVNum");

                    b.HasIndex("MapNpcId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("NosCore.Database.Entities.RecipeItem", b =>
                {
                    b.Property<short>("RecipeItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Amount");

                    b.Property<short>("ItemVNum");

                    b.Property<short>("RecipeId");

                    b.HasKey("RecipeItemId");

                    b.HasIndex("ItemVNum");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeItem");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Respawn", b =>
                {
                    b.Property<long>("RespawnId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CharacterId");

                    b.Property<short>("MapId");

                    b.Property<long>("RespawnMapTypeId");

                    b.Property<short>("X");

                    b.Property<short>("Y");

                    b.HasKey("RespawnId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("MapId");

                    b.HasIndex("RespawnMapTypeId");

                    b.ToTable("Respawn");
                });

            modelBuilder.Entity("NosCore.Database.Entities.RespawnMapType", b =>
                {
                    b.Property<long>("RespawnMapTypeId");

                    b.Property<short>("DefaultX");

                    b.Property<short>("DefaultY");

                    b.Property<short>("MapId");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("RespawnMapTypeId");

                    b.HasIndex("MapId");

                    b.ToTable("RespawnMapType");
                });

            modelBuilder.Entity("NosCore.Database.Entities.RollGeneratedItem", b =>
                {
                    b.Property<short>("RollGeneratedItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsRareRandom");

                    b.Property<bool>("IsSuperReward");

                    b.Property<byte>("ItemGeneratedAmount");

                    b.Property<byte>("ItemGeneratedUpgrade");

                    b.Property<short>("ItemGeneratedVNum");

                    b.Property<short>("MaximumOriginalItemRare");

                    b.Property<short>("MinimumOriginalItemRare");

                    b.Property<short>("OriginalItemDesign");

                    b.Property<short>("OriginalItemVNum");

                    b.Property<short>("Probability");

                    b.HasKey("RollGeneratedItemId");

                    b.HasIndex("ItemGeneratedVNum");

                    b.HasIndex("OriginalItemVNum");

                    b.ToTable("RollGeneratedItem");
                });

            modelBuilder.Entity("NosCore.Database.Entities.ScriptedInstance", b =>
                {
                    b.Property<short>("ScriptedInstanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.Property<short>("MapId");

                    b.Property<short>("PositionX");

                    b.Property<short>("PositionY");

                    b.Property<string>("Script")
                        .HasMaxLength(2147483647);

                    b.Property<byte>("Type");

                    b.HasKey("ScriptedInstanceId");

                    b.HasIndex("MapId");

                    b.ToTable("ScriptedInstance");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MapNpcId");

                    b.Property<byte>("MenuType");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<byte>("ShopType");

                    b.HasKey("ShopId");

                    b.HasIndex("MapNpcId");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("NosCore.Database.Entities.ShopItem", b =>
                {
                    b.Property<int>("ShopItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("Color");

                    b.Property<short>("ItemVNum");

                    b.Property<short>("Rare");

                    b.Property<int>("ShopId");

                    b.Property<byte>("Slot");

                    b.Property<byte>("Type");

                    b.Property<byte>("Upgrade");

                    b.HasKey("ShopItemId");

                    b.HasIndex("ItemVNum");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopItem");
                });

            modelBuilder.Entity("NosCore.Database.Entities.ShopSkill", b =>
                {
                    b.Property<int>("ShopSkillId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ShopId");

                    b.Property<short>("SkillVNum");

                    b.Property<byte>("Slot");

                    b.Property<byte>("Type");

                    b.HasKey("ShopSkillId");

                    b.HasIndex("ShopId");

                    b.HasIndex("SkillVNum");

                    b.ToTable("ShopSkill");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Skill", b =>
                {
                    b.Property<short>("SkillVNum");

                    b.Property<short>("AttackAnimation");

                    b.Property<byte>("CPCost");

                    b.Property<short>("CastAnimation");

                    b.Property<short>("CastEffect");

                    b.Property<short>("CastId");

                    b.Property<short>("CastTime");

                    b.Property<byte>("Class");

                    b.Property<short>("Cooldown");

                    b.Property<short>("Duration");

                    b.Property<short>("Effect");

                    b.Property<byte>("Element");

                    b.Property<byte>("HitType");

                    b.Property<short>("ItemVNum");

                    b.Property<byte>("Level");

                    b.Property<byte>("LevelMinimum");

                    b.Property<byte>("MinimumAdventurerLevel");

                    b.Property<byte>("MinimumArcherLevel");

                    b.Property<byte>("MinimumMagicianLevel");

                    b.Property<byte>("MinimumSwordmanLevel");

                    b.Property<short>("MpCost");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("Price");

                    b.Property<byte>("Range");

                    b.Property<byte>("SkillType");

                    b.Property<byte>("TargetRange");

                    b.Property<byte>("TargetType");

                    b.Property<byte>("Type");

                    b.Property<short>("UpgradeSkill");

                    b.Property<short>("UpgradeType");

                    b.HasKey("SkillVNum");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("NosCore.Database.Entities.StaticBonus", b =>
                {
                    b.Property<long>("StaticBonusId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CharacterId");

                    b.Property<DateTime>("DateEnd");

                    b.Property<byte>("StaticBonusType");

                    b.HasKey("StaticBonusId");

                    b.HasIndex("CharacterId");

                    b.ToTable("StaticBonus");
                });

            modelBuilder.Entity("NosCore.Database.Entities.StaticBuff", b =>
                {
                    b.Property<long>("StaticBuffId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("CardId");

                    b.Property<long>("CharacterId");

                    b.Property<int>("RemainingTime");

                    b.HasKey("StaticBuffId");

                    b.HasIndex("CardId");

                    b.HasIndex("CharacterId");

                    b.ToTable("StaticBuff");
                });

            modelBuilder.Entity("NosCore.Database.Entities.Teleporter", b =>
                {
                    b.Property<short>("TeleporterId")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("Index");

                    b.Property<short>("MapId");

                    b.Property<int>("MapNpcId");

                    b.Property<short>("MapX");

                    b.Property<short>("MapY");

                    b.Property<byte>("Type");

                    b.HasKey("TeleporterId");

                    b.HasIndex("MapId");

                    b.HasIndex("MapNpcId");

                    b.ToTable("Teleporter");
                });

            modelBuilder.Entity("NosCore.Database.Entities.UsableInstance", b =>
                {
                    b.HasBaseType("NosCore.Database.Entities.ItemInstance");

                    b.Property<short?>("HP");

                    b.Property<short?>("MP");

                    b.ToTable("UsableInstance");

                    b.HasDiscriminator().HasValue("UsableInstance");
                });

            modelBuilder.Entity("NosCore.Database.Entities.WearableInstance", b =>
                {
                    b.HasBaseType("NosCore.Database.Entities.ItemInstance");

                    b.Property<byte?>("Ammo");

                    b.Property<byte?>("Cellon");

                    b.Property<short?>("CloseDefence");

                    b.Property<short?>("Concentrate");

                    b.Property<short?>("CriticalDodge");

                    b.Property<byte?>("CriticalLuckRate");

                    b.Property<short?>("CriticalRate");

                    b.Property<short?>("DamageMaximum");

                    b.Property<short?>("DamageMinimum");

                    b.Property<byte?>("DarkElement");

                    b.Property<short?>("DarkResistance");

                    b.Property<short?>("DefenceDodge");

                    b.Property<short?>("DistanceDefence");

                    b.Property<short?>("DistanceDefenceDodge");

                    b.Property<short?>("ElementRate");

                    b.Property<byte?>("FireElement");

                    b.Property<short?>("FireResistance");

                    b.Property<short?>("HP")
                        .HasColumnName("WearableInstance_HP");

                    b.Property<short?>("HitRate");

                    b.Property<bool?>("IsEmpty");

                    b.Property<bool?>("IsFixed");

                    b.Property<byte?>("LightElement");

                    b.Property<short?>("LightResistance");

                    b.Property<short?>("MP")
                        .HasColumnName("WearableInstance_MP");

                    b.Property<short?>("MagicDefence");

                    b.Property<short?>("MaxElementRate");

                    b.Property<byte?>("ShellRarity");

                    b.Property<byte?>("WaterElement");

                    b.Property<short?>("WaterResistance");

                    b.Property<long?>("XP");

                    b.ToTable("WearableInstance");

                    b.HasDiscriminator().HasValue("WearableInstance");
                });

            modelBuilder.Entity("NosCore.Database.Entities.SpecialistInstance", b =>
                {
                    b.HasBaseType("NosCore.Database.Entities.WearableInstance");

                    b.Property<short?>("SlDamage");

                    b.Property<short?>("SlDefence");

                    b.Property<short?>("SlElement");

                    b.Property<short?>("SlHP");

                    b.Property<byte?>("SpDamage");

                    b.Property<byte?>("SpDark");

                    b.Property<byte?>("SpDefence");

                    b.Property<byte?>("SpElement");

                    b.Property<byte?>("SpFire");

                    b.Property<byte?>("SpHP");

                    b.Property<byte?>("SpLevel");

                    b.Property<byte?>("SpLight");

                    b.Property<byte?>("SpStoneUpgrade");

                    b.Property<byte?>("SpWater");

                    b.ToTable("SpecialistInstance");

                    b.HasDiscriminator().HasValue("SpecialistInstance");
                });

            modelBuilder.Entity("NosCore.Database.Entities.BoxInstance", b =>
                {
                    b.HasBaseType("NosCore.Database.Entities.SpecialistInstance");

                    b.Property<short?>("HoldingVNum");

                    b.ToTable("BoxInstance");

                    b.HasDiscriminator().HasValue("BoxInstance");
                });

            modelBuilder.Entity("NosCore.Database.Entities.BazaarItem", b =>
                {
                    b.HasOne("NosCore.Database.Entities.ItemInstance", "ItemInstance")
                        .WithMany("BazaarItem")
                        .HasForeignKey("ItemInstanceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("BazaarItem")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.BCard", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Card", "Card")
                        .WithMany("BCards")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Item", "Item")
                        .WithMany("BCards")
                        .HasForeignKey("ItemVNum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.NpcMonster", "NpcMonster")
                        .WithMany("BCards")
                        .HasForeignKey("NpcMonsterVNum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Skill", "Skill")
                        .WithMany("BCards")
                        .HasForeignKey("SkillVNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Character", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Account", "Account")
                        .WithMany("Character")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Map", "Map")
                        .WithMany("Character")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.CharacterQuest", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("CharacterQuest")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Quest", "Quest")
                        .WithMany("CharacterQuest")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.CharacterRelation", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "Character1")
                        .WithMany("CharacterRelation1")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Character", "Character2")
                        .WithMany("CharacterRelation2")
                        .HasForeignKey("RelatedCharacterId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.CharacterSkill", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("CharacterSkill")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Skill", "Skill")
                        .WithMany("CharacterSkill")
                        .HasForeignKey("SkillVNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Combo", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Skill", "Skill")
                        .WithMany("Combo")
                        .HasForeignKey("SkillVNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Drop", b =>
                {
                    b.HasOne("NosCore.Database.Entities.MapType", "MapType")
                        .WithMany("Drops")
                        .HasForeignKey("MapTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.NpcMonster", "NpcMonster")
                        .WithMany("Drop")
                        .HasForeignKey("MonsterVNum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Item", "Item")
                        .WithMany("Drop")
                        .HasForeignKey("VNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.EquipmentOption", b =>
                {
                    b.HasOne("NosCore.Database.Entities.WearableInstance", "WearableInstance")
                        .WithMany()
                        .HasForeignKey("WearableInstanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NosCore.Database.Entities.FamilyCharacter", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("FamilyCharacter")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Family", "Family")
                        .WithMany("FamilyCharacters")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.FamilyLog", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Family", "Family")
                        .WithMany("FamilyLogs")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.ItemInstance", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "BoundCharacter")
                        .WithMany()
                        .HasForeignKey("BoundCharacterId");

                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("Inventory")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Item", "Item")
                        .WithMany("ItemInstances")
                        .HasForeignKey("ItemVNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Mail", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Item", "Item")
                        .WithMany("Mail")
                        .HasForeignKey("AttachmentVNum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Character", "Receiver")
                        .WithMany("Mail1")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Character", "Sender")
                        .WithMany("Mail")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.MapMonster", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Map", "Map")
                        .WithMany("MapMonster")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.NpcMonster", "NpcMonster")
                        .WithMany("MapMonster")
                        .HasForeignKey("VNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.MapNpc", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Map", "Map")
                        .WithMany("MapNpc")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.NpcMonster", "NpcMonster")
                        .WithMany("MapNpc")
                        .HasForeignKey("VNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.MapType", b =>
                {
                    b.HasOne("NosCore.Database.Entities.RespawnMapType", "RespawnMapType")
                        .WithMany("MapTypes")
                        .HasForeignKey("RespawnMapTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.RespawnMapType", "ReturnMapType")
                        .WithMany("MapTypes1")
                        .HasForeignKey("ReturnMapTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.MapTypeMap", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Map", "Map")
                        .WithMany("MapTypeMap")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.MapType", "MapType")
                        .WithMany("MapTypeMap")
                        .HasForeignKey("MapTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Mate", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("Mate")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.NpcMonster", "NpcMonster")
                        .WithMany("Mate")
                        .HasForeignKey("VNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.MinilandObject", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("MinilandObject")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.ItemInstance", "ItemInstance")
                        .WithMany("MinilandObject")
                        .HasForeignKey("ItemInstanceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.NpcMonsterSkill", b =>
                {
                    b.HasOne("NosCore.Database.Entities.NpcMonster", "NpcMonster")
                        .WithMany("NpcMonsterSkill")
                        .HasForeignKey("NpcMonsterVNum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Skill", "Skill")
                        .WithMany("NpcMonsterSkill")
                        .HasForeignKey("SkillVNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.PenaltyLog", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Account", "Account")
                        .WithMany("PenaltyLog")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Portal", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Map", "Map")
                        .WithMany("Portal")
                        .HasForeignKey("DestinationMapId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Map", "Map1")
                        .WithMany("Portal1")
                        .HasForeignKey("SourceMapId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.QuestObjective", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Quest", "Quest")
                        .WithMany("QuestObjective")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.QuestReward", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Quest", "Quest")
                        .WithMany()
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NosCore.Database.Entities.QuicklistEntry", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("QuicklistEntry")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Recipe", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Item", "Item")
                        .WithMany("Recipe")
                        .HasForeignKey("ItemVNum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.MapNpc", "MapNpc")
                        .WithMany("Recipe")
                        .HasForeignKey("MapNpcId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.RecipeItem", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Item", "Item")
                        .WithMany("RecipeItem")
                        .HasForeignKey("ItemVNum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Recipe", "Recipe")
                        .WithMany("RecipeItem")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Respawn", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("Respawn")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Map", "Map")
                        .WithMany("Respawn")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.RespawnMapType", "RespawnMapType")
                        .WithMany("Respawn")
                        .HasForeignKey("RespawnMapTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.RespawnMapType", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Map", "Map")
                        .WithMany("RespawnMapType")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.RollGeneratedItem", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Item", "ItemGenerated")
                        .WithMany("RollGeneratedItem2")
                        .HasForeignKey("ItemGeneratedVNum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Item", "OriginalItem")
                        .WithMany("RollGeneratedItem")
                        .HasForeignKey("OriginalItemVNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.ScriptedInstance", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Map", "Map")
                        .WithMany("ScriptedInstance")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Shop", b =>
                {
                    b.HasOne("NosCore.Database.Entities.MapNpc", "MapNpc")
                        .WithMany("Shop")
                        .HasForeignKey("MapNpcId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.ShopItem", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Item", "Item")
                        .WithMany("ShopItem")
                        .HasForeignKey("ItemVNum")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Shop", "Shop")
                        .WithMany("ShopItem")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.ShopSkill", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Shop", "Shop")
                        .WithMany("ShopSkill")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Skill", "Skill")
                        .WithMany("ShopSkill")
                        .HasForeignKey("SkillVNum")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.StaticBonus", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("StaticBonus")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.StaticBuff", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Card", "Card")
                        .WithMany("StaticBuff")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.Character", "Character")
                        .WithMany("StaticBuff")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NosCore.Database.Entities.Teleporter", b =>
                {
                    b.HasOne("NosCore.Database.Entities.Map", "Map")
                        .WithMany("Teleporter")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NosCore.Database.Entities.MapNpc", "MapNpc")
                        .WithMany("Teleporter")
                        .HasForeignKey("MapNpcId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
