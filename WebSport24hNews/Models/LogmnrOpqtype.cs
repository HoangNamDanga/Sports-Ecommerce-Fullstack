using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Intcol")]
[Table("LOGMNR_OPQTYPE$")]
[Index("LogmnrUid", "Obj", "Intcol", Name = "LOGMNR_I1OPQTYPE$")]
public partial class LogmnrOpqtype  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal Intcol { get; set; }

    [Column("TYPE", TypeName = "NUMBER")]
    public decimal? Type { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("LOBCOL", TypeName = "NUMBER")]
    public decimal? Lobcol { get; set; }

    [Column("OBJCOL", TypeName = "NUMBER")]
    public decimal? Objcol { get; set; }

    [Column("EXTRACOL", TypeName = "NUMBER")]
    public decimal? Extracol { get; set; }

    [Column("SCHEMAOID")]
    public Guid? Schemaoid { get; set; }

    [Column("ELEMNUM", TypeName = "NUMBER")]
    public decimal? Elemnum { get; set; }

    [Column("SCHEMAURL")]
    [Unicode(false)]
    public string? Schemaurl { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
