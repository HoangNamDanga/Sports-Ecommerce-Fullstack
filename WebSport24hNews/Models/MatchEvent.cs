using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("MATCH_EVENTS")]
public partial class MatchEvent  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("MATCH_ID", TypeName = "NUMBER")]
    public decimal? MatchId { get; set; }

    [Column("EVENT_TYPE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? EventType { get; set; }

    [Column("PLAYER_ID", TypeName = "NUMBER")]
    public decimal? PlayerId { get; set; }

    [Column("TEAM_ID", TypeName = "NUMBER")]
    public decimal? TeamId { get; set; }

    [Column("MINUTE", TypeName = "NUMBER")]
    public decimal? Minute { get; set; }

    [Column("ADDITIONAL_INFO")]
    [StringLength(255)]
    [Unicode(false)]
    public string? AdditionalInfo { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
