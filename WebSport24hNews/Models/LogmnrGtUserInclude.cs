using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGMNR_GT_USER_INCLUDE$")]
public partial class LogmnrGtUserInclude  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("USER_NAME")]
    [StringLength(390)]
    [Unicode(false)]
    public string? UserName { get; set; }

    [Column("USER_TYPE", TypeName = "NUMBER")]
    public decimal? UserType { get; set; }

    [Column("PDB_NAME")]
    [StringLength(390)]
    [Unicode(false)]
    public string? PdbName { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
