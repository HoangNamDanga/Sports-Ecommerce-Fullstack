using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Con")]
[Table("LOGMNR_CDEF$")]
[Index("LogmnrUid", "Con", Name = "LOGMNR_I1CDEF$")]
[Index("LogmnrUid", "Robj", Name = "LOGMNR_I2CDEF$")]
[Index("LogmnrUid", "Obj", Name = "LOGMNR_I3CDEF$")]
public partial class LogmnrCdef  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("CON#", TypeName = "NUMBER")]
    public decimal? Con { get; set; }

    [Column("COLS", TypeName = "NUMBER")]
    public decimal? Cols { get; set; }

    [Column("TYPE#", TypeName = "NUMBER")]
    public decimal? Type { get; set; }

    [Column("ROBJ#", TypeName = "NUMBER")]
    public decimal? Robj { get; set; }

    [Column("RCON#", TypeName = "NUMBER")]
    public decimal? Rcon { get; set; }

    [Column("ENABLED", TypeName = "NUMBER")]
    public decimal? Enabled { get; set; }

    [Column("DEFER", TypeName = "NUMBER")]
    public decimal? Defer { get; set; }

    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
