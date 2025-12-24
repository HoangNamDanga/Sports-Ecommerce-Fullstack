using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Anchor-join graph representation
/// </summary>
[Table("MVIEW$_ADV_AJG")]
public partial class MviewAdvAjg  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("AJGID#", TypeName = "NUMBER")]
    public decimal Ajgid { get; set; }

    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Column("AJGDESLEN", TypeName = "NUMBER")]
    public decimal Ajgdeslen { get; set; }

    [Column("AJGDES", TypeName = "LONG RAW")]
    public byte[] Ajgdes { get; set; } = null!;

    [Column("HASHVALUE", TypeName = "NUMBER")]
    public decimal Hashvalue { get; set; }

    [Column("FREQUENCY", TypeName = "NUMBER")]
    public decimal? Frequency { get; set; }

    [InverseProperty("Ajg")]
    public virtual ICollection<MviewAdvFjg> MviewAdvFjgs { get; set; } = new List<MviewAdvFjg>();

    [ForeignKey("Runid")]
    [InverseProperty("MviewAdvAjgs")]
    public virtual MviewAdvLog Run { get; set; } = null!;
}
