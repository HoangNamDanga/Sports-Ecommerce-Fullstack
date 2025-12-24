using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Pkgowner", "Pkgname", "Name")]
[Table("LOGMNR_PROFILE_PLSQL_STATS$")]
public partial class LogmnrProfilePlsqlStat  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("PKGOWNER")]
    [StringLength(384)]
    [Unicode(false)]
    public string Pkgowner { get; set; } = null!;

    [Key]
    [Column("PKGNAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Pkgname { get; set; } = null!;

    [Key]
    [Column("NAME", TypeName = "NUMBER")]
    public decimal Name { get; set; }

    [Column("PRAGMAOP", TypeName = "NUMBER")]
    public decimal? Pragmaop { get; set; }

    [Column("OPNUM", TypeName = "NUMBER")]
    public decimal? Opnum { get; set; }

    [Column("TLSBYUNSUPPOPNUM", TypeName = "NUMBER")]
    public decimal? Tlsbyunsuppopnum { get; set; }

    [Column("OGGUNSUPPOPNUM", TypeName = "NUMBER")]
    public decimal? Oggunsuppopnum { get; set; }

    [Column("REDOSIZE", TypeName = "NUMBER")]
    public decimal? Redosize { get; set; }

    [Column("REDORATE", TypeName = "NUMBER")]
    public decimal? Redorate { get; set; }

    [Column("SPARE1")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Spare1 { get; set; }

    [Column("SPARE2")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SPARE4", TypeName = "NUMBER")]
    public decimal? Spare4 { get; set; }

    [Column("SPARE5", TypeName = "NUMBER")]
    public decimal? Spare5 { get; set; }

    [Column("SPARE6", TypeName = "NUMBER")]
    public decimal? Spare6 { get; set; }
}
