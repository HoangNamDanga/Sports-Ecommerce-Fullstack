using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj")]
[Table("LOGMNR_IND$")]
[Index("LogmnrUid", "Obj", Name = "LOGMNR_I1IND$")]
[Index("LogmnrUid", "Bo", Name = "LOGMNR_I2IND$")]
public partial class LogmnrInd  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("BO#", TypeName = "NUMBER(22)")]
    public decimal? Bo { get; set; }

    [Column("COLS", TypeName = "NUMBER(22)")]
    public decimal? Cols { get; set; }

    [Column("TYPE#", TypeName = "NUMBER(22)")]
    public decimal? Type { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("PROPERTY", TypeName = "NUMBER")]
    public decimal? Property { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER(22)")]
    public decimal Obj { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
