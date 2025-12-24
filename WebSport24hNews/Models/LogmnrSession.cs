using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("LOGMNR_SESSION$")]
[Index("SessionName", Name = "LOGMNR_SESSION_UK1", IsUnique = true)]
public partial class LogmnrSession  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal Session { get; set; }

    [Column("CLIENT#", TypeName = "NUMBER")]
    public decimal? Client { get; set; }

    [Column("SESSION_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string SessionName { get; set; } = null!;

    [Column("DB_ID", TypeName = "NUMBER")]
    public decimal? DbId { get; set; }

    [Column("RESETLOGS_CHANGE#", TypeName = "NUMBER")]
    public decimal? ResetlogsChange { get; set; }

    [Column("SESSION_ATTR", TypeName = "NUMBER")]
    public decimal? SessionAttr { get; set; }

    [Column("SESSION_ATTR_VERBOSE")]
    [StringLength(400)]
    [Unicode(false)]
    public string? SessionAttrVerbose { get; set; }

    [Column("START_SCN", TypeName = "NUMBER")]
    public decimal? StartScn { get; set; }

    [Column("END_SCN", TypeName = "NUMBER")]
    public decimal? EndScn { get; set; }

    [Column("SPILL_SCN", TypeName = "NUMBER")]
    public decimal? SpillScn { get; set; }

    [Column("SPILL_TIME", TypeName = "DATE")]
    public DateTime? SpillTime { get; set; }

    [Column("OLDEST_SCN", TypeName = "NUMBER")]
    public decimal? OldestScn { get; set; }

    [Column("RESUME_SCN", TypeName = "NUMBER")]
    public decimal? ResumeScn { get; set; }

    [Column("GLOBAL_DB_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? GlobalDbName { get; set; }

    [Column("RESET_TIMESTAMP", TypeName = "NUMBER")]
    public decimal? ResetTimestamp { get; set; }

    [Column("BRANCH_SCN", TypeName = "NUMBER")]
    public decimal? BranchScn { get; set; }

    [Column("VERSION")]
    [StringLength(64)]
    [Unicode(false)]
    public string? Version { get; set; }

    [Column("REDO_COMPAT")]
    [StringLength(20)]
    [Unicode(false)]
    public string? RedoCompat { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("PURGE_SCN", TypeName = "NUMBER")]
    public decimal? PurgeScn { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SPARE4", TypeName = "NUMBER")]
    public decimal? Spare4 { get; set; }

    [Column("SPARE5", TypeName = "NUMBER")]
    public decimal? Spare5 { get; set; }

    [Column("SPARE6", TypeName = "DATE")]
    public DateTime? Spare6 { get; set; }

    [Column("SPARE7")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? Spare7 { get; set; }

    [Column("SPARE8")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? Spare8 { get; set; }

    [Column("SPARE9", TypeName = "NUMBER")]
    public decimal? Spare9 { get; set; }
}
