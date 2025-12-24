using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Con", "Intcol")]
[Table("LOGMNR_CCOL$")]
[Index("LogmnrUid", "Con", "Intcol", Name = "LOGMNR_I1CCOL$")]
public partial class LogmnrCcol  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("CON#", TypeName = "NUMBER")]
    public decimal? Con { get; set; }

    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal? Obj { get; set; }

    [Column("COL#", TypeName = "NUMBER")]
    public decimal? Col { get; set; }

    [Column("POS#", TypeName = "NUMBER")]
    public decimal? Pos { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal Intcol { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
