using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGSTDBY$HISTORY")]
public partial class LogstdbyHistory  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("STREAM_SEQUENCE#", TypeName = "NUMBER")]
    public decimal? StreamSequence { get; set; }

    [Column("LMNR_SID", TypeName = "NUMBER")]
    public decimal? LmnrSid { get; set; }

    [Column("DBID", TypeName = "NUMBER")]
    public decimal? Dbid { get; set; }

    [Column("FIRST_CHANGE#", TypeName = "NUMBER")]
    public decimal? FirstChange { get; set; }

    [Column("LAST_CHANGE#", TypeName = "NUMBER")]
    public decimal? LastChange { get; set; }

    [Column("SOURCE", TypeName = "NUMBER")]
    public decimal? Source { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal? Status { get; set; }

    [Column("FIRST_TIME", TypeName = "DATE")]
    public DateTime? FirstTime { get; set; }

    [Column("LAST_TIME", TypeName = "DATE")]
    public DateTime? LastTime { get; set; }

    [Column("DGNAME")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Dgname { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
