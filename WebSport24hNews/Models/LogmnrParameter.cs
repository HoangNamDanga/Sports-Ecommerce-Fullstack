using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGMNR_PARAMETER$")]
[Index("Session", "Name", Name = "LOGMNR_PARAMETER_INDX")]
public partial class LogmnrParameter  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal Session { get; set; }

    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

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
