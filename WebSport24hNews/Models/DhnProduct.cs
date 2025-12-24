using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("DHN_PRODUCTS")]
public partial class DhnProduct  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("PRODUCT_NAME")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ProductName { get; set; }

    [Column("CATEGORY_ID", TypeName = "NUMBER")]
    public decimal? CategoryId { get; set; }

    [Column("ORIGINAL_PRICE", TypeName = "NUMBER(10,2)")]
    public decimal? OriginalPrice { get; set; }

    [Column("CURRENT_PRICE", TypeName = "NUMBER(10,2)")]
    public decimal? CurrentPrice { get; set; }

    [Column("BRAND")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Brand { get; set; }

    [Column("DESCRIPTION", TypeName = "CLOB")]
    public string? Description { get; set; }

    [Column("STOCK_QUANTITY", TypeName = "NUMBER")]
    public decimal? StockQuantity { get; set; }

    [Column("IS_BEST_SELLER")]
    [StringLength(1)]
    [Unicode(false)]
    public string? IsBestSeller { get; set; }

    [Column("ATTRIBUTE1")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute1 { get; set; }

    [Column("ATTRIBUTE2")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute2 { get; set; }

    [Column("ATTRIBUTE3")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute3 { get; set; }

    [Column("ATTRIBUTE4")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute4 { get; set; }

    [Column("ATTRIBUTE5")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute5 { get; set; }

    [Column("ATTRIBUTE6")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute6 { get; set; }

    [Column("ATTRIBUTE7")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute7 { get; set; }

    [Column("ATTRIBUTE8")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute8 { get; set; }

    [Column("ATTRIBUTE9")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute9 { get; set; }

    [Column("ATTRIBUTE10")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute10 { get; set; }

    [Column("ATTRIBUTE11")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute11 { get; set; }

    [Column("ATTRIBUTE12")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute12 { get; set; }

    [Column("ATTRIBUTE13")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute13 { get; set; }

    [Column("ATTRIBUTE14")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute14 { get; set; }

    [Column("ATTRIBUTE15")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute15 { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<DhnCartItem> DhnCartItems { get; set; } = new List<DhnCartItem>();

    [InverseProperty("Product")]
    public virtual ICollection<DhnNewsArticle> DhnNewsArticles { get; set; } = new List<DhnNewsArticle>();

    [InverseProperty("Product")]
    public virtual ICollection<DhnProductImage> DhnProductImages { get; set; } = new List<DhnProductImage>();

    [InverseProperty("Product")]
    public virtual ICollection<DhnProductVariant> DhnProductVariants { get; set; } = new List<DhnProductVariant>();
}
