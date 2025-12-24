using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("LOGSTDBY$FLASHBACK_SCN")]
public partial class LogstdbyFlashbackScn  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("PRIMARY_SCN", TypeName = "NUMBER")]
    public decimal PrimaryScn { get; set; }

    [Column("PRIMARY_TIME", TypeName = "DATE")]
    public DateTime? PrimaryTime { get; set; }

    [Column("STANDBY_SCN", TypeName = "NUMBER")]
    public decimal? StandbyScn { get; set; }

    [Column("STANDBY_TIME", TypeName = "DATE")]
    public DateTime? StandbyTime { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "DATE")]
    public DateTime? Spare3 { get; set; }
}
