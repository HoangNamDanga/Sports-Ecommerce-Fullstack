using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Internal table for passing information from the SQL analyzer
/// </summary>
[PrimaryKey("Runid", "Seq")]
[Table("MVIEW$_ADV_INFO")]
public partial class MviewAdvInfo  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Key]
    [Column("SEQ#", TypeName = "NUMBER")]
    public decimal Seq { get; set; }

    [Column("TYPE", TypeName = "NUMBER")]
    public decimal Type { get; set; }

    [Column("INFOLEN", TypeName = "NUMBER")]
    public decimal Infolen { get; set; }

    [Column("INFO", TypeName = "LONG RAW")]
    public byte[]? Info { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal? Status { get; set; }

    [Column("FLAG", TypeName = "NUMBER")]
    public decimal? Flag { get; set; }

    [ForeignKey("Runid")]
    [InverseProperty("MviewAdvInfos")]
    public virtual MviewAdvLog Run { get; set; } = null!;
}
