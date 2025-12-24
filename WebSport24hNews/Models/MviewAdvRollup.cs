using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Each row repesents either a functional dependency or join-key relationship
/// </summary>
[PrimaryKey("Runid", "Clevelid", "Plevelid")]
[Table("MVIEW$_ADV_ROLLUP")]
public partial class MviewAdvRollup  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Key]
    [Column("CLEVELID#", TypeName = "NUMBER")]
    public decimal Clevelid { get; set; }

    [Key]
    [Column("PLEVELID#", TypeName = "NUMBER")]
    public decimal Plevelid { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal Flags { get; set; }

    [ForeignKey("Runid, Clevelid")]
    [InverseProperty("MviewAdvRollupMviewAdvLevels")]
    public virtual MviewAdvLevel MviewAdvLevel { get; set; } = null!;

    [ForeignKey("Runid, Plevelid")]
    [InverseProperty("MviewAdvRollupMviewAdvLevelNavigations")]
    public virtual MviewAdvLevel MviewAdvLevelNavigation { get; set; } = null!;

    [ForeignKey("Runid")]
    [InverseProperty("MviewAdvRollups")]
    public virtual MviewAdvLog Run { get; set; } = null!;
}
