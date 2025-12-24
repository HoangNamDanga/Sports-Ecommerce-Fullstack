using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("REDO_DB")]
[Index("TenantKey", "Dbid", "Thread", "ResetlogsScn", "ResetlogsTime", Name = "REDO_DB_IDX")]
public partial class RedoDb  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("DBID", TypeName = "NUMBER")]
    public decimal Dbid { get; set; }

    [Column("GLOBAL_DBNAME")]
    [StringLength(129)]
    [Unicode(false)]
    public string? GlobalDbname { get; set; }

    [Column("DBUNAME")]
    [StringLength(32)]
    [Unicode(false)]
    public string? Dbuname { get; set; }

    [Column("VERSION")]
    [StringLength(32)]
    [Unicode(false)]
    public string? Version { get; set; }

    [Column("THREAD#", TypeName = "NUMBER")]
    public decimal Thread { get; set; }

    [Column("RESETLOGS_SCN_BAS", TypeName = "NUMBER")]
    public decimal? ResetlogsScnBas { get; set; }

    [Column("RESETLOGS_SCN_WRP", TypeName = "NUMBER")]
    public decimal? ResetlogsScnWrp { get; set; }

    [Column("RESETLOGS_TIME", TypeName = "NUMBER")]
    public decimal ResetlogsTime { get; set; }

    [Column("PRESETLOGS_SCN_BAS", TypeName = "NUMBER")]
    public decimal? PresetlogsScnBas { get; set; }

    [Column("PRESETLOGS_SCN_WRP", TypeName = "NUMBER")]
    public decimal? PresetlogsScnWrp { get; set; }

    [Column("PRESETLOGS_TIME", TypeName = "NUMBER")]
    public decimal PresetlogsTime { get; set; }

    [Column("SEQNO_RCV_CUR", TypeName = "NUMBER")]
    public decimal? SeqnoRcvCur { get; set; }

    [Column("SEQNO_RCV_LO", TypeName = "NUMBER")]
    public decimal? SeqnoRcvLo { get; set; }

    [Column("SEQNO_RCV_HI", TypeName = "NUMBER")]
    public decimal? SeqnoRcvHi { get; set; }

    [Column("SEQNO_DONE_CUR", TypeName = "NUMBER")]
    public decimal? SeqnoDoneCur { get; set; }

    [Column("SEQNO_DONE_LO", TypeName = "NUMBER")]
    public decimal? SeqnoDoneLo { get; set; }

    [Column("SEQNO_DONE_HI", TypeName = "NUMBER")]
    public decimal? SeqnoDoneHi { get; set; }

    [Column("GAP_SEQNO", TypeName = "NUMBER")]
    public decimal? GapSeqno { get; set; }

    [Column("GAP_RET", TypeName = "NUMBER")]
    public decimal? GapRet { get; set; }

    [Column("GAP_DONE", TypeName = "NUMBER")]
    public decimal? GapDone { get; set; }

    [Column("APPLY_SEQNO", TypeName = "NUMBER")]
    public decimal? ApplySeqno { get; set; }

    [Column("APPLY_DONE", TypeName = "NUMBER")]
    public decimal? ApplyDone { get; set; }

    [Column("PURGE_DONE", TypeName = "NUMBER")]
    public decimal? PurgeDone { get; set; }

    [Column("HAS_CHILD", TypeName = "NUMBER")]
    public decimal? HasChild { get; set; }

    [Column("ERROR1", TypeName = "NUMBER")]
    public decimal? Error1 { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal? Status { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime? CreateDate { get; set; }

    [Column("TS1", TypeName = "NUMBER")]
    public decimal? Ts1 { get; set; }

    [Column("TS2", TypeName = "NUMBER")]
    public decimal? Ts2 { get; set; }

    [Column("GAP_NEXT_SCN", TypeName = "NUMBER")]
    public decimal? GapNextScn { get; set; }

    [Column("GAP_NEXT_TIME", TypeName = "NUMBER")]
    public decimal? GapNextTime { get; set; }

    [Column("CURSCN_TIME", TypeName = "NUMBER")]
    public decimal? CurscnTime { get; set; }

    [Column("RESETLOGS_SCN", TypeName = "NUMBER")]
    public decimal ResetlogsScn { get; set; }

    [Column("PRESETLOGS_SCN", TypeName = "NUMBER")]
    public decimal PresetlogsScn { get; set; }

    [Column("GAP_RET2", TypeName = "NUMBER")]
    public decimal? GapRet2 { get; set; }

    [Column("CURLOG", TypeName = "NUMBER")]
    public decimal? Curlog { get; set; }

    [Column("ENDIAN", TypeName = "NUMBER")]
    public decimal? Endian { get; set; }

    [Column("ENQIDX", TypeName = "NUMBER")]
    public decimal? Enqidx { get; set; }

    [Column("SPARE4", TypeName = "NUMBER")]
    public decimal? Spare4 { get; set; }

    [Column("SPARE5", TypeName = "DATE")]
    public DateTime? Spare5 { get; set; }

    [Column("SPARE6")]
    [StringLength(65)]
    [Unicode(false)]
    public string? Spare6 { get; set; }

    [Column("SPARE7")]
    [StringLength(129)]
    [Unicode(false)]
    public string? Spare7 { get; set; }

    [Column("TS3", TypeName = "NUMBER")]
    public decimal? Ts3 { get; set; }

    [Column("CURBLKNO", TypeName = "NUMBER")]
    public decimal? Curblkno { get; set; }

    [Column("SPARE8", TypeName = "NUMBER")]
    public decimal? Spare8 { get; set; }

    [Column("SPARE9", TypeName = "NUMBER")]
    public decimal? Spare9 { get; set; }

    [Column("SPARE10", TypeName = "NUMBER")]
    public decimal? Spare10 { get; set; }

    [Column("SPARE11", TypeName = "NUMBER")]
    public decimal? Spare11 { get; set; }

    [Column("SPARE12", TypeName = "NUMBER")]
    public decimal? Spare12 { get; set; }

    [Column("TENANT_KEY", TypeName = "NUMBER")]
    public decimal TenantKey { get; set; }
}
