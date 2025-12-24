using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("CATEGORIES")]
public partial class Category  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("CATEGORY_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CategoryName { get; set; }

    [Column("SLUG")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Slug { get; set; }

    [Column("PARENT_ID", TypeName = "NUMBER")]
    public decimal? ParentId { get; set; }

    [Column("DISPLAY_ORDER", TypeName = "NUMBER")]
    public decimal? DisplayOrder { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }

    [Column("LEAGUE_ID", TypeName = "NUMBER")]
    public decimal? LeagueId { get; set; }
}
