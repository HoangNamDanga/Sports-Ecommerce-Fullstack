using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("LIVE_SCORES")]
public partial class LiveScore  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("MATCH_ID", TypeName = "NUMBER")]
    public decimal? MatchId { get; set; }

    [Column("HOME_SCORE", TypeName = "NUMBER")]
    public decimal? HomeScore { get; set; }

    [Column("AWAY_SCORE", TypeName = "NUMBER")]
    public decimal? AwayScore { get; set; }

    [Column("CURRENT_MINUTE")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CurrentMinute { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
