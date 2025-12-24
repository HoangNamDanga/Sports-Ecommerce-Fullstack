using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("FA_ADDITIONS")]
public partial class FaAdditions  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID")]
    [Precision(15)]
    public long Id { get; set; }

    [Column("ASSET_ID", TypeName = "NUMBER")]
    public decimal AssetId { get; set; }

    [Column("DATE_IN_SERVICE", TypeName = "DATE")]
    public DateTime DateInService { get; set; }

    [Column("DATE_EFFECTIVE", TypeName = "DATE")]
    public DateTime DateEffective { get; set; }

    [Column("DEPRN_START_DATE", TypeName = "DATE")]
    public DateTime DeprnStartDate { get; set; }

    [Column("LIFE_IN_MONTHS")]
    [Precision(4)]
    public byte? LifeInMonths { get; set; }

    [Column("RATE_ADJUSTMENT", TypeName = "NUMBER")]
    public decimal? RateAdjustment { get; set; }

    [Column("CURR_COST", TypeName = "NUMBER")]
    public decimal? CurrCost { get; set; }

    [Column("ORIGINAL_COST", TypeName = "NUMBER")]
    public decimal? OriginalCost { get; set; }

    [Column("DEPRECIATED_VALUE", TypeName = "NUMBER")]
    public decimal? DepreciatedValue { get; set; }

    [Column("YTD_DEPRN_AMOUT", TypeName = "NUMBER")]
    public decimal? YtdDeprnAmout { get; set; }

    [Column("ACCUMULATED_DEPRN_AMOUT", TypeName = "NUMBER")]
    public decimal? AccumulatedDeprnAmout { get; set; }

    [Column("CAPITALIZE_FLAG", TypeName = "NUMBER(1)")]
    public bool? CapitalizeFlag { get; set; }

    [Column("RETIREMENT_PENDING_FLAG", TypeName = "NUMBER(1)")]
    public bool? RetirementPendingFlag { get; set; }

    [Column("DEPRECIATE_FLAG", TypeName = "NUMBER(1)")]
    public bool? DepreciateFlag { get; set; }

    [Column("TRANSACTION_HEADER_ID_IN")]
    [Precision(15)]
    public long? TransactionHeaderIdIn { get; set; }

    [Column("TRANSACTION_HEADER_ID_OUT")]
    [Precision(15)]
    public long? TransactionHeaderIdOut { get; set; }

    [Column("RETIMENT_ID")]
    [Precision(15)]
    public long? RetimentId { get; set; }

    [Column("PERIOD_COUNTER_CAPITALIZED")]
    [StringLength(15)]
    [Unicode(false)]
    public string? PeriodCounterCapitalized { get; set; }

    [Column("PERIOD_COUNTER_FULLY_RESERVED")]
    [StringLength(15)]
    [Unicode(false)]
    public string? PeriodCounterFullyReserved { get; set; }

    [Column("PERIOD_COUNTER_FULLY_RETIRED")]
    [StringLength(15)]
    [Unicode(false)]
    public string? PeriodCounterFullyRetired { get; set; }

    [Column("DEPRN_METHOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DeprnMethod { get; set; }

    [Column("DEPRN_LIFE_YEAR", TypeName = "NUMBER")]
    public decimal DeprnLifeYear { get; set; }

    [Column("DEPRN_LIFE_MONTH", TypeName = "NUMBER")]
    public decimal DeprnLifeMonth { get; set; }

    [Column("ATTRIBUTE1")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute1 { get; set; }

    [Column("ATTRIBUTE2")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute2 { get; set; }

    [Column("ATTRIBUTE3")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute3 { get; set; }

    [Column("ATTRIBUTE4")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute4 { get; set; }

    [Column("ATTRIBUTE5")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute5 { get; set; }

    [Column("ATTRIBUTE6")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute6 { get; set; }

    [Column("ATTRIBUTE7")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute7 { get; set; }

    [Column("ATTRIBUTE8")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute8 { get; set; }

    [Column("ATTRIBUTE9")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute9 { get; set; }

    [Column("ATTRIBUTE10")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute10 { get; set; }

    [Column("ATTRIBUTE11")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute11 { get; set; }

    [Column("ATTRIBUTE12")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute12 { get; set; }

    [Column("ATTRIBUTE13")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute13 { get; set; }

    [Column("ATTRIBUTE14")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute14 { get; set; }

    [Column("ATTRIBUTE15")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute15 { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
