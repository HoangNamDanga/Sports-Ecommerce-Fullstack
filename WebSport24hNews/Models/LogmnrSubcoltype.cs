using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Intcol", "Toid")]
[Table("LOGMNR_SUBCOLTYPE$")]
[Index("LogmnrUid", "Obj", "Intcol", "Toid", Name = "LOGMNR_I1SUBCOLTYPE$")]
public partial class LogmnrSubcoltype  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal Intcol { get; set; }

    [Key]
    [Column("TOID")]
    public Guid Toid { get; set; }

    [Column("VERSION#", TypeName = "NUMBER")]
    public decimal Version { get; set; }

    [Column("INTCOLS", TypeName = "NUMBER")]
    public decimal? Intcols { get; set; }

    [Column("INTCOL#S")]
    public byte[]? IntcolS { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("SYNOBJ#", TypeName = "NUMBER")]
    public decimal? Synobj { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
