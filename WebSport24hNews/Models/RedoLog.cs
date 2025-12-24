using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("REDO_LOG")]
[Index("TenantKey", "Dbid", "Thread", "ResetlogsScn", "ResetlogsTime", Name = "REDO_LOG_IDX")]
public partial class RedoLog  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
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

    [Column("SEQUENCE#", TypeName = "NUMBER")]
    public decimal Sequence { get; set; }

    [Column("DUPID", TypeName = "NUMBER")]
    public decimal? Dupid { get; set; }

    [Column("STATUS1", TypeName = "NUMBER")]
    public decimal? Status1 { get; set; }

    [Column("STATUS2", TypeName = "NUMBER")]
    public decimal? Status2 { get; set; }

    [Column("CREATE_TIME")]
    [StringLength(32)]
    [Unicode(false)]
    public string? CreateTime { get; set; }

    [Column("CLOSE_TIME")]
    [StringLength(32)]
    [Unicode(false)]
    public string? CloseTime { get; set; }

    [Column("DONE_TIME")]
    [StringLength(32)]
    [Unicode(false)]
    public string? DoneTime { get; set; }

    [Column("FIRST_SCN_BAS", TypeName = "NUMBER")]
    public decimal? FirstScnBas { get; set; }

    [Column("FIRST_SCN_WRP", TypeName = "NUMBER")]
    public decimal? FirstScnWrp { get; set; }

    [Column("FIRST_TIME", TypeName = "NUMBER")]
    public decimal? FirstTime { get; set; }

    [Column("NEXT_SCN_BAS", TypeName = "NUMBER")]
    public decimal? NextScnBas { get; set; }

    [Column("NEXT_SCN_WRP", TypeName = "NUMBER")]
    public decimal? NextScnWrp { get; set; }

    [Column("NEXT_TIME", TypeName = "NUMBER")]
    public decimal? NextTime { get; set; }

    [Column("FIRST_SCN", TypeName = "NUMBER")]
    public decimal? FirstScn { get; set; }

    [Column("NEXT_SCN", TypeName = "NUMBER")]
    public decimal? NextScn { get; set; }

    [Column("RESETLOGS_SCN", TypeName = "NUMBER")]
    public decimal ResetlogsScn { get; set; }

    [Column("BLOCKS", TypeName = "NUMBER")]
    public decimal? Blocks { get; set; }

    [Column("BLOCK_SIZE", TypeName = "NUMBER")]
    public decimal? BlockSize { get; set; }

    [Column("OLD_BLOCKS", TypeName = "NUMBER")]
    public decimal? OldBlocks { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime? CreateDate { get; set; }

    [Column("ERROR1", TypeName = "NUMBER")]
    public decimal? Error1 { get; set; }

    [Column("ERROR2", TypeName = "NUMBER")]
    public decimal? Error2 { get; set; }

    [Column("FILENAME")]
    [StringLength(513)]
    [Unicode(false)]
    public string? Filename { get; set; }

    [Column("TS1", TypeName = "NUMBER")]
    public decimal? Ts1 { get; set; }

    [Column("TS2", TypeName = "NUMBER")]
    public decimal? Ts2 { get; set; }

    [Column("ENDIAN", TypeName = "NUMBER")]
    public decimal? Endian { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

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

    [Column("PRESETLOGS_SCN", TypeName = "NUMBER")]
    public decimal PresetlogsScn { get; set; }

    [Column("SPARE8", TypeName = "NUMBER")]
    public decimal? Spare8 { get; set; }

    [Column("SPARE9", TypeName = "NUMBER")]
    public decimal? Spare9 { get; set; }

    [Column("SPARE10", TypeName = "NUMBER")]
    public decimal? Spare10 { get; set; }

    [Column("OLD_STATUS1", TypeName = "NUMBER")]
    public decimal? OldStatus1 { get; set; }

    [Column("OLD_STATUS2", TypeName = "NUMBER")]
    public decimal? OldStatus2 { get; set; }

    [Column("OLD_FILENAME")]
    [StringLength(513)]
    [Unicode(false)]
    public string? OldFilename { get; set; }

    [Column("TENANT_KEY", TypeName = "NUMBER")]
    public decimal TenantKey { get; set; }
}
