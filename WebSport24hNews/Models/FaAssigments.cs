using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("FA_ASSIGMENTS")]
public partial class FaAssigments  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID")]
    [Precision(15)]
    public long Id { get; set; }

    [Column("ASSET_ID", TypeName = "NUMBER")]
    public decimal AssetId { get; set; }

    [Column("EMP_ID")]
    [Precision(15)]
    public long EmpId { get; set; }

    [Column("EMP_CODE")]
    [StringLength(15)]
    [Unicode(false)]
    public string EmpCode { get; set; } = null!;

    [Column("EMP_NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string? EmpName { get; set; }

    [Column("LOCATION_ID")]
    [Precision(15)]
    public long LocationId { get; set; }

    [Column("TOTAL_UNIT", TypeName = "NUMBER")]
    public decimal? TotalUnit { get; set; }

    [Column("UNIT_ASSIGNED", TypeName = "NUMBER")]
    public decimal? UnitAssigned { get; set; }

    [Column("EXP_CCID", TypeName = "NUMBER")]
    public decimal? ExpCcid { get; set; }

    [Column("TRANSFER_DATE", TypeName = "DATE")]
    public DateTime TransferDate { get; set; }

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
