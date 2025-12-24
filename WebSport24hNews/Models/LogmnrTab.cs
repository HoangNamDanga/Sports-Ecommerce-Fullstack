using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj")]
[Table("LOGMNR_TAB$")]
[Index("LogmnrUid", "Obj", Name = "LOGMNR_I1TAB$")]
[Index("LogmnrUid", "Bobj", Name = "LOGMNR_I2TAB$")]
public partial class LogmnrTab  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("TS#", TypeName = "NUMBER(22)")]
    public decimal? Ts { get; set; }

    [Column("COLS", TypeName = "NUMBER(22)")]
    public decimal? Cols { get; set; }

    [Column("PROPERTY", TypeName = "NUMBER")]
    public decimal? Property { get; set; }

    [Column("INTCOLS", TypeName = "NUMBER(22)")]
    public decimal? Intcols { get; set; }

    [Column("KERNELCOLS", TypeName = "NUMBER(22)")]
    public decimal? Kernelcols { get; set; }

    [Column("BOBJ#", TypeName = "NUMBER(22)")]
    public decimal? Bobj { get; set; }

    [Column("TRIGFLAG", TypeName = "NUMBER(22)")]
    public decimal? Trigflag { get; set; }

    [Column("FLAGS", TypeName = "NUMBER(22)")]
    public decimal? Flags { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER(22)")]
    public decimal Obj { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }

    [Column("ACDRFLAGS", TypeName = "NUMBER")]
    public decimal? Acdrflags { get; set; }

    [Column("ACDRTSOBJ#", TypeName = "NUMBER")]
    public decimal? Acdrtsobj { get; set; }

    [Column("ACDRROWTSINTCOL#", TypeName = "NUMBER")]
    public decimal? Acdrrowtsintcol { get; set; }
}
