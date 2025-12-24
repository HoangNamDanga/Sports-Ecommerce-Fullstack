using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("FA_BOOKS")]
public partial class FaBooks  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ASSET_ID", TypeName = "NUMBER")]
    public decimal AssetId { get; set; }

    [Column("ASSET_NUMBER")]
    [StringLength(15)]
    [Unicode(false)]
    public string AssetNumber { get; set; } = null!;

    [Column("ASSET_NAME")]
    [StringLength(200)]
    [Unicode(false)]
    public string? AssetName { get; set; }

    [Column("UOM")]
    [Precision(15)]
    public long? Uom { get; set; }

    [Column("ASSET_KEY_CCID")]
    [Precision(15)]
    public long? AssetKeyCcid { get; set; }

    [Column("FA_BOOKS_ID")]
    [Precision(15)]
    public long FaBooksId { get; set; }

    [Column("CURRENT_UNITS")]
    [StringLength(15)]
    [Unicode(false)]
    public string CurrentUnits { get; set; } = null!;

    [Column("ASSET_TYPE")]
    [StringLength(15)]
    [Unicode(false)]
    public string AssetType { get; set; } = null!;

    [Column("ASSET_CATEGORY_ID")]
    [StringLength(15)]
    [Unicode(false)]
    public string AssetCategoryId { get; set; } = null!;

    [Column("IN_USE_FLAG")]
    [StringLength(1)]
    [Unicode(false)]
    public string? InUseFlag { get; set; }

    [Column("INVENTORY_STOCK")]
    [StringLength(1)]
    [Unicode(false)]
    public string? InventoryStock { get; set; }

    [Column("PARENT_ASSET_ID")]
    [Precision(15)]
    public long? ParentAssetId { get; set; }

    [Column("MANUFACTURED_NAME")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ManufacturedName { get; set; }

    [Column("SERIAL_NUMBER")]
    [StringLength(40)]
    [Unicode(false)]
    public string? SerialNumber { get; set; }

    [Column("MODEL")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Model { get; set; }

    [Column("MUNUFACTURE")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Munufacture { get; set; }

    [Column("WARRANTY", TypeName = "NUMBER")]
    public decimal? Warranty { get; set; }

    [Column("OWNER")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Owner { get; set; }

    [Column("LEASE_NUMBER")]
    [StringLength(20)]
    [Unicode(false)]
    public string? LeaseNumber { get; set; }

    [Column("LEASE_VENDOR")]
    [StringLength(200)]
    [Unicode(false)]
    public string? LeaseVendor { get; set; }

    [Column("ACTIVE", TypeName = "NUMBER(1)")]
    public bool? Active { get; set; }

    [Column("ATTRIBUTE1")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute1 { get; set; }

    [Column("ATTRIBUTE2")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute2 { get; set; }

    [Column("ATTRIBUTE3")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute3 { get; set; }

    [Column("ATTRIBUTE4")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute4 { get; set; }

    [Column("ATTRIBUTE5")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute5 { get; set; }

    [Column("ATTRIBUTE6")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute6 { get; set; }

    [Column("ATTRIBUTE7")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute7 { get; set; }

    [Column("ATTRIBUTE8")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute8 { get; set; }

    [Column("ATTRIBUTE9")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute9 { get; set; }

    [Column("ATTRIBUTE10")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute10 { get; set; }

    [Column("ATTRIBUTE11")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute11 { get; set; }

    [Column("ATTRIBUTE12")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute12 { get; set; }

    [Column("ATTRIBUTE13")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute13 { get; set; }

    [Column("ATTRIBUTE14")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute14 { get; set; }

    [Column("ATTRIBUTE15")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute15 { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
