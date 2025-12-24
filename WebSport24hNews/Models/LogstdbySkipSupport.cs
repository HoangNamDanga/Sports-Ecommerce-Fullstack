using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGSTDBY$SKIP_SUPPORT")]
[Index("Name", "Action", Name = "LOGSTDBY$SKIP_IND")]
public partial class LogstdbySkipSupport  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("ACTION", TypeName = "NUMBER")]
    public decimal Action { get; set; }

    [Column("NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("NAME2")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Name2 { get; set; }

    [Column("NAME3")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Name3 { get; set; }

    [Column("NAME4")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Name4 { get; set; }

    [Column("NAME5")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Name5 { get; set; }

    [Column("REG", TypeName = "NUMBER(38)")]
    public decimal? Reg { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
