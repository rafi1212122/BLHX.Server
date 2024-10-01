// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: p28_pb.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
namespace BLHX.Server.Common.Proto.p28
{

    [global::ProtoBuf.ProtoContract(Name = @"apartment_furniture")]
    public partial class ApartmentFurniture : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"furniture_id", IsRequired = true)]
        public uint FurnitureId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"slot_id", IsRequired = true)]
        public uint SlotId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"apartment_gift")]
    public partial class ApartmentGift : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"gift_id", IsRequired = true)]
        public uint GiftId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"number", IsRequired = true)]
        public uint Number { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"used_number", IsRequired = true)]
        public uint UsedNumber { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"apartment_gift_shop")]
    public partial class ApartmentGiftShop : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"gift_id", IsRequired = true)]
        public uint GiftId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"count", IsRequired = true)]
        public uint Count { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"apartment_give_gift")]
    public partial class ApartmentGiveGift : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"gift_id", IsRequired = true)]
        public uint GiftId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"number", IsRequired = true)]
        public uint Number { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"apartment_room")]
    public partial class ApartmentRoom : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"id", IsRequired = true)]
        public uint Id { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"furnitures")]
        public global::System.Collections.Generic.List<ApartmentFurniture> Furnitures { get; set; } = new global::System.Collections.Generic.List<ApartmentFurniture>();

        [global::ProtoBuf.ProtoMember(3, Name = @"collections")]
        public global::System.Collections.Generic.List<uint> Collections { get; set; } = new global::System.Collections.Generic.List<uint>();

        [global::ProtoBuf.ProtoMember(4, Name = @"ships")]
        public global::System.Collections.Generic.List<uint> Ships { get; set; } = new global::System.Collections.Generic.List<uint>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"apartment_ship")]
    public partial class ApartmentShip : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"ship_group", IsRequired = true)]
        public uint ShipGroup { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"favor_lv", IsRequired = true)]
        public uint FavorLv { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"favor_exp", IsRequired = true)]
        public uint FavorExp { get; set; }

        [global::ProtoBuf.ProtoMember(4, Name = @"regular_trigger")]
        public global::System.Collections.Generic.List<uint> RegularTriggers { get; set; } = new global::System.Collections.Generic.List<uint>();

        [global::ProtoBuf.ProtoMember(5, Name = @"daily_favor", IsRequired = true)]
        public uint DailyFavor { get; set; }

        [global::ProtoBuf.ProtoMember(6, Name = @"dialogues")]
        public global::System.Collections.Generic.List<uint> Dialogues { get; set; } = new global::System.Collections.Generic.List<uint>();

        [global::ProtoBuf.ProtoMember(7, Name = @"skins")]
        public global::System.Collections.Generic.List<uint> Skins { get; set; } = new global::System.Collections.Generic.List<uint>();

        [global::ProtoBuf.ProtoMember(8, Name = @"cur_skin", IsRequired = true)]
        public uint CurSkin { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28001")]
    public partial class Cs28001 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"room_id", IsRequired = true)]
        public uint RoomId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28003")]
    public partial class Cs28003 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"ship_group", IsRequired = true)]
        public uint ShipGroup { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"trigger_id", IsRequired = true)]
        public uint TriggerId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28005")]
    public partial class Cs28005 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"ship_group", IsRequired = true)]
        public uint ShipGroup { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28007")]
    public partial class Cs28007 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"room_id", IsRequired = true)]
        public uint RoomId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"furnitures")]
        public global::System.Collections.Generic.List<ApartmentFurniture> Furnitures { get; set; } = new global::System.Collections.Generic.List<ApartmentFurniture>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28009")]
    public partial class Cs28009 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"ship_group", IsRequired = true)]
        public uint ShipGroup { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"gifts")]
        public global::System.Collections.Generic.List<ApartmentGiveGift> Gifts { get; set; } = new global::System.Collections.Generic.List<ApartmentGiveGift>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28011")]
    public partial class Cs28011 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"room_id", IsRequired = true)]
        public uint RoomId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"collection_id", IsRequired = true)]
        public uint CollectionId { get; set; }

        [global::ProtoBuf.ProtoMember(3, Name = @"ship_group", IsRequired = true)]
        public uint ShipGroup { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28013")]
    public partial class Cs28013 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"ship_group", IsRequired = true)]
        public uint ShipGroup { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"skin", IsRequired = true)]
        public uint Skin { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28015")]
    public partial class Cs28015 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"dialog_id", IsRequired = true)]
        public uint DialogId { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28017")]
    public partial class Cs28017 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"type", IsRequired = true)]
        public uint Type { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28019")]
    public partial class Cs28019 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"room_id", IsRequired = true)]
        public uint RoomId { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"ship_group", IsRequired = true)]
        public uint ShipGroup { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"cs_28090")]
    public partial class Cs28090 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"track_typ", IsRequired = true)]
        public uint TrackTyp { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"int_args")]
        public global::System.Collections.Generic.List<int> IntArgs { get; set; } = new global::System.Collections.Generic.List<int>();

        [global::ProtoBuf.ProtoMember(3, Name = @"str_args")]
        public global::System.Collections.Generic.List<string> StrArgs { get; set; } = new global::System.Collections.Generic.List<string>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28000")]
    public partial class Sc28000 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"gifts")]
        public global::System.Collections.Generic.List<ApartmentGift> Gifts { get; set; } = new global::System.Collections.Generic.List<ApartmentGift>();

        [global::ProtoBuf.ProtoMember(2, Name = @"ships")]
        public global::System.Collections.Generic.List<ApartmentShip> Ships { get; set; } = new global::System.Collections.Generic.List<ApartmentShip>();

        [global::ProtoBuf.ProtoMember(3, Name = @"gift_daily")]
        public global::System.Collections.Generic.List<ApartmentGiftShop> GiftDailies { get; set; } = new global::System.Collections.Generic.List<ApartmentGiftShop>();

        [global::ProtoBuf.ProtoMember(4, Name = @"gift_permanent")]
        public global::System.Collections.Generic.List<ApartmentGiftShop> GiftPermanents { get; set; } = new global::System.Collections.Generic.List<ApartmentGiftShop>();

        [global::ProtoBuf.ProtoMember(5, Name = @"furniture_daily")]
        public global::System.Collections.Generic.List<ApartmentGiftShop> FurnitureDailies { get; set; } = new global::System.Collections.Generic.List<ApartmentGiftShop>();

        [global::ProtoBuf.ProtoMember(6, Name = @"furniture_permanent")]
        public global::System.Collections.Generic.List<ApartmentGiftShop> FurniturePermanents { get; set; } = new global::System.Collections.Generic.List<ApartmentGiftShop>();

        [global::ProtoBuf.ProtoMember(7, Name = @"daily_vigor_max", IsRequired = true)]
        public uint DailyVigorMax { get; set; }

        [global::ProtoBuf.ProtoMember(8, Name = @"rooms")]
        public global::System.Collections.Generic.List<ApartmentRoom> Rooms { get; set; } = new global::System.Collections.Generic.List<ApartmentRoom>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28002")]
    public partial class Sc28002 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"room", IsRequired = true)]
        public ApartmentRoom Room { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28004")]
    public partial class Sc28004 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28006")]
    public partial class Sc28006 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"drop_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo> DropLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28008")]
    public partial class Sc28008 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28010")]
    public partial class Sc28010 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28012")]
    public partial class Sc28012 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28014")]
    public partial class Sc28014 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28016")]
    public partial class Sc28016 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

        [global::ProtoBuf.ProtoMember(2, Name = @"drop_list")]
        public global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo> DropLists { get; set; } = new global::System.Collections.Generic.List<global::BLHX.Server.Common.Proto.common.Dropinfo>();

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28018")]
    public partial class Sc28018 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

    [global::ProtoBuf.ProtoContract(Name = @"sc_28020")]
    public partial class Sc28020 : global::ProtoBuf.IExtensible
    {
        private global::ProtoBuf.IExtension __pbn__extensionData;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
            => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

        [global::ProtoBuf.ProtoMember(1, Name = @"result", IsRequired = true)]
        public uint Result { get; set; }

    }

}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, CS8981, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion