using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "AsOfScn")]
[Table("LOGMNRC_GSBA")]
public partial class LogmnrcGsba  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("AS_OF_SCN", TypeName = "NUMBER")]
    public decimal AsOfScn { get; set; }

    [Column("FDO_LENGTH", TypeName = "NUMBER")]
    public decimal? FdoLength { get; set; }

    [Column("FDO_VALUE")]
    [MaxLength(255)]
    public byte[]? FdoValue { get; set; }

    [Column("CHARSETID", TypeName = "NUMBER")]
    public decimal? Charsetid { get; set; }

    [Column("NCHARSETID", TypeName = "NUMBER")]
    public decimal? Ncharsetid { get; set; }

    [Column("DBTIMEZONE_LEN", TypeName = "NUMBER")]
    public decimal? DbtimezoneLen { get; set; }

    [Column("DBTIMEZONE_VALUE")]
    [StringLength(192)]
    [Unicode(false)]
    public string? DbtimezoneValue { get; set; }

    [Column("LOGMNR_SPARE1", TypeName = "NUMBER")]
    public decimal? LogmnrSpare1 { get; set; }

    [Column("LOGMNR_SPARE2", TypeName = "NUMBER")]
    public decimal? LogmnrSpare2 { get; set; }

    [Column("LOGMNR_SPARE3")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? LogmnrSpare3 { get; set; }

    [Column("LOGMNR_SPARE4", TypeName = "DATE")]
    public DateTime? LogmnrSpare4 { get; set; }

    [Column("DB_GLOBAL_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? DbGlobalName { get; set; }
}
