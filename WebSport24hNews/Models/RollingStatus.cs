using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("ROLLING$STATUS")]
public partial class RollingStatus  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("REVISION", TypeName = "NUMBER")]
    public decimal? Revision { get; set; }

    [Column("PHASE", TypeName = "NUMBER")]
    public decimal? Phase { get; set; }

    [Column("BATCHID", TypeName = "NUMBER")]
    public decimal? Batchid { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal? Status { get; set; }

    [Column("COORDID", TypeName = "NUMBER")]
    public decimal? Coordid { get; set; }

    [Column("OPRIMARY", TypeName = "NUMBER")]
    public decimal? Oprimary { get; set; }

    [Column("FPRIMARY", TypeName = "NUMBER")]
    public decimal? Fprimary { get; set; }

    [Column("PID", TypeName = "NUMBER")]
    public decimal? Pid { get; set; }

    [Column("INSTANCE", TypeName = "NUMBER")]
    public decimal? Instance { get; set; }

    [Column("DBTOTAL", TypeName = "NUMBER")]
    public decimal? Dbtotal { get; set; }

    [Column("DBACTIVE", TypeName = "NUMBER")]
    public decimal? Dbactive { get; set; }

    [Column("LOCATION")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Location { get; set; }

    [Column("INIT_TIME")]
    [Precision(6)]
    public DateTime? InitTime { get; set; }

    [Column("BUILD_TIME")]
    [Precision(6)]
    public DateTime? BuildTime { get; set; }

    [Column("START_TIME")]
    [Precision(6)]
    public DateTime? StartTime { get; set; }

    [Column("SWITCH_TIME")]
    [Precision(6)]
    public DateTime? SwitchTime { get; set; }

    [Column("FINISH_TIME")]
    [Precision(6)]
    public DateTime? FinishTime { get; set; }

    [Column("LAST_INSTID", TypeName = "NUMBER")]
    public decimal? LastInstid { get; set; }

    [Column("LAST_BATCHID", TypeName = "NUMBER")]
    public decimal? LastBatchid { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
