using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("ARTICLES")]
public partial class Article  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("TITLE")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Title { get; set; }

    [Column("CONTENT", TypeName = "CLOB")]
    public string? Content { get; set; }

    [Column("SUMMARY")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Summary { get; set; }

    [Column("AUTHOR_ID", TypeName = "NUMBER")]
    public decimal? AuthorId { get; set; }

    [Column("TEAM_ID", TypeName = "NUMBER")]
    public decimal? TeamId { get; set; }

    [Column("PUBLISHED_AT", TypeName = "DATE")]
    public DateTime? PublishedAt { get; set; }

    [Column("SLUG")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Slug { get; set; }

    [Column("FEATURED_IMAGE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? FeaturedImage { get; set; }

    [Column("VIEW_COUNT", TypeName = "NUMBER")]
    public decimal? ViewCount { get; set; }

    [Column("IS_FEATURED", TypeName = "NUMBER(1)")]
    public bool? IsFeatured { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }

    [Column("CATEGORY_ID", TypeName = "NUMBER")]
    public decimal? CategoryId { get; set; }

    [InverseProperty("PrimaryArticle")]
    public virtual ICollection<RelatedArticle> RelatedArticlePrimaryArticles { get; set; } = new List<RelatedArticle>();

    [InverseProperty("RelatedArticleNavigation")]
    public virtual ICollection<RelatedArticle> RelatedArticleRelatedArticleNavigations { get; set; } = new List<RelatedArticle>();
}
