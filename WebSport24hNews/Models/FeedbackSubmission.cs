using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("FEEDBACK_SUBMISSIONS")]
public partial class FeedbackSubmission  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("FULL_NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string? FullName { get; set; }

    [Column("EMAIL")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("FEEDBACK_CONTENT", TypeName = "CLOB")]
    public string? FeedbackContent { get; set; }

    [Column("STATUS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }

    [Column("VIDEO_ID", TypeName = "NUMBER")]
    public decimal? VideoId { get; set; }

    [Column("ARTICLE_ID", TypeName = "NUMBER")]
    public decimal? ArticleId { get; set; }
}
