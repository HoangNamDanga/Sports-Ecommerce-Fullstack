using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Shared workload repository for DBA users of summary advisor
/// </summary>
[Table("MVIEW$_ADV_WORKLOAD")]
[Index("Collectionid", "Queryid", Name = "MVIEW$_ADV_WORKLOAD_IDX_01")]
public partial class MviewAdvWorkload  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("QUERYID#", TypeName = "NUMBER")]
    public decimal Queryid { get; set; }

    [Column("COLLECTIONID#", TypeName = "NUMBER")]
    public decimal Collectionid { get; set; }

    [Column("COLLECTTIME", TypeName = "DATE")]
    public DateTime Collecttime { get; set; }

    [Column("APPLICATION")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Application { get; set; }

    [Column("CARDINALITY", TypeName = "NUMBER")]
    public decimal? Cardinality { get; set; }

    [Column("RESULTSIZE", TypeName = "NUMBER")]
    public decimal? Resultsize { get; set; }

    [Column("UNAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string Uname { get; set; } = null!;

    [Column("QDATE", TypeName = "DATE")]
    public DateTime? Qdate { get; set; }

    [Column("PRIORITY", TypeName = "NUMBER")]
    public decimal? Priority { get; set; }

    [Column("EXEC_TIME", TypeName = "NUMBER")]
    public decimal? ExecTime { get; set; }

    [Column("SQL_TEXT", TypeName = "LONG")]
    public string SqlText { get; set; } = null!;

    [Column("SQL_TEXTLEN", TypeName = "NUMBER")]
    public decimal SqlTextlen { get; set; }

    [Column("SQL_HASH", TypeName = "NUMBER")]
    public decimal? SqlHash { get; set; }

    [Column("SQL_ADDR")]
    public Guid? SqlAddr { get; set; }

    [Column("FREQUENCY", TypeName = "NUMBER")]
    public decimal? Frequency { get; set; }
}
