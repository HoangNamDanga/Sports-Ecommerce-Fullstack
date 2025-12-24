using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Oid", "Destination")]
[Table("AQ$_SCHEDULES")]
[Index("Jobno", Name = "AQ$_SCHEDULES_CHECK", IsUnique = true)]
public partial class AqSchedule  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OID")]
    public Guid Oid { get; set; }

    [Key]
    [Column("DESTINATION")]
    [StringLength(390)]
    [Unicode(false)]
    public string Destination { get; set; } = null!;

    [Column("START_TIME", TypeName = "DATE")]
    public DateTime? StartTime { get; set; }

    [Column("DURATION")]
    [StringLength(8)]
    [Unicode(false)]
    public string? Duration { get; set; }

    [Column("NEXT_TIME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? NextTime { get; set; }

    [Column("LATENCY")]
    [StringLength(8)]
    [Unicode(false)]
    public string? Latency { get; set; }

    [Column("LAST_TIME", TypeName = "DATE")]
    public DateTime? LastTime { get; set; }

    [Column("JOBNO", TypeName = "NUMBER")]
    public decimal? Jobno { get; set; }
}
