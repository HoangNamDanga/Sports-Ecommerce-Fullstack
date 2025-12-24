using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("VIDEOS")]
public partial class Video  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("TITLE")]
    [StringLength(200)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column("DESCRIPTION")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("EMBED_URL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? EmbedUrl { get; set; }

    [Column("THUMBNAIL_URL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ThumbnailUrl { get; set; }

    [Column("TEAM_ID", TypeName = "NUMBER")]
    public decimal? TeamId { get; set; }

    [Column("LEAGUE_ID", TypeName = "NUMBER")]
    public decimal? LeagueId { get; set; }

    [Column("AUTHOR_ID", TypeName = "NUMBER")]
    public decimal? AuthorId { get; set; }

    [Column("DURATION")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Duration { get; set; }

    [Column("PUBLISHED_AT", TypeName = "DATE")]
    public DateTime? PublishedAt { get; set; }

    [Column("SLUG")]
    [StringLength(150)]
    [Unicode(false)]
    public string? Slug { get; set; }

    [Column("VIEW_COUNT", TypeName = "NUMBER")]
    public decimal? ViewCount { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
