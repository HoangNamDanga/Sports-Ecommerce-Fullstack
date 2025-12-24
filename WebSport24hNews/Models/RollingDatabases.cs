using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("ROLLING$DATABASES")]
public partial class RollingDatabases  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("RDBID", TypeName = "NUMBER")]
    public decimal? Rdbid { get; set; }

    [Column("ATTRIBUTES", TypeName = "NUMBER")]
    public decimal? Attributes { get; set; }

    [Column("ATTRIBUTES2", TypeName = "NUMBER")]
    public decimal? Attributes2 { get; set; }

    [Column("DBUN")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Dbun { get; set; }

    [Column("DBID", TypeName = "NUMBER")]
    public decimal? Dbid { get; set; }

    [Column("PROD_RSCN", TypeName = "NUMBER")]
    public decimal? ProdRscn { get; set; }

    [Column("PROD_RID", TypeName = "NUMBER")]
    public decimal? ProdRid { get; set; }

    [Column("PROD_SCN", TypeName = "NUMBER")]
    public decimal? ProdScn { get; set; }

    [Column("CONS_RSCN", TypeName = "NUMBER")]
    public decimal? ConsRscn { get; set; }

    [Column("CONS_RID", TypeName = "NUMBER")]
    public decimal? ConsRid { get; set; }

    [Column("CONS_SCN", TypeName = "NUMBER")]
    public decimal? ConsScn { get; set; }

    [Column("ENGINE_STATUS", TypeName = "NUMBER")]
    public decimal? EngineStatus { get; set; }

    [Column("VERSION")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Version { get; set; }

    [Column("REDO_SOURCE", TypeName = "NUMBER")]
    public decimal? RedoSource { get; set; }

    [Column("UPDATE_TIME")]
    [Precision(6)]
    public DateTime? UpdateTime { get; set; }

    [Column("REVISION", TypeName = "NUMBER")]
    public decimal? Revision { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
