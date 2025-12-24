using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGSTDBY$SCN")]
public partial class LogstdbyScn  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal? Obj { get; set; }

    [Column("OBJNAME")]
    [Unicode(false)]
    public string? Objname { get; set; }

    [Column("SCHEMA")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Schema { get; set; }

    [Column("TYPE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Type { get; set; }

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
