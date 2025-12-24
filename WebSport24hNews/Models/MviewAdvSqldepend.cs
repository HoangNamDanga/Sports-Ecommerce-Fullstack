using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Temporary table for workload collections
/// </summary>
[Keyless]
[Table("MVIEW$_ADV_SQLDEPEND")]
[Index("Collectionid", "FromAddress", "FromHash", "InstId", Name = "MVIEW$_ADV_SQLDEPEND_IDX_01")]
public partial class MviewAdvSqldepend  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("COLLECTIONID#", TypeName = "NUMBER")]
    public decimal? Collectionid { get; set; }

    [Column("INST_ID", TypeName = "NUMBER")]
    public decimal? InstId { get; set; }

    [Column("FROM_ADDRESS")]
    public Guid? FromAddress { get; set; }

    [Column("FROM_HASH", TypeName = "NUMBER")]
    public decimal? FromHash { get; set; }

    [Column("TO_OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string? ToOwner { get; set; }

    [Column("TO_NAME")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? ToName { get; set; }

    [Column("TO_TYPE", TypeName = "NUMBER")]
    public decimal? ToType { get; set; }

    [Column("CARDINALITY", TypeName = "NUMBER")]
    public decimal? Cardinality { get; set; }
}
