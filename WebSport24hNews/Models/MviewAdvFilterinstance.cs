using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Table for workload filter instance definition
/// </summary>
[Keyless]
[Table("MVIEW$_ADV_FILTERINSTANCE")]
public partial class MviewAdvFilterinstance  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Column("FILTERID#", TypeName = "NUMBER")]
    public decimal? Filterid { get; set; }

    [Column("SUBFILTERNUM#", TypeName = "NUMBER")]
    public decimal? Subfilternum { get; set; }

    [Column("SUBFILTERTYPE", TypeName = "NUMBER")]
    public decimal? Subfiltertype { get; set; }

    [Column("STR_VALUE")]
    [StringLength(1028)]
    [Unicode(false)]
    public string? StrValue { get; set; }

    [Column("NUM_VALUE1", TypeName = "NUMBER")]
    public decimal? NumValue1 { get; set; }

    [Column("NUM_VALUE2", TypeName = "NUMBER")]
    public decimal? NumValue2 { get; set; }

    [Column("DATE_VALUE1", TypeName = "DATE")]
    public DateTime? DateValue1 { get; set; }

    [Column("DATE_VALUE2", TypeName = "DATE")]
    public DateTime? DateValue2 { get; set; }

    [ForeignKey("Runid")]
    public virtual MviewAdvLog Run { get; set; } = null!;
}
