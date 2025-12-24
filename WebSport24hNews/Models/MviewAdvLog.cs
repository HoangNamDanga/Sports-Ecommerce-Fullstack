using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Log all calls to summary advisory functions
/// </summary>
[Table("MVIEW$_ADV_LOG")]
public partial class MviewAdvLog  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Column("FILTERID#", TypeName = "NUMBER")]
    public decimal? Filterid { get; set; }

    [Column("RUN_BEGIN", TypeName = "DATE")]
    public DateTime? RunBegin { get; set; }

    [Column("RUN_END", TypeName = "DATE")]
    public DateTime? RunEnd { get; set; }

    [Column("RUN_TYPE", TypeName = "NUMBER")]
    public decimal? RunType { get; set; }

    [Column("UNAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Uname { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal Status { get; set; }

    [Column("MESSAGE")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Message { get; set; }

    [Column("COMPLETED", TypeName = "NUMBER")]
    public decimal? Completed { get; set; }

    [Column("TOTAL", TypeName = "NUMBER")]
    public decimal? Total { get; set; }

    [Column("ERROR_CODE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ErrorCode { get; set; }

    [InverseProperty("Run")]
    public virtual ICollection<MviewAdvAjg> MviewAdvAjgs { get; set; } = new List<MviewAdvAjg>();

    [InverseProperty("Run")]
    public virtual ICollection<MviewAdvClique> MviewAdvCliques { get; set; } = new List<MviewAdvClique>();

    [InverseProperty("Run")]
    public virtual ICollection<MviewAdvEligible> MviewAdvEligibles { get; set; } = new List<MviewAdvEligible>();

    [InverseProperty("Run")]
    public virtual ICollection<MviewAdvInfo> MviewAdvInfos { get; set; } = new List<MviewAdvInfo>();

    [InverseProperty("Run")]
    public virtual ICollection<MviewAdvJournal> MviewAdvJournals { get; set; } = new List<MviewAdvJournal>();

    [InverseProperty("Run")]
    public virtual ICollection<MviewAdvLevel> MviewAdvLevels { get; set; } = new List<MviewAdvLevel>();

    [InverseProperty("Run")]
    public virtual ICollection<MviewAdvOutput> MviewAdvOutputs { get; set; } = new List<MviewAdvOutput>();

    [InverseProperty("Run")]
    public virtual ICollection<MviewAdvRollup> MviewAdvRollups { get; set; } = new List<MviewAdvRollup>();
}
