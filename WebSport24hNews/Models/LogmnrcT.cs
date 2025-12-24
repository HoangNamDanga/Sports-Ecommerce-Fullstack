using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Ts", "StartScn")]
[Table("LOGMNRC_TS")]
[Index("LogmnrUid", "DropScn", Name = "LOGMNRC_I1TS")]
public partial class LogmnrcT  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("TS#", TypeName = "NUMBER(22)")]
    public decimal Ts { get; set; }

    [Column("NAME")]
    [StringLength(90)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Key]
    [Column("START_SCN", TypeName = "NUMBER")]
    public decimal StartScn { get; set; }

    [Column("DROP_SCN", TypeName = "NUMBER")]
    public decimal? DropScn { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
