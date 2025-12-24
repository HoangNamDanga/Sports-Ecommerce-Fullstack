using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("USERS")]
public partial class User  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("USERNAME")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Username { get; set; }

    [Column("PASSWORD")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Password { get; set; }

    [Column("INACTIVE", TypeName = "NUMBER(1)")]
    public bool? Inactive { get; set; }

    [Column("ONDELETE", TypeName = "NUMBER(1)")]
    public bool? Ondelete { get; set; }

    [Column("ROLE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Role { get; set; }

    [Column("ROLENUMBER", TypeName = "NUMBER")]
    public decimal? Rolenumber { get; set; }

    [Column("PHONE")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("FULLNAME")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Fullname { get; set; }

    [Column("MODIFYDATE", TypeName = "DATE")]
    public DateTime? Modifydate { get; set; }

    [Column("MODIFYBY")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Modifyby { get; set; }

    [Column("CREATEDATE", TypeName = "DATE")]
    public DateTime? Createdate { get; set; }

    [Column("CREATEBY")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Createby { get; set; }

    [Column("TOKENACTIVE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Tokenactive { get; set; }

    [Column("DATEACTIVE", TypeName = "DATE")]
    public DateTime? Dateactive { get; set; }

    [Column("CODEACTIVE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Codeactive { get; set; }

    [Column("DATECODEACTIVE", TypeName = "DATE")]
    public DateTime? Datecodeactive { get; set; }

    [Column("CENTER")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Center { get; set; }

    [Column("ADDGOOGLE", TypeName = "NUMBER(1)")]
    public bool? Addgoogle { get; set; }

    [Column("EMPID", TypeName = "NUMBER")]
    public decimal? Empid { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<ApproveLoginUser> ApproveLoginUsers { get; set; } = new List<ApproveLoginUser>();

    [InverseProperty("User")]
    public virtual ICollection<UserDepartment> UserDepartments { get; set; } = new List<UserDepartment>();

    [InverseProperty("User")]
    public virtual ICollection<UserInventory> UserInventories { get; set; } = new List<UserInventory>();
}
