using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("UserId", "InventoryId")]
[Table("USER_INVENTORIES")]
public partial class UserInventories  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("USER_ID", TypeName = "NUMBER")]
    public decimal UserId { get; set; }

    [Key]
    [Column("INVENTORY_ID", TypeName = "NUMBER")]
    public decimal InventoryId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserInventories")]
    public virtual Users User { get; set; } = null!;
}
