using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGSTDBY$APPLY_MILESTONE")]
public partial class LogstdbyApplyMilestone  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SESSION_ID", TypeName = "NUMBER")]
    public decimal SessionId { get; set; }

    [Column("COMMIT_SCN", TypeName = "NUMBER")]
    public decimal CommitScn { get; set; }

    [Column("COMMIT_TIME", TypeName = "DATE")]
    public DateTime? CommitTime { get; set; }

    [Column("SYNCH_SCN", TypeName = "NUMBER")]
    public decimal SynchScn { get; set; }

    [Column("EPOCH", TypeName = "NUMBER")]
    public decimal Epoch { get; set; }

    [Column("PROCESSED_SCN", TypeName = "NUMBER")]
    public decimal ProcessedScn { get; set; }

    [Column("PROCESSED_TIME", TypeName = "DATE")]
    public DateTime? ProcessedTime { get; set; }

    [Column("FETCHLWM_SCN", TypeName = "NUMBER")]
    public decimal FetchlwmScn { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare3 { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("LWM_UPD_TIME", TypeName = "DATE")]
    public DateTime? LwmUpdTime { get; set; }

    [Column("SPARE4", TypeName = "NUMBER")]
    public decimal? Spare4 { get; set; }

    [Column("SPARE5", TypeName = "NUMBER")]
    public decimal? Spare5 { get; set; }

    [Column("SPARE6", TypeName = "NUMBER")]
    public decimal? Spare6 { get; set; }

    [Column("SPARE7", TypeName = "DATE")]
    public DateTime? Spare7 { get; set; }

    [Column("PTO_RECOVERY_SCN", TypeName = "NUMBER")]
    public decimal? PtoRecoveryScn { get; set; }

    [Column("PTO_RECOVERY_INCARNATION", TypeName = "NUMBER")]
    public decimal? PtoRecoveryIncarnation { get; set; }
}
