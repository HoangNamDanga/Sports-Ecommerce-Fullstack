using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("PREMIER_LEAGUE_STANDINGS")]
public partial class PremierLeagueStanding  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("TEAM_ID", TypeName = "NUMBER")]
    public decimal TeamId { get; set; }

    [Column("LEAGUE_ID", TypeName = "NUMBER")]
    public decimal LeagueId { get; set; }

    [Column("RANK_POSITION")]
    [Precision(2)]
    public byte? RankPosition { get; set; }

    [Column("TEAM_NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string TeamName { get; set; } = null!;

    [Column("MATCHES_PLAYED")]
    [Precision(3)]
    public byte? MatchesPlayed { get; set; }

    [Column("WINS")]
    [Precision(3)]
    public byte? Wins { get; set; }

    [Column("DRAWS")]
    [Precision(3)]
    public byte? Draws { get; set; }

    [Column("LOSSES")]
    [Precision(3)]
    public byte? Losses { get; set; }

    [Column("GOALS_FOR")]
    [Precision(3)]
    public byte? GoalsFor { get; set; }

    [Column("GOALS_AGAINST")]
    [Precision(3)]
    public byte? GoalsAgainst { get; set; }

    [Column("GOAL_DIFFERENCE")]
    [Precision(3)]
    public byte? GoalDifference { get; set; }

    [Column("POINTS")]
    [Precision(3)]
    public byte? Points { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
