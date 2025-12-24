using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("BOM_DETAILS")]
public partial class BomDetail  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("ORG_ID", TypeName = "NUMBER")]
    public decimal OrgId { get; set; }

    [Column("BOM_ID", TypeName = "NUMBER")]
    public decimal BomId { get; set; }

    [Column("PRODUCT_CODE")]
    [StringLength(20)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    [Column("ITEM_ID", TypeName = "NUMBER")]
    public decimal ItemId { get; set; }

    [Column("ITEM_CODE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ItemCode { get; set; }

    [Column("ITEM_NAME")]
    [StringLength(200)]
    [Unicode(false)]
    public string? ItemName { get; set; }

    [Column("ALT_ITEM_ID", TypeName = "NUMBER")]
    public decimal? AltItemId { get; set; }

    [Column("BOM_QUANTITY", TypeName = "NUMBER")]
    public decimal? BomQuantity { get; set; }

    [Column("PRICE", TypeName = "NUMBER")]
    public decimal? Price { get; set; }

    [Column("AMOUNT", TypeName = "NUMBER")]
    public decimal? Amount { get; set; }

    [Column("IS_PRIARY", TypeName = "NUMBER(1)")]
    public bool? IsPriary { get; set; }

    [Column("LOSS_RATO", TypeName = "NUMBER")]
    public decimal? LossRato { get; set; }

    [Column("NOTE")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Note { get; set; }

    [Column("ROUTING_ID", TypeName = "NUMBER")]
    public decimal? RoutingId { get; set; }

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
