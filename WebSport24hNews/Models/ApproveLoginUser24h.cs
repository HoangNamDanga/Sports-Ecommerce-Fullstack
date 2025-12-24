using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("APPROVE_LOGIN_USER24H")]
public partial class ApproveLoginUser24h  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("USER_ID", TypeName = "NUMBER")]
    public decimal? UserId { get; set; }

    [Column("IP")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Ip { get; set; }

    [Column("ISLOGIN", TypeName = "NUMBER(1)")]
    public bool? Islogin { get; set; }

    [Column("ISLOGOUT", TypeName = "NUMBER(1)")]
    public bool? Islogout { get; set; }
}
