// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: p34_pb.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace BLHX.Server.Common.Proto.p34
{

    [global::ProtoBuf.ProtoContract(Name = @"cs_34001")]
    public partial class Cs34001 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"group_id")]
        public global::System.Collections.Generic.List<uint> GroupIds { get; set; } = new global::System.Collections.Generic.List<uint>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34003")]
    public partial class Cs34003 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"group_id", IsRequired = true)]
        public uint GroupId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"target_pt", IsRequired = true)]
        public uint TargetPt { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34501")]
    public partial class Cs34501 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34503")]
    public partial class Cs34503 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"user_id_list")]
        public global::System.Collections.Generic.List<uint> UserIdLists { get; set; } = new global::System.Collections.Generic.List<uint>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34505")]
    public partial class Cs34505 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_id", IsRequired = true)]
        public uint BossId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34509")]
    public partial class Cs34509 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34511")]
    public partial class Cs34511 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_id", IsRequired = true)]
        public uint BossId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34513")]
    public partial class Cs34513 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34515")]
    public partial class Cs34515 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_id", IsRequired = true)]
        public uint BossId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"last_time")]
        public uint LastTime
        {
            get => __pbn__LastTime.GetValueOrDefault();
            set => __pbn__LastTime = value;
        }
        public bool ShouldSerializeLastTime() => __pbn__LastTime != null;
        public void ResetLastTime() => __pbn__LastTime = null;
        private uint? __pbn__LastTime;

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34517")]
    public partial class Cs34517 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_id")]
        public global::System.Collections.Generic.List<uint> BossIds { get; set; } = new global::System.Collections.Generic.List<uint>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34519")]
    public partial class Cs34519 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_id", IsRequired = true)]
        public uint BossId { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public uint userId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34521")]
    public partial class Cs34521 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"template_id", IsRequired = true)]
        public uint TemplateId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34523")]
    public partial class Cs34523 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_id", IsRequired = true)]
        public uint BossId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34525")]
    public partial class Cs34525 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_id", IsRequired = true)]
        public uint BossId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_34527")]
    public partial class Cs34527 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_id", IsRequired = true)]
        public uint BossId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"meta_ship_info")]
    public partial class MetaShipInfo : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"group_id", IsRequired = true)]
        public uint GroupId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"pt", IsRequired = true)]
        public uint Pt { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"fetch_list")]
        public global::System.Collections.Generic.List<uint> FetchLists { get; set; } = new global::System.Collections.Generic.List<uint>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34002")]
    public partial class Sc34002 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"meta_ship_list")]
        public global::System.Collections.Generic.List<MetaShipInfo> MetaShipLists { get; set; } = new global::System.Collections.Generic.List<MetaShipInfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34004")]
    public partial class Sc34004 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"drop_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo> DropLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34502")]
    public partial class Sc34502 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"fight_count", IsRequired = true)]
        public uint FightCount { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"fight_count_update_time", IsRequired = true)]
        public uint FightCountUpdateTime { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"self_boss")]
        public global::BLHX.Server.Common.Proto.p33.WorldbossInfo SelfBoss { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"other_boss")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.p33.WorldbossInfo> OtherBosses { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.p33.WorldbossInfo>();

        [global::ProtoBuf.ProtoMember(5, Name = @"summon_pt", IsRequired = true)]
        public uint SummonPt { get; set; }

        [global::ProtoBuf.ProtoMember(6, Name = @"summon_pt_old", IsRequired = true)]
        public uint SummonPtOld { get; set; }

        [global::ProtoBuf.ProtoMember(7, Name = @"summon_pt_daily_acc", IsRequired = true)]
        public uint SummonPtDailyAcc { get; set; }

        [global::ProtoBuf.ProtoMember(8, Name = @"summon_pt_old_daily_acc", IsRequired = true)]
        public uint SummonPtOldDailyAcc { get; set; }

        [global::ProtoBuf.ProtoMember(9, Name = @"summon_free", IsRequired = true)]
        public uint SummonFree { get; set; }

        [global::ProtoBuf.ProtoMember(10, Name = @"auto_fight_finish_time", IsRequired = true)]
        public uint AutoFightFinishTime { get; set; }

        [global::ProtoBuf.ProtoMember(11, Name = @"default_boss_id", IsRequired = true)]
        public uint DefaultBossId { get; set; }

        [global::ProtoBuf.ProtoMember(12, Name = @"auto_fight_max_damage", IsRequired = true)]
        public uint AutoFightMaxDamage { get; set; }

        [global::ProtoBuf.ProtoMember(13, Name = @"guild_support", IsRequired = true)]
        public uint GuildSupport { get; set; }

        [global::ProtoBuf.ProtoMember(14, Name = @"friend_support", IsRequired = true)]
        public uint FriendSupport { get; set; }

        [global::ProtoBuf.ProtoMember(15, Name = @"world_support", IsRequired = true)]
        public uint WorldSupport { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34504")]
    public partial class Sc34504 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.p33.WorldbossInfo> BossLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.p33.WorldbossInfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34506")]
    public partial class Sc34506 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"rank_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.p33.WorldbossRank> RankLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.p33.WorldbossRank>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34507")]
    public partial class Sc34507 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_info", IsRequired = true)]
        public global::BLHX.Server.Common.Proto.p33.WorldbossInfo BossInfo { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"user_info", IsRequired = true)]
        public global::BLHX.Server.Common.Proto.common.Usersimpleinfo UserInfo { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34508")]
    public partial class Sc34508 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boss_id", IsRequired = true)]
        public uint BossId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"hp", IsRequired = true)]
        public uint Hp { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34510")]
    public partial class Sc34510 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34512")]
    public partial class Sc34512 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"drops")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo> Drops { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34514")]
    public partial class Sc34514 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34516")]
    public partial class Sc34516 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34518")]
    public partial class Sc34518 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"list")]
        public global::System.Collections.Generic.List<WorldbossSimple> Lists { get; set; } = new global::System.Collections.Generic.List<WorldbossSimple>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34520")]
    public partial class Sc34520 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"ship_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Shipinfo> ShipLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Shipinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34522")]
    public partial class Sc34522 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"boss")]
        public global::BLHX.Server.Common.Proto.p33.WorldbossInfo Boss { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34524")]
    public partial class Sc34524 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"auto_fight_finish_time", IsRequired = true)]
        public uint AutoFightFinishTime { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34526")]
    public partial class Sc34526 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"count", IsRequired = true)]
        public uint Count { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"damage", IsRequired = true)]
        public uint Damage { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"oil", IsRequired = true)]
        public uint Oil { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_34528")]
    public partial class Sc34528 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"worldboss_info")]
    public partial class WorldbossInfo : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"template_id", IsRequired = true)]
        public uint TemplateId { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"lv", IsRequired = true)]
        public uint Lv { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"hp", IsRequired = true)]
        public uint Hp { get; set; }

        [global::ProtoBuf.ProtoMember(5, Name = @"owner", IsRequired = true)]
        public uint Owner { get; set; }

        [global::ProtoBuf.ProtoMember(6, Name = @"last_time", IsRequired = true)]
        public uint LastTime { get; set; }

        [global::ProtoBuf.ProtoMember(7, Name = @"kill_time", IsRequired = true)]
        public uint KillTime { get; set; }

        [global::ProtoBuf.ProtoMember(8, Name = @"fight_count", IsRequired = true)]
        public uint FightCount { get; set; }

        [global::ProtoBuf.ProtoMember(9, Name = @"rank_count", IsRequired = true)]
        public uint RankCount { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"worldboss_rank")]
    public partial class WorldbossRank : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"damage", IsRequired = true)]
        public uint Damage { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"worldboss_simple")]
    public partial class WorldbossSimple : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"hp", IsRequired = true)]
        public uint Hp { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"rank_count", IsRequired = true)]
        public uint RankCount { get; set; }

    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
