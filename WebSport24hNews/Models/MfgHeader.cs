using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("MFG_HEADERS")]
public partial class MfgHeader  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("ORG_ID", TypeName = "NUMBER")]
    public decimal OrgId { get; set; }

    [Column("MFG_CODE", TypeName = "NUMBER")]
    public decimal MfgCode { get; set; }

    [Column("MFG_DATE", TypeName = "DATE")]
    public DateTime MfgDate { get; set; }

    [Column("NOTE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Note { get; set; }

    [Column("STATUS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("PLAN_ID")]
    [StringLength(1)]
    [Unicode(false)]
    public string? PlanId { get; set; }

    [Column("PRODUCT_CODE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ProductCode { get; set; }

    [Column("BOM_CODE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? BomCode { get; set; }

    [Column("REQUESTOR_ID", TypeName = "NUMBER")]
    public decimal? RequestorId { get; set; }

    [Column("QUANTITY", TypeName = "NUMBER")]
    public decimal? Quantity { get; set; }

    [Column("QUANTITY_COMPLETED", TypeName = "NUMBER")]
    public decimal? QuantityCompleted { get; set; }

    [Column("ATTRIBUTE1")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute1 { get; set; }

    [Column("ATTRIBUTE2")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute2 { get; set; }

    [Column("ATTRIBUTE3")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute3 { get; set; }

    [Column("ATTRIBUTE4")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute4 { get; set; }

    [Column("ATTRIBUTE5")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute5 { get; set; }

    [Column("ATTRIBUTE6")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute6 { get; set; }

    [Column("ATTRIBUTE7")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute7 { get; set; }

    [Column("ATTRIBUTE8")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute8 { get; set; }

    [Column("ATTRIBUTE9")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute9 { get; set; }

    [Column("ATTRIBUTE10")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute10 { get; set; }

    [Column("ATTRIBUTE11")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute11 { get; set; }

    [Column("ATTRIBUTE12")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute12 { get; set; }

    [Column("ATTRIBUTE13")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute13 { get; set; }

    [Column("ATTRIBUTE14")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute14 { get; set; }

    [Column("ATTRIBUTE15")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute15 { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal? CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime? CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime? LastUpdateDate { get; set; }

    [Column("SCHEDULE_DATE", TypeName = "DATE")]
    public DateTime? ScheduleDate { get; set; }
}
