using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Level definition
/// </summary>
[PrimaryKey("Runid", "Levelid")]
[Table("MVIEW$_ADV_LEVEL")]
public partial class MviewAdvLevel  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Key]
    [Column("LEVELID#", TypeName = "NUMBER")]
    public decimal Levelid { get; set; }

    [Column("DIMOBJ#", TypeName = "NUMBER")]
    public decimal? Dimobj { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal Flags { get; set; }

    [Column("TBLOBJ#", TypeName = "NUMBER")]
    public decimal Tblobj { get; set; }

    [Column("COLUMNLIST")]
    [MaxLength(70)]
    public byte[] Columnlist { get; set; } = null!;

    [Column("LEVELNAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Levelname { get; set; }

    [InverseProperty("MviewAdvLevelNavigation")]
    public virtual ICollection<MviewAdvRollup> MviewAdvRollupMviewAdvLevelNavigations { get; set; } = new List<MviewAdvRollup>();

    [InverseProperty("MviewAdvLevel")]
    public virtual ICollection<MviewAdvRollup> MviewAdvRollupMviewAdvLevels { get; set; } = new List<MviewAdvRollup>();

    [ForeignKey("Runid")]
    [InverseProperty("MviewAdvLevels")]
    public virtual MviewAdvLog Run { get; set; } = null!;
}
