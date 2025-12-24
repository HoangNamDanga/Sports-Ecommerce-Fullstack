using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("TEAMS")]
public partial class Team  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("TEAM_NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string TeamName { get; set; } = null!;

    [Column("TEAM_CODE")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TeamCode { get; set; }

    [Column("COUNTRY")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Country { get; set; }

    [Column("LOGO_URL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LogoUrl { get; set; }

    [Column("LEAGUE_ID", TypeName = "NUMBER")]
    public decimal? LeagueId { get; set; }

    [Column("FOUNDED_YEAR", TypeName = "NUMBER")]
    public decimal? FoundedYear { get; set; }

    [Column("STADIUM")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Stadium { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
