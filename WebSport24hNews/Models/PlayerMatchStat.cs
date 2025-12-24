using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("PLAYER_MATCH_STATS")]
public partial class PlayerMatchStat  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("PLAYER_ID", TypeName = "NUMBER")]
    public decimal PlayerId { get; set; }

    [Column("MATCH_ID", TypeName = "NUMBER")]
    public decimal MatchId { get; set; }

    [Column("GOALS")]
    [Precision(2)]
    public byte? Goals { get; set; }

    [Column("ASSISTS")]
    [Precision(2)]
    public byte? Assists { get; set; }

    [Column("MINUTES_PLAYED")]
    [Precision(3)]
    public byte? MinutesPlayed { get; set; }

    [Column("YELLOW_CARDS", TypeName = "NUMBER(1)")]
    public bool? YellowCards { get; set; }

    [Column("RED_CARDS", TypeName = "NUMBER(1)")]
    public bool? RedCards { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
