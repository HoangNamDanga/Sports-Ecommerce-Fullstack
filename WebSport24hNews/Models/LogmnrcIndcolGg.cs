using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "CommitScn", "Intcol")]
[Table("LOGMNRC_INDCOL_GG")]
public partial class LogmnrcIndcolGg  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("COMMIT_SCN", TypeName = "NUMBER")]
    public decimal CommitScn { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal Intcol { get; set; }

    [Column("POS#", TypeName = "NUMBER")]
    public decimal Pos { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
