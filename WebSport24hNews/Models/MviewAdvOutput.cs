using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Output table for summary recommendations and evaluations
/// </summary>
[PrimaryKey("Runid", "Rank")]
[Table("MVIEW$_ADV_OUTPUT")]
public partial class MviewAdvOutput  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Column("OUTPUT_TYPE", TypeName = "NUMBER")]
    public decimal OutputType { get; set; }

    [Key]
    [Column("RANK#", TypeName = "NUMBER")]
    public decimal Rank { get; set; }

    [Column("ACTION_TYPE")]
    [StringLength(6)]
    [Unicode(false)]
    public string? ActionType { get; set; }

    [Column("SUMMARY_OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string? SummaryOwner { get; set; }

    [Column("SUMMARY_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? SummaryName { get; set; }

    [Column("GROUP_BY_COLUMNS")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? GroupByColumns { get; set; }

    [Column("WHERE_CLAUSE")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? WhereClause { get; set; }

    [Column("FROM_CLAUSE")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? FromClause { get; set; }

    [Column("MEASURES_LIST")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? MeasuresList { get; set; }

    [Column("FACT_TABLES")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? FactTables { get; set; }

    [Column("GROUPING_LEVELS")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? GroupingLevels { get; set; }

    [Column("QUERYLEN", TypeName = "NUMBER")]
    public decimal? Querylen { get; set; }

    [Column("QUERY_TEXT", TypeName = "LONG")]
    public string? QueryText { get; set; }

    [Column("STORAGE_IN_BYTES", TypeName = "NUMBER")]
    public decimal? StorageInBytes { get; set; }

    [Column("PCT_PERFORMANCE_GAIN", TypeName = "NUMBER")]
    public decimal? PctPerformanceGain { get; set; }

    [Column("FREQUENCY", TypeName = "NUMBER")]
    public decimal? Frequency { get; set; }

    [Column("CUMULATIVE_BENEFIT", TypeName = "NUMBER")]
    public decimal? CumulativeBenefit { get; set; }

    [Column("BENEFIT_TO_COST_RATIO", TypeName = "NUMBER")]
    public decimal BenefitToCostRatio { get; set; }

    [Column("VALIDATED", TypeName = "NUMBER")]
    public decimal? Validated { get; set; }

    [ForeignKey("Runid")]
    [InverseProperty("MviewAdvOutputs")]
    public virtual MviewAdvLog Run { get; set; } = null!;
}
