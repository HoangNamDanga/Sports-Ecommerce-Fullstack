using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("USER_AUDITLOG_24H")]
public partial class UserAuditlog24h  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("USERNAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Username { get; set; }

    [Column("ACTION")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Action { get; set; }

    [Column("FULLNAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Fullname { get; set; }

    [Column("ROLE")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Role { get; set; }

    [Column("PHONE")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("CREATE_BY")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("NOTE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Note { get; set; }
}
