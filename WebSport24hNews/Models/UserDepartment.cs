using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("UserId", "DepartmentId")]
[Table("USER_DEPARTMENTS")]
public partial class UserDepartment  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("USER_ID", TypeName = "NUMBER")]
    public decimal UserId { get; set; }

    [Key]
    [Column("DEPARTMENT_ID", TypeName = "NUMBER")]
    public decimal DepartmentId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserDepartments")]
    public virtual User User { get; set; } = null!;
}
