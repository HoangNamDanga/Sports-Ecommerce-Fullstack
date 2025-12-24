using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
public partial class MviewRecommendations  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("RUNID", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Column("ALL_TABLES")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? AllTables { get; set; }

    [Column("FACT_TABLES")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? FactTables { get; set; }

    [Column("GROUPING_LEVELS")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? GroupingLevels { get; set; }

    [Column("QUERY_TEXT", TypeName = "LONG")]
    public string? QueryText { get; set; }

    [Column("RECOMMENDATION_NUMBER", TypeName = "NUMBER")]
    public decimal RecommendationNumber { get; set; }

    [Column("RECOMMENDED_ACTION")]
    [StringLength(6)]
    [Unicode(false)]
    public string? RecommendedAction { get; set; }

    [Column("MVIEW_OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string? MviewOwner { get; set; }

    [Column("MVIEW_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? MviewName { get; set; }

    [Column("STORAGE_IN_BYTES", TypeName = "NUMBER")]
    public decimal? StorageInBytes { get; set; }

    [Column("PCT_PERFORMANCE_GAIN", TypeName = "NUMBER")]
    public decimal? PctPerformanceGain { get; set; }

    [Column("BENEFIT_TO_COST_RATIO", TypeName = "NUMBER")]
    public decimal BenefitToCostRatio { get; set; }
}
