using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "User")]
[Table("LOGMNR_USER$")]
[Index("LogmnrUid", "User", Name = "LOGMNR_I1USER$")]
[Index("LogmnrUid", "Name", Name = "LOGMNR_I2USER$")]
public partial class LogmnrUser  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("USER#", TypeName = "NUMBER(22)")]
    public decimal? User { get; set; }

    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }
}
