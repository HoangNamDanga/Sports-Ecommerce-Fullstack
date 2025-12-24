using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Con", "CommitScn")]
[Table("LOGMNRC_CON_GG")]
[Index("LogmnrUid", "Baseobj", "Baseobjv", "CommitScn", Name = "LOGMNRC_I1CONGG")]
[Index("LogmnrUid", "DropScn", Name = "LOGMNRC_I2CONGG")]
public partial class LogmnrcConGg  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("CON#", TypeName = "NUMBER")]
    public decimal Con { get; set; }

    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Key]
    [Column("COMMIT_SCN", TypeName = "NUMBER")]
    public decimal CommitScn { get; set; }

    [Column("DROP_SCN", TypeName = "NUMBER")]
    public decimal? DropScn { get; set; }

    [Column("BASEOBJ#", TypeName = "NUMBER")]
    public decimal Baseobj { get; set; }

    [Column("BASEOBJV#", TypeName = "NUMBER")]
    public decimal Baseobjv { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal Flags { get; set; }

    [Column("INDEXOBJ#", TypeName = "NUMBER")]
    public decimal? Indexobj { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SPARE4")]
    [Unicode(false)]
    public string? Spare4 { get; set; }

    [Column("SPARE5")]
    [Unicode(false)]
    public string? Spare5 { get; set; }

    [Column("SPARE6")]
    [Unicode(false)]
    public string? Spare6 { get; set; }
}
