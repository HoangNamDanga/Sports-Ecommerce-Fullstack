using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "User", "StartScn")]
[Table("LOGMNRC_USER")]
[Index("LogmnrUid", "Name", "StartScn", Name = "LOGMNRC_I1USER")]
public partial class LogmnrcUser  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("USER#", TypeName = "NUMBER(22)")]
    public decimal User { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Key]
    [Column("START_SCN", TypeName = "NUMBER")]
    public decimal StartScn { get; set; }

    [Column("DROP_SCN", TypeName = "NUMBER")]
    public decimal? DropScn { get; set; }

    [Column("SPARE1_C", TypeName = "NUMBER")]
    public decimal? Spare1C { get; set; }

    [Column("SPARE2_C", TypeName = "NUMBER")]
    public decimal? Spare2C { get; set; }

    [Column("SPARE3_C")]
    [Unicode(false)]
    public string? Spare3C { get; set; }
}
