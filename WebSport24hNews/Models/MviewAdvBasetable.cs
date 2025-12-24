using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Base tables refered by a query
/// </summary>
[Keyless]
[Table("MVIEW$_ADV_BASETABLE")]
[Index("Queryid", Name = "MVIEW$_ADV_BASETABLE_IDX_01")]
public partial class MviewAdvBasetable  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("COLLECTIONID#", TypeName = "NUMBER")]
    public decimal Collectionid { get; set; }

    [Column("QUERYID#", TypeName = "NUMBER")]
    public decimal Queryid { get; set; }

    [Column("OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Owner { get; set; }

    [Column("TABLE_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? TableName { get; set; }

    [Column("TABLE_TYPE", TypeName = "NUMBER")]
    public decimal? TableType { get; set; }

    [ForeignKey("Queryid")]
    public virtual MviewAdvWorkload Query { get; set; } = null!;
}
