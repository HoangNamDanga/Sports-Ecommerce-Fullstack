using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrDid", "LogmnrMdh", "PluginScn")]
[Table("LOGMNR_PDB_INFO$")]
public partial class LogmnrPdbInfo  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_DID", TypeName = "NUMBER")]
    public decimal LogmnrDid { get; set; }

    [Key]
    [Column("LOGMNR_MDH", TypeName = "NUMBER")]
    public decimal LogmnrMdh { get; set; }

    [Column("PDB_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? PdbName { get; set; }

    [Column("PDB_ID", TypeName = "NUMBER")]
    public decimal? PdbId { get; set; }

    [Column("PDB_UID", TypeName = "NUMBER")]
    public decimal? PdbUid { get; set; }

    [Key]
    [Column("PLUGIN_SCN", TypeName = "NUMBER")]
    public decimal PluginScn { get; set; }

    [Column("UNPLUG_SCN", TypeName = "NUMBER")]
    public decimal? UnplugScn { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Unicode(false)]
    public string? Spare3 { get; set; }

    [Column("SPARE4")]
    [Precision(6)]
    public DateTime? Spare4 { get; set; }

    [Column("PDB_GLOBAL_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? PdbGlobalName { get; set; }
}
