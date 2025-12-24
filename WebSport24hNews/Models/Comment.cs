using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("COMMENTS")]
public partial class Comment  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("ARTICLE_ID", TypeName = "NUMBER")]
    public decimal? ArticleId { get; set; }

    [Column("USER_ID", TypeName = "NUMBER")]
    public decimal? UserId { get; set; }

    [Column("CONTENT")]
    [StringLength(1000)]
    [Unicode(false)]
    public string Content { get; set; } = null!;

    [Column("PARENT_COMMENT_ID", TypeName = "NUMBER")]
    public decimal? ParentCommentId { get; set; }

    [Column("IS_APPROVED", TypeName = "NUMBER(1)")]
    public bool? IsApproved { get; set; }

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
}
