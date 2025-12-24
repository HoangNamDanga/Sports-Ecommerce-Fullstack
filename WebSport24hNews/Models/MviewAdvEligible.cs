using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Summary management rewrite eligibility information
/// </summary>
[PrimaryKey("Sumobjn", "Runid")]
[Table("MVIEW$_ADV_ELIGIBLE")]
public partial class MviewAdvEligible  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("SUMOBJN#", TypeName = "NUMBER")]
    public decimal Sumobjn { get; set; }

    [Key]
    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Column("BYTECOST", TypeName = "NUMBER")]
    public decimal Bytecost { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal Flags { get; set; }

    [Column("FREQUENCY", TypeName = "NUMBER")]
    public decimal Frequency { get; set; }

    [ForeignKey("Runid")]
    [InverseProperty("MviewAdvEligibles")]
    public virtual MviewAdvLog Run { get; set; } = null!;
}
