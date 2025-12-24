using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("REFRESH_TOKEN")]
[Index("Token", Name = "SYS_C008320", IsUnique = true)]
public partial class RefreshToken  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("USER_ID", TypeName = "NUMBER")]
    public decimal UserId { get; set; }

    [Column("TOKEN")]
    [StringLength(200)]
    [Unicode(false)]
    public string Token { get; set; } = null!;

    [Column("EXPIRY_DATE", TypeName = "DATE")]
    public DateTime ExpiryDate { get; set; }

    [Column("CREATED_DATE", TypeName = "DATE")]
    public DateTime CreatedDate { get; set; }

    [Column("REVOKED")]
    [StringLength(1)]
    [Unicode(false)]
    public string? Revoked { get; set; }
}
