using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Intcol")]
[Table("LOGMNR_ICOL$")]
[Index("LogmnrUid", "Obj", "Intcol", Name = "LOGMNR_I1ICOL$")]
public partial class LogmnrIcol  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal? Obj { get; set; }

    [Column("BO#", TypeName = "NUMBER")]
    public decimal? Bo { get; set; }

    [Column("COL#", TypeName = "NUMBER")]
    public decimal? Col { get; set; }

    [Column("POS#", TypeName = "NUMBER")]
    public decimal? Pos { get; set; }

    [Column("SEGCOL#", TypeName = "NUMBER")]
    public decimal? Segcol { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal Intcol { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
