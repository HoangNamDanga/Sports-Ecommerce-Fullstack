using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Con", "CommitScn", "Intcol")]
[Table("LOGMNRC_CONCOL_GG")]
public partial class LogmnrcConcolGg  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("CON#", TypeName = "NUMBER")]
    public decimal Con { get; set; }

    [Key]
    [Column("COMMIT_SCN", TypeName = "NUMBER")]
    public decimal CommitScn { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal Intcol { get; set; }

    [Column("POS#", TypeName = "NUMBER")]
    public decimal? Pos { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
