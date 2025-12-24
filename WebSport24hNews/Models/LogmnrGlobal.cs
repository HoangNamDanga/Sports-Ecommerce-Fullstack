using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGMNR_GLOBAL$")]
public partial class LogmnrGlobal  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("HIGH_RECID_FOREIGN", TypeName = "NUMBER")]
    public decimal? HighRecidForeign { get; set; }

    [Column("HIGH_RECID_DELETED", TypeName = "NUMBER")]
    public decimal? HighRecidDeleted { get; set; }

    [Column("LOCAL_RESET_SCN", TypeName = "NUMBER")]
    public decimal? LocalResetScn { get; set; }

    [Column("LOCAL_RESET_TIMESTAMP", TypeName = "NUMBER")]
    public decimal? LocalResetTimestamp { get; set; }

    [Column("VERSION_TIMESTAMP", TypeName = "NUMBER")]
    public decimal? VersionTimestamp { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SPARE4")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare4 { get; set; }

    [Column("SPARE5", TypeName = "DATE")]
    public DateTime? Spare5 { get; set; }

    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal? Session { get; set; }
}
