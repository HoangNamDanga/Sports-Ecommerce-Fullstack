using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGSTDBY$PARAMETERS")]
public partial class LogstdbyParameter  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("NAME")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("VALUE")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Value { get; set; }

    [Column("TYPE", TypeName = "NUMBER")]
    public decimal? Type { get; set; }

    [Column("SCN", TypeName = "NUMBER")]
    public decimal? Scn { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
