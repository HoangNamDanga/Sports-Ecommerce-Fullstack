using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGSTDBY$PLSQL")]
public partial class LogstdbyPlsql  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SESSION_ID", TypeName = "NUMBER")]
    public decimal? SessionId { get; set; }

    [Column("START_FINISH", TypeName = "NUMBER")]
    public decimal? StartFinish { get; set; }

    [Column("CALL_TEXT", TypeName = "CLOB")]
    public string? CallText { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
