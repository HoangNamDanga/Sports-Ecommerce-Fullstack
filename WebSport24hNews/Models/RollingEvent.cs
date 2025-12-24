using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("ROLLING$EVENTS")]
public partial class RollingEvent  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("EVENTID", TypeName = "NUMBER")]
    public decimal? Eventid { get; set; }

    [Column("INSTID", TypeName = "NUMBER")]
    public decimal? Instid { get; set; }

    [Column("REVISION", TypeName = "NUMBER")]
    public decimal? Revision { get; set; }

    [Column("EVENT_TIME")]
    [Precision(6)]
    public DateTime? EventTime { get; set; }

    [Column("TYPE")]
    [StringLength(16)]
    [Unicode(false)]
    public string? Type { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal? Status { get; set; }

    [Column("MESSAGE")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Message { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
