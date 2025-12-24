using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("MATCH_LINEUPS")]
public partial class MatchLineup  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("MATCH_ID", TypeName = "NUMBER")]
    public decimal MatchId { get; set; }

    [Column("TEAM_ID", TypeName = "NUMBER")]
    public decimal TeamId { get; set; }

    [Column("PLAYER_ID", TypeName = "NUMBER")]
    public decimal PlayerId { get; set; }

    [Column("JERSEY_NUMBER")]
    [Precision(2)]
    public byte? JerseyNumber { get; set; }

    [Column("POSITION")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Position { get; set; }

    [Column("IS_STARTER")]
    [StringLength(1)]
    [Unicode(false)]
    public string? IsStarter { get; set; }

    [Column("SUBSTITUTION_IN_MINUTE", TypeName = "NUMBER")]
    public decimal? SubstitutionInMinute { get; set; }

    [Column("SUBSTITUTION_OUT_MINUTE", TypeName = "NUMBER")]
    public decimal? SubstitutionOutMinute { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
