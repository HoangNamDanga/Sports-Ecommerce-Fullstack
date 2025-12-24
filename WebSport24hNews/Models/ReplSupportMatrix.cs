using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Bmap1", "Bmap2", "ReplProduct", "SupportMode")]
[Table("REPL_SUPPORT_MATRIX")]
public partial class ReplSupportMatrix  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("FEATURE_NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string? FeatureName { get; set; }

    [Column("REASON_CODE", TypeName = "NUMBER")]
    public decimal? ReasonCode { get; set; }

    [Key]
    [Column("BMAP1", TypeName = "NUMBER")]
    public decimal Bmap1 { get; set; }

    [Key]
    [Column("BMAP2", TypeName = "NUMBER")]
    public decimal Bmap2 { get; set; }

    [Key]
    [Column("REPL_PRODUCT", TypeName = "NUMBER")]
    public decimal ReplProduct { get; set; }

    [Key]
    [Column("SUPPORT_MODE", TypeName = "NUMBER")]
    public decimal SupportMode { get; set; }

    [Column("MIN_COMPAT", TypeName = "NUMBER")]
    public decimal? MinCompat { get; set; }

    [Column("MAX_COMPAT", TypeName = "NUMBER")]
    public decimal? MaxCompat { get; set; }
}
