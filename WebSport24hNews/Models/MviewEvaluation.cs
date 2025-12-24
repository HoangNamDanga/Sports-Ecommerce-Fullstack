using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
public partial class MviewEvaluation  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("RUNID", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Column("MVIEW_OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string? MviewOwner { get; set; }

    [Column("MVIEW_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? MviewName { get; set; }

    [Column("RANK", TypeName = "NUMBER")]
    public decimal Rank { get; set; }

    [Column("STORAGE_IN_BYTES", TypeName = "NUMBER")]
    public decimal? StorageInBytes { get; set; }

    [Column("FREQUENCY", TypeName = "NUMBER")]
    public decimal? Frequency { get; set; }

    [Column("CUMULATIVE_BENEFIT", TypeName = "NUMBER")]
    public decimal? CumulativeBenefit { get; set; }

    [Column("BENEFIT_TO_COST_RATIO", TypeName = "NUMBER")]
    public decimal BenefitToCostRatio { get; set; }
}
