using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("ROLLING$PLAN")]
public partial class RollingPlan  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("INSTID", TypeName = "NUMBER")]
    public decimal? Instid { get; set; }

    [Column("BATCHID", TypeName = "NUMBER")]
    public decimal? Batchid { get; set; }

    [Column("DIRECTID", TypeName = "NUMBER")]
    public decimal? Directid { get; set; }

    [Column("TASKID", TypeName = "NUMBER")]
    public decimal? Taskid { get; set; }

    [Column("REVISION", TypeName = "NUMBER")]
    public decimal? Revision { get; set; }

    [Column("PHASE", TypeName = "NUMBER")]
    public decimal? Phase { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal? Status { get; set; }

    [Column("PROGRESS", TypeName = "NUMBER")]
    public decimal? Progress { get; set; }

    [Column("SOURCE", TypeName = "NUMBER")]
    public decimal? Source { get; set; }

    [Column("TARGET", TypeName = "NUMBER")]
    public decimal? Target { get; set; }

    [Column("RFLAGS", TypeName = "NUMBER")]
    public decimal? Rflags { get; set; }

    [Column("OPCODE", TypeName = "NUMBER")]
    public decimal? Opcode { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? P1 { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? P2 { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? P3 { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? P4 { get; set; }

    [Column("DESCRIPTION")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("EXEC_STATUS", TypeName = "NUMBER")]
    public decimal? ExecStatus { get; set; }

    [Column("EXEC_INFO")]
    [StringLength(256)]
    [Unicode(false)]
    public string? ExecInfo { get; set; }

    [Column("EXEC_TIME")]
    [Precision(6)]
    public DateTime? ExecTime { get; set; }

    [Column("FINISH_TIME")]
    [Precision(6)]
    public DateTime? FinishTime { get; set; }

    [Column("POST_STATUS", TypeName = "NUMBER")]
    public decimal? PostStatus { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
