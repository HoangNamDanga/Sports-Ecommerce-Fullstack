using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "InitialXid")]
[Table("LOGMNR_LOGMNR_BUILDLOG")]
[Index("LogmnrUid", "InitialXid", Name = "LOGMNR_I1LOGMNR_BUILDLOG")]
public partial class LogmnrLogmnrBuildlog  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("BUILD_DATE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? BuildDate { get; set; }

    [Column("DB_TXN_SCNBAS", TypeName = "NUMBER")]
    public decimal? DbTxnScnbas { get; set; }

    [Column("DB_TXN_SCNWRP", TypeName = "NUMBER")]
    public decimal? DbTxnScnwrp { get; set; }

    [Column("CURRENT_BUILD_STATE", TypeName = "NUMBER")]
    public decimal? CurrentBuildState { get; set; }

    [Column("COMPLETION_STATUS", TypeName = "NUMBER")]
    public decimal? CompletionStatus { get; set; }

    [Column("MARKED_LOG_FILE_LOW_SCN", TypeName = "NUMBER")]
    public decimal? MarkedLogFileLowScn { get; set; }

    [Key]
    [Column("INITIAL_XID")]
    [StringLength(22)]
    [Unicode(false)]
    public string InitialXid { get; set; } = null!;

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }

    [Column("CDB_XID")]
    [StringLength(22)]
    [Unicode(false)]
    public string? CdbXid { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2")]
    [Unicode(false)]
    public string? Spare2 { get; set; }
}
