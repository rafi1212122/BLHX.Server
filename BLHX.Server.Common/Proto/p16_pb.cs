// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: p16_pb.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace BLHX.Server.Common.Proto.p16
{

    [global::ProtoBuf.ProtoContract(Name = @"cs_16001")]
    public partial class Cs16001 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"number", IsRequired = true)]
        public uint Number { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_16100")]
    public partial class Cs16100 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"cnt", IsRequired = true)]
        public uint Cnt { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_16104")]
    public partial class Cs16104 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_16106")]
    public partial class Cs16106 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_16108")]
    public partial class Cs16108 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"flash_time", IsRequired = true)]
        public uint FlashTime { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"shopid", IsRequired = true)]
        public uint Shopid { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"selected")]
        public global::System.Collections.Generic.List<SelectedInfo> Selecteds { get; set; } = new global::System.Collections.Generic.List<SelectedInfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_16201")]
    public partial class Cs16201 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"count", IsRequired = true)]
        public uint Count { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_16203")]
    public partial class Cs16203 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"flag", IsRequired = true)]
        public uint Flag { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_16205")]
    public partial class Cs16205 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"cost_type", IsRequired = true)]
        public uint CostType { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"goods_info")]
    public partial class GoodsInfo : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"count", IsRequired = true)]
        public uint Count { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_16002")]
    public partial class Sc16002 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"drop_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo> DropLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_16101")]
    public partial class Sc16101 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"ship_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Shipinfo> ShipLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Shipinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_16105")]
    public partial class Sc16105 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"first_pay_list")]
        public global::System.Collections.Generic.List<uint> FirstPayLists { get; set; } = new global::System.Collections.Generic.List<uint>();

        [global::ProtoBuf.ProtoMember(2, Name = @"pay_list")]
        public global::System.Collections.Generic.List<Shopinfo> PayLists { get; set; } = new global::System.Collections.Generic.List<Shopinfo>();

        [global::ProtoBuf.ProtoMember(3, Name = @"normal_list")]
        public global::System.Collections.Generic.List<Shopinfo> NormalLists { get; set; } = new global::System.Collections.Generic.List<Shopinfo>();

        [global::ProtoBuf.ProtoMember(4, Name = @"normal_group_list")]
        public global::System.Collections.Generic.List<Shopinfo> NormalGroupLists { get; set; } = new global::System.Collections.Generic.List<Shopinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_16107")]
    public partial class Sc16107 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"item_flash_time", IsRequired = true)]
        public uint ItemFlashTime { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"good_list")]
        public global::System.Collections.Generic.List<GoodsInfo> GoodLists { get; set; } = new global::System.Collections.Generic.List<GoodsInfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_16109")]
    public partial class Sc16109 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"drop_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo> DropLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_16200")]
    public partial class Sc16200 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"core_shop_list")]
        public global::System.Collections.Generic.List<Shopinfo> CoreShopLists { get; set; } = new global::System.Collections.Generic.List<Shopinfo>();

        [global::ProtoBuf.ProtoMember(2, Name = @"blue_shop_list")]
        public global::System.Collections.Generic.List<Shopinfo> BlueShopLists { get; set; } = new global::System.Collections.Generic.List<Shopinfo>();

        [global::ProtoBuf.ProtoMember(3, Name = @"normal_shop_list")]
        public global::System.Collections.Generic.List<Shopinfo> NormalShopLists { get; set; } = new global::System.Collections.Generic.List<Shopinfo>();

        [global::ProtoBuf.ProtoMember(4, Name = @"month", IsRequired = true)]
        public uint Month { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_16202")]
    public partial class Sc16202 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"drop_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo> DropLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_16204")]
    public partial class Sc16204 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"ret", IsRequired = true)]
        public uint Ret { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_16206")]
    public partial class Sc16206 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"ret", IsRequired = true)]
        public uint Ret { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"selected_info")]
    public partial class SelectedInfo : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"count", IsRequired = true)]
        public uint Count { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"shopinfo")]
    public partial class Shopinfo : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"shop_id", IsRequired = true)]
        public uint ShopId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"pay_count", IsRequired = true)]
        public uint PayCount { get; set; }

    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
