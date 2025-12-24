using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Session", "Thread")]
[Table("LOGMNR_PROCESSED_LOG$")]
public partial class LogmnrProcessedLog  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal Session { get; set; }

    [Key]
    [Column("THREAD#", TypeName = "NUMBER")]
    public decimal Thread { get; set; }

    [Column("SEQUENCE#", TypeName = "NUMBER")]
    public decimal? Sequence { get; set; }

    [Column("FIRST_CHANGE#", TypeName = "NUMBER")]
    public decimal? FirstChange { get; set; }

    [Column("NEXT_CHANGE#", TypeName = "NUMBER")]
    public decimal? NextChange { get; set; }

    [Column("FIRST_TIME", TypeName = "DATE")]
    public DateTime? FirstTime { get; set; }

    [Column("NEXT_TIME", TypeName = "DATE")]
    public DateTime? NextTime { get; set; }

    [Column("FILE_NAME")]
    [StringLength(513)]
    [Unicode(false)]
    public string? FileName { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal? Status { get; set; }

    [Column("INFO")]
    [StringLength(32)]
    [Unicode(false)]
    public string? Info { get; set; }

    [Column("TIMESTAMP", TypeName = "DATE")]
    public DateTime? Timestamp { get; set; }
}
