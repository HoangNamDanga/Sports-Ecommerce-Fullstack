using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Bo")]
[Table("LOGMNR_INDPART$")]
[Index("LogmnrUid", "Obj", "Bo", Name = "LOGMNR_I1INDPART$")]
[Index("LogmnrUid", "Bo", Name = "LOGMNR_I2INDPART$")]
public partial class LogmnrIndpart  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal? Obj { get; set; }

    [Key]
    [Column("BO#", TypeName = "NUMBER")]
    public decimal? Bo { get; set; }

    [Column("PART#", TypeName = "NUMBER")]
    public decimal? Part { get; set; }

    [Column("TS#", TypeName = "NUMBER")]
    public decimal Ts { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
