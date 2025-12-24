using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("DHN_PRODUCT_IMAGE")]
public partial class DhnProductImage  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("PRODUCT_ID", TypeName = "NUMBER")]
    public decimal? ProductId { get; set; }

    [Column("IMAGE_URL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ImageUrl { get; set; }

    [Column("IS_THUMBNAIL")]
    [StringLength(1)]
    [Unicode(false)]
    public string? IsThumbnail { get; set; }

    [Column("DISPLAY_ORDER", TypeName = "NUMBER")]
    public decimal? DisplayOrder { get; set; }

    [Column("ALT_TEXT")]
    [StringLength(255)]
    [Unicode(false)]
    public string? AltText { get; set; }

    [Column("ATTRIBUTE1")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute1 { get; set; }

    [Column("ATTRIBUTE2")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute2 { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("DhnProductImages")]
    public virtual DhnProduct? Product { get; set; }
}
