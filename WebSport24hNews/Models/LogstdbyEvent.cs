using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGSTDBY$EVENTS")]
[Index("EventTime", Name = "LOGSTDBY$EVENTS_IND")]
[Index("CommitScn", Name = "LOGSTDBY$EVENTS_IND_SCN")]
[Index("Xidusn", "Xidslt", "Xidsqn", Name = "LOGSTDBY$EVENTS_IND_XID")]
public partial class LogstdbyEvent  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("EVENT_TIME")]
    [Precision(6)]
    public DateTime EventTime { get; set; }

    [Column("CURRENT_SCN", TypeName = "NUMBER")]
    public decimal? CurrentScn { get; set; }

    [Column("COMMIT_SCN", TypeName = "NUMBER")]
    public decimal? CommitScn { get; set; }

    [Column("XIDUSN", TypeName = "NUMBER")]
    public decimal? Xidusn { get; set; }

    [Column("XIDSLT", TypeName = "NUMBER")]
    public decimal? Xidslt { get; set; }

    [Column("XIDSQN", TypeName = "NUMBER")]
    public decimal? Xidsqn { get; set; }

    [Column("ERRVAL", TypeName = "NUMBER")]
    public decimal? Errval { get; set; }

    [Column("EVENT")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Event { get; set; }

    [Column("FULL_EVENT", TypeName = "CLOB")]
    public string? FullEvent { get; set; }

    [Column("ERROR")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Error { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare3 { get; set; }

    [Column("CON_NAME")]
    [StringLength(30)]
    [Unicode(false)]
    public string? ConName { get; set; }

    [Column("CON_ID", TypeName = "NUMBER")]
    public decimal? ConId { get; set; }
}
