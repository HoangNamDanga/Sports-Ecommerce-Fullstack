using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("DHN_COMPESATION_PROMOTION_DETAIL")]
public partial class DhnCompesationPromotionDetail  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID")]
    [Precision(15)]
    public long Id { get; set; }

    [Column("COMPESATION_PROMOTION_ID")]
    [Precision(15)]
    public long? CompesationPromotionId { get; set; }

    [Column("CODE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Code { get; set; }

    [Column("ITEM_ID")]
    [Precision(15)]
    public long? ItemId { get; set; }

    [Column("QUANTITY")]
    [Precision(15)]
    public long? Quantity { get; set; }

    [Column("UNIT_PRICE", TypeName = "NUMBER")]
    public decimal? UnitPrice { get; set; }

    [Column("TOTAL", TypeName = "NUMBER")]
    public decimal? Total { get; set; }

    [Column("UOM")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Uom { get; set; }

    [Column("ATTRIBUTE2")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Attribute2 { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
