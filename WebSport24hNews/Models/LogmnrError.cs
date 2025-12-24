using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGMNR_ERROR$")]
public partial class LogmnrError  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal? Session { get; set; }

    [Column("TIME_OF_ERROR", TypeName = "DATE")]
    public DateTime? TimeOfError { get; set; }

    [Column("CODE", TypeName = "NUMBER")]
    public decimal? Code { get; set; }

    [Column("MESSAGE")]
    [Unicode(false)]
    public string? Message { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SPARE4")]
    [Unicode(false)]
    public string? Spare4 { get; set; }

    [Column("SPARE5")]
    [Unicode(false)]
    public string? Spare5 { get; set; }
}
