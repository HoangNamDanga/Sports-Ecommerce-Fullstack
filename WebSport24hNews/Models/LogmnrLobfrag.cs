using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Fragobj")]
[Table("LOGMNR_LOBFRAG$")]
[Index("LogmnrUid", "Fragobj", Name = "LOGMNR_I1LOBFRAG$")]
public partial class LogmnrLobfrag  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("FRAGOBJ#", TypeName = "NUMBER")]
    public decimal? Fragobj { get; set; }

    [Column("PARENTOBJ#", TypeName = "NUMBER")]
    public decimal? Parentobj { get; set; }

    [Column("TABFRAGOBJ#", TypeName = "NUMBER")]
    public decimal? Tabfragobj { get; set; }

    [Column("INDFRAGOBJ#", TypeName = "NUMBER")]
    public decimal? Indfragobj { get; set; }

    [Column("FRAG#", TypeName = "NUMBER")]
    public decimal Frag { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
