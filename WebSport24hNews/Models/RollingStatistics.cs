using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("ROLLING$STATISTICS")]
public partial class RollingStatistics  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("STATID", TypeName = "NUMBER")]
    public decimal? Statid { get; set; }

    [Column("RDBID", TypeName = "NUMBER")]
    public decimal? Rdbid { get; set; }

    [Column("ATTRIBUTES", TypeName = "NUMBER")]
    public decimal? Attributes { get; set; }

    [Column("TYPE", TypeName = "NUMBER")]
    public decimal? Type { get; set; }

    [Column("NAME")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("VALUESTR")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Valuestr { get; set; }

    [Column("VALUENUM", TypeName = "NUMBER")]
    public decimal? Valuenum { get; set; }

    [Column("VALUETS")]
    [Precision(6)]
    public DateTime? Valuets { get; set; }

    [Column("VALUEINT", TypeName = "INTERVAL DAY(3) TO SECOND(2)")]
    public TimeSpan? Valueint { get; set; }

    [Column("UPDATE_TIME")]
    [Precision(6)]
    public DateTime? UpdateTime { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
