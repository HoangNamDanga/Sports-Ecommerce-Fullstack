using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Intcol")]
[Table("LOGMNR_NTAB$")]
[Index("LogmnrUid", "Obj", "Intcol", Name = "LOGMNR_I1NTAB$")]
[Index("LogmnrUid", "Ntab", Name = "LOGMNR_I2NTAB$")]
public partial class LogmnrNtab  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("COL#", TypeName = "NUMBER")]
    public decimal? Col { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal? Intcol { get; set; }

    [Column("NTAB#", TypeName = "NUMBER")]
    public decimal? Ntab { get; set; }

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
