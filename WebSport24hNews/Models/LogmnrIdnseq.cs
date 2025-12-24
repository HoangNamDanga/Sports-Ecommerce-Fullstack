using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Intcol")]
[Table("LOGMNR_IDNSEQ$")]
[Index("LogmnrUid", "Obj", "Intcol", Name = "LOGMNR_I1IDNSEQ$")]
[Index("LogmnrUid", "Seqobj", Name = "LOGMNR_I2IDNSEQ$")]
public partial class LogmnrIdnseq  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal Intcol { get; set; }

    [Column("SEQOBJ#", TypeName = "NUMBER")]
    public decimal Seqobj { get; set; }

    [Column("STARTWITH", TypeName = "NUMBER")]
    public decimal Startwith { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
