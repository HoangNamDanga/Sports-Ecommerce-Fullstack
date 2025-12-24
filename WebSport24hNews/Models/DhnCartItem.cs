using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("DHN_CART_ITEMS")]
[Index("CartId", "ProductId", Name = "UQ_CART_PRODUCT", IsUnique = true)]
public partial class DhnCartItem  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("CART_ID", TypeName = "NUMBER")]
    public decimal CartId { get; set; }

    [Column("PRODUCT_ID", TypeName = "NUMBER")]
    public decimal ProductId { get; set; }

    [Column("QUANTITY", TypeName = "NUMBER")]
    public decimal? Quantity { get; set; }

    [Column("UNIT_PRICE", TypeName = "NUMBER(10,2)")]
    public decimal? UnitPrice { get; set; }

    [Column("TOTAL_PRICE", TypeName = "NUMBER(10,2)")]
    public decimal? TotalPrice { get; set; }

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

    [ForeignKey("CartId")]
    [InverseProperty("DhnCartItems")]
    public virtual DhnCart Cart { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("DhnCartItems")]
    public virtual DhnProduct Product { get; set; } = null!;
}
