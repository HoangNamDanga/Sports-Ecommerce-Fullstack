using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Pobj")]
[Table("LOGMNR_TABSUBPART$")]
[Index("LogmnrUid", "Obj", "Pobj", Name = "LOGMNR_I1TABSUBPART$")]
[Index("LogmnrUid", "Pobj", Name = "LOGMNR_I2TABSUBPART$")]
public partial class LogmnrTabsubpart  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OBJ#", TypeName = "NUMBER(22)")]
    public decimal? Obj { get; set; }

    [Column("DATAOBJ#", TypeName = "NUMBER(22)")]
    public decimal? Dataobj { get; set; }

    [Key]
    [Column("POBJ#", TypeName = "NUMBER(22)")]
    public decimal? Pobj { get; set; }

    [Column("SUBPART#", TypeName = "NUMBER(22)")]
    public decimal? Subpart { get; set; }

    [Column("TS#", TypeName = "NUMBER(22)")]
    public decimal Ts { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
