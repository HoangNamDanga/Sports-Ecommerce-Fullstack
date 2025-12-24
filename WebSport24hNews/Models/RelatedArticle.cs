using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("PrimaryArticleId", "RelatedArticleId")]
[Table("RELATED_ARTICLES")]
public partial class RelatedArticle  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("PRIMARY_ARTICLE_ID", TypeName = "NUMBER")]
    public decimal PrimaryArticleId { get; set; }

    [Key]
    [Column("RELATED_ARTICLE_ID", TypeName = "NUMBER")]
    public decimal RelatedArticleId { get; set; }

    [Column("RELATION_TYPE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? RelationType { get; set; }

    [Column("CREATED_AT")]
    [Precision(6)]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("PrimaryArticleId")]
    [InverseProperty("RelatedArticlePrimaryArticles")]
    public virtual Article PrimaryArticle { get; set; } = null!;

    [ForeignKey("RelatedArticleId")]
    [InverseProperty("RelatedArticleRelatedArticleNavigations")]
    public virtual Article RelatedArticleNavigation { get; set; } = null!;
}
