using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Intcol")]
[Table("LOGMNR_REFCON$")]
[Index("LogmnrUid", "Obj", "Intcol", Name = "LOGMNR_I1REFCON$")]
public partial class LogmnrRefcon  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("COL#", TypeName = "NUMBER")]
    public decimal? Col { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal? Intcol { get; set; }

    [Column("REFTYP", TypeName = "NUMBER")]
    public decimal? Reftyp { get; set; }

    [Column("STABID")]
    public Guid? Stabid { get; set; }

    [Column("EXPCTOID")]
    public Guid? Expctoid { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
