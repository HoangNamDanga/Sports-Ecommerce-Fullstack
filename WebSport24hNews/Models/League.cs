using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("LEAGUES")]
public partial class League  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("LEAGUE_NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string? LeagueName { get; set; }

    [Column("REGION_COUNTRY")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RegionCountry { get; set; }

    [Column("DIVISION", TypeName = "NUMBER(1)")]
    public bool? Division { get; set; }

    [Column("SEASON_START", TypeName = "DATE")]
    public DateTime? SeasonStart { get; set; }

    [Column("SEASON_END", TypeName = "DATE")]
    public DateTime? SeasonEnd { get; set; }

    [Column("LOGO_URL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? LogoUrl { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
