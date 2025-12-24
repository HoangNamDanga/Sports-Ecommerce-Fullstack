using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Intcol")]
[Table("LOGMNR_COL$")]
[Index("LogmnrUid", "Obj", "Intcol", Name = "LOGMNR_I1COL$")]
[Index("LogmnrUid", "Obj", "Name", Name = "LOGMNR_I2COL$")]
[Index("LogmnrUid", "Obj", "Col", Name = "LOGMNR_I3COL$")]
public partial class LogmnrCol  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("COL#", TypeName = "NUMBER(22)")]
    public decimal? Col { get; set; }

    [Column("SEGCOL#", TypeName = "NUMBER(22)")]
    public decimal? Segcol { get; set; }

    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("TYPE#", TypeName = "NUMBER(22)")]
    public decimal? Type { get; set; }

    [Column("LENGTH", TypeName = "NUMBER(22)")]
    public decimal? Length { get; set; }

    [Column("PRECISION#", TypeName = "NUMBER(22)")]
    public decimal? Precision { get; set; }

    [Column("SCALE", TypeName = "NUMBER(22)")]
    public decimal? Scale { get; set; }

    [Column("NULL$", TypeName = "NUMBER(22)")]
    public decimal? Null { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER(22)")]
    public decimal? Intcol { get; set; }

    [Column("PROPERTY", TypeName = "NUMBER")]
    public decimal? Property { get; set; }

    [Column("CHARSETID", TypeName = "NUMBER(22)")]
    public decimal? Charsetid { get; set; }

    [Column("CHARSETFORM", TypeName = "NUMBER(22)")]
    public decimal? Charsetform { get; set; }

    [Column("SPARE1", TypeName = "NUMBER(22)")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER(22)")]
    public decimal? Spare2 { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER(22)")]
    public decimal Obj { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }

    [Column("COLLID", TypeName = "NUMBER")]
    public decimal? Collid { get; set; }

    [Column("COLLINTCOL#", TypeName = "NUMBER")]
    public decimal? Collintcol { get; set; }

    [Column("ACDRRESCOL#", TypeName = "NUMBER")]
    public decimal? Acdrrescol { get; set; }
}
