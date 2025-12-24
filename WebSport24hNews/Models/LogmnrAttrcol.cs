using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Intcol")]
[Table("LOGMNR_ATTRCOL$")]
[Index("LogmnrUid", "Obj", "Intcol", Name = "LOGMNR_I1ATTRCOL$")]
public partial class LogmnrAttrcol  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal? Intcol { get; set; }

    [Column("NAME")]
    [Unicode(false)]
    public string? Name { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
