using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("GlobalName", "LogmnrMdh")]
[Table("LOGMNRC_DBNAME_UID_MAP")]
public partial class LogmnrcDbnameUidMap  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("GLOBAL_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string GlobalName { get; set; } = null!;

    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal? LogmnrUid { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("PDB_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? PdbName { get; set; }

    [Key]
    [Column("LOGMNR_MDH", TypeName = "NUMBER")]
    public decimal LogmnrMdh { get; set; }
}
