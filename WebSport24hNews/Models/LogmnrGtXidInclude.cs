using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGMNR_GT_XID_INCLUDE$")]
public partial class LogmnrGtXidInclude  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("XIDUSN", TypeName = "NUMBER")]
    public decimal? Xidusn { get; set; }

    [Column("XIDSLT", TypeName = "NUMBER")]
    public decimal? Xidslt { get; set; }

    [Column("XIDSQN", TypeName = "NUMBER")]
    public decimal? Xidsqn { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Unicode(false)]
    public string? Spare3 { get; set; }

    [Column("PDBID", TypeName = "NUMBER")]
    public decimal? Pdbid { get; set; }

    [Column("PDB_NAME")]
    [StringLength(390)]
    [Unicode(false)]
    public string? PdbName { get; set; }
}
