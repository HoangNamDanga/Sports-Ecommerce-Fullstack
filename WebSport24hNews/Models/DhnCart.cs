using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("DHN_CARTS")]
public partial class DhnCart  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("USER_ID", TypeName = "NUMBER")]
    public decimal? UserId { get; set; }

    [Column("TOTAL_AMOUNT", TypeName = "NUMBER(10,2)")]
    public decimal? TotalAmount { get; set; }

    [Column("STATUS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Status { get; set; }

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

    [Column("SESSION_ID")]
    [StringLength(255)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("TOTAL_ITEMS", TypeName = "NUMBER")]
    public decimal? TotalItems { get; set; }

    [InverseProperty("Cart")]
    public virtual ICollection<DhnCartItem> DhnCartItems { get; set; } = new List<DhnCartItem>();
}
