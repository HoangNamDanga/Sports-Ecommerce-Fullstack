using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Session", "Thread", "Sequence", "FirstChange", "DbId", "ResetlogsChange", "ResetTimestamp")]
[Table("LOGMNR_LOG$")]
[Index("FirstChange", Name = "LOGMNR_LOG$_FIRST_CHANGE#")]
[Index("Flags", Name = "LOGMNR_LOG$_FLAGS")]
[Index("FileName", "Status", Name = "LOGMNR_LOG$_PURGE_IDX1")]
[Index("Session", "ResetTimestamp", "NextChange", "Status", Name = "LOGMNR_LOG$_PURGE_IDX2")]
[Index("Recid", Name = "LOGMNR_LOG$_RECID")]
public partial class LogmnrLog  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal Session { get; set; }

    [Key]
    [Column("THREAD#", TypeName = "NUMBER")]
    public decimal Thread { get; set; }

    [Key]
    [Column("SEQUENCE#", TypeName = "NUMBER")]
    public decimal Sequence { get; set; }

    [Key]
    [Column("FIRST_CHANGE#", TypeName = "NUMBER")]
    public decimal FirstChange { get; set; }

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

    [Column("DICT_BEGIN")]
    [StringLength(3)]
    [Unicode(false)]
    public string? DictBegin { get; set; }

    [Column("DICT_END")]
    [StringLength(3)]
    [Unicode(false)]
    public string? DictEnd { get; set; }

    [Column("STATUS_INFO")]
    [StringLength(32)]
    [Unicode(false)]
    public string? StatusInfo { get; set; }

    [Key]
    [Column("DB_ID", TypeName = "NUMBER")]
    public decimal DbId { get; set; }

    [Key]
    [Column("RESETLOGS_CHANGE#", TypeName = "NUMBER")]
    public decimal ResetlogsChange { get; set; }

    [Key]
    [Column("RESET_TIMESTAMP", TypeName = "NUMBER")]
    public decimal ResetTimestamp { get; set; }

    [Column("PREV_RESETLOGS_CHANGE#", TypeName = "NUMBER")]
    public decimal? PrevResetlogsChange { get; set; }

    [Column("PREV_RESET_TIMESTAMP", TypeName = "NUMBER")]
    public decimal? PrevResetTimestamp { get; set; }

    [Column("BLOCKS", TypeName = "NUMBER")]
    public decimal? Blocks { get; set; }

    [Column("BLOCK_SIZE", TypeName = "NUMBER")]
    public decimal? BlockSize { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("CONTENTS", TypeName = "NUMBER")]
    public decimal? Contents { get; set; }

    [Column("RECID", TypeName = "NUMBER")]
    public decimal? Recid { get; set; }

    [Column("RECSTAMP", TypeName = "NUMBER")]
    public decimal? Recstamp { get; set; }

    [Column("MARK_DELETE_TIMESTAMP", TypeName = "NUMBER")]
    public decimal? MarkDeleteTimestamp { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SPARE4", TypeName = "NUMBER")]
    public decimal? Spare4 { get; set; }

    [Column("SPARE5", TypeName = "NUMBER")]
    public decimal? Spare5 { get; set; }
}
