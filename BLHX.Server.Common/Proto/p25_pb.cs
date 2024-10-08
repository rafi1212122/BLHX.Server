// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: p25_pb.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace BLHX.Server.Common.Proto.p25
{

    [global::ProtoBuf.ProtoContract(Name = @"commanderboxinfo")]
    public partial class Commanderboxinfo : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, IsRequired = true)]
        public uint poolId { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"finish_time", IsRequired = true)]
        public uint FinishTime { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"begin_time", IsRequired = true)]
        public uint BeginTime { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"commanderhomeslot")]
    public partial class Commanderhomeslot : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"op_flag", IsRequired = true)]
        public uint OpFlag { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"exp_time", IsRequired = true)]
        public uint ExpTime { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"commander_id", IsRequired = true)]
        public uint CommanderId { get; set; }

        [global::ProtoBuf.ProtoMember(5, Name = @"style", IsRequired = true)]
        public uint Style { get; set; }

        [global::ProtoBuf.ProtoMember(6, Name = @"commander_level")]
        public uint CommanderLevel
        {
            get => __pbn__CommanderLevel.GetValueOrDefault();
            set => __pbn__CommanderLevel = value;
        }
        public bool ShouldSerializeCommanderLevel() => __pbn__CommanderLevel != null;
        public void ResetCommanderLevel() => __pbn__CommanderLevel = null;
        private uint? __pbn__CommanderLevel;

        [global::ProtoBuf.ProtoMember(7, Name = @"commander_exp")]
        public uint CommanderExp
        {
            get => __pbn__CommanderExp.GetValueOrDefault();
            set => __pbn__CommanderExp = value;
        }
        public bool ShouldSerializeCommanderExp() => __pbn__CommanderExp != null;
        public void ResetCommanderExp() => __pbn__CommanderExp = null;
        private uint? __pbn__CommanderExp;

        [global::ProtoBuf.ProtoMember(8, Name = @"cache_exp", IsRequired = true)]
        public uint CacheExp { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25002")]
    public partial class Cs25002 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boxid", IsRequired = true)]
        public uint Boxid { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25004")]
    public partial class Cs25004 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"boxid", IsRequired = true)]
        public uint Boxid { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25006")]
    public partial class Cs25006 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"groupid", IsRequired = true)]
        public uint Groupid { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"pos", IsRequired = true)]
        public uint Pos { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"commanderid", IsRequired = true)]
        public uint Commanderid { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25008")]
    public partial class Cs25008 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"targetid", IsRequired = true)]
        public uint Targetid { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"materialid")]
        public global::System.Collections.Generic.List<uint> Materialids { get; set; } = new global::System.Collections.Generic.List<uint>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25010")]
    public partial class Cs25010 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"commanderid", IsRequired = true)]
        public uint Commanderid { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25012")]
    public partial class Cs25012 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"commanderid", IsRequired = true)]
        public uint Commanderid { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"targetid", IsRequired = true)]
        public uint Targetid { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"replaceid", IsRequired = true)]
        public uint Replaceid { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25014")]
    public partial class Cs25014 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"commanderid", IsRequired = true)]
        public uint Commanderid { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25016")]
    public partial class Cs25016 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"commanderid", IsRequired = true)]
        public uint Commanderid { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"flag", IsRequired = true)]
        public uint Flag { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25018")]
    public partial class Cs25018 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25020")]
    public partial class Cs25020 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"commanderid", IsRequired = true)]
        public uint Commanderid { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25022")]
    public partial class Cs25022 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"commandersid")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Commandersinfo> Commandersids { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Commandersinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25024")]
    public partial class Cs25024 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25026")]
    public partial class Cs25026 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25028")]
    public partial class Cs25028 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25030")]
    public partial class Cs25030 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"slotidx", IsRequired = true)]
        public uint Slotidx { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"commander_id", IsRequired = true)]
        public uint CommanderId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25032")]
    public partial class Cs25032 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"slotidx", IsRequired = true)]
        public uint Slotidx { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"styleidx", IsRequired = true)]
        public uint Styleidx { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25034")]
    public partial class Cs25034 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25036")]
    public partial class Cs25036 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"is_open", IsRequired = true)]
        public uint IsOpen { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_25037")]
    public partial class Cs25037 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"item_cnt", IsRequired = true)]
        public uint ItemCnt { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"finish_cnt", IsRequired = true)]
        public uint FinishCnt { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"affect_cnt", IsRequired = true)]
        public uint AffectCnt { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"presetfleet")]
    public partial class Presetfleet : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"commandersid")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Commandersinfo> Commandersids { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Commandersinfo>();

        [global::ProtoBuf.ProtoMember(3, Name = @"name", IsRequired = true)]
        public string Name { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25001")]
    public partial class Sc25001 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"commanders")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Commanderinfo> Commanders { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Commanderinfo>();

        [global::ProtoBuf.ProtoMember(2, Name = @"box")]
        public global::System.Collections.Generic.List<Commanderboxinfo> Boxs { get; set; } = new global::System.Collections.Generic.List<Commanderboxinfo>();

        [global::ProtoBuf.ProtoMember(3, Name = @"usage_count", IsRequired = true)]
        public uint UsageCount { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"presets")]
        public global::System.Collections.Generic.List<Presetfleet> Presets { get; set; } = new global::System.Collections.Generic.List<Presetfleet>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25003")]
    public partial class Sc25003 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"box", IsRequired = true)]
        public Commanderboxinfo Box { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25005")]
    public partial class Sc25005 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"commander", IsRequired = true)]
        public global::BLHX.Server.Common.Proto.common.Commanderinfo Commander { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"finish_time", IsRequired = true)]
        public uint FinishTime { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25007")]
    public partial class Sc25007 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25009")]
    public partial class Sc25009 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25011")]
    public partial class Sc25011 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"abilityid")]
        public global::System.Collections.Generic.List<uint> Abilityids { get; set; } = new global::System.Collections.Generic.List<uint>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25013")]
    public partial class Sc25013 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25015")]
    public partial class Sc25015 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25017")]
    public partial class Sc25017 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25019")]
    public partial class Sc25019 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"awards")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo> Awards { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25021")]
    public partial class Sc25021 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25023")]
    public partial class Sc25023 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25025")]
    public partial class Sc25025 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25027")]
    public partial class Sc25027 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"level", IsRequired = true)]
        public uint Level { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"exp", IsRequired = true)]
        public uint Exp { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"slots")]
        public global::System.Collections.Generic.List<Commanderhomeslot> Slots { get; set; } = new global::System.Collections.Generic.List<Commanderhomeslot>();

        [global::ProtoBuf.ProtoMember(4, Name = @"clean", IsRequired = true)]
        public uint Clean { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25029")]
    public partial class Sc25029 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"level", IsRequired = true)]
        public uint Level { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"exp", IsRequired = true)]
        public uint Exp { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"awards")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo> Awards { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo>();

        [global::ProtoBuf.ProtoMember(5, Name = @"op_time", IsRequired = true)]
        public uint OpTime { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25031")]
    public partial class Sc25031 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"time", IsRequired = true)]
        public uint Time { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"commander_level", IsRequired = true)]
        public uint CommanderLevel { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"commander_exp", IsRequired = true)]
        public uint CommanderExp { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25033")]
    public partial class Sc25033 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25035")]
    public partial class Sc25035 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"box_list")]
        public global::System.Collections.Generic.List<Commanderboxinfo> BoxLists { get; set; } = new global::System.Collections.Generic.List<Commanderboxinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25038")]
    public partial class Sc25038 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_25039")]
    public partial class Sc25039 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"commander_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Commanderinfo> CommanderLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Commanderinfo>();

    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
