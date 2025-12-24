using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("MATCHES")]
public partial class Match  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("HOME_TEAM_ID", TypeName = "NUMBER")]
    public decimal? HomeTeamId { get; set; }

    [Column("AWAY_TEAM_ID", TypeName = "NUMBER")]
    public decimal? AwayTeamId { get; set; }

    [Column("LEAGUE_ID", TypeName = "NUMBER")]
    public decimal? LeagueId { get; set; }

    [Column("MATCH_DATE", TypeName = "DATE")]
    public DateTime? MatchDate { get; set; }

    [Column("STADIUM")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Stadium { get; set; }

    [Column("FIRST_HALF_SCORE_HOME")]
    [Precision(2)]
    public byte? FirstHalfScoreHome { get; set; }

    [Column("FIRST_HALF_SCORE_AWAY")]
    [Precision(2)]
    public byte? FirstHalfScoreAway { get; set; }

    [Column("FULL_TIME_SCORE_HOME")]
    [Precision(2)]
    public byte? FullTimeScoreHome { get; set; }

    [Column("FULL_TIME_SCORE_AWAY")]
    [Precision(2)]
    public byte? FullTimeScoreAway { get; set; }

    [Column("STATUS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("REFEREE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Referee { get; set; }

    [Column("ATTENDANCE", TypeName = "NUMBER")]
    public decimal? Attendance { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
