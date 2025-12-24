using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Group-by columns of a query
/// </summary>
[Table("MVIEW$_ADV_GC")]
public partial class MviewAdvGc  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("GCID#", TypeName = "NUMBER")]
    public decimal Gcid { get; set; }

    [Column("FJGID#", TypeName = "NUMBER")]
    public decimal Fjgid { get; set; }

    [Column("GCDESLEN", TypeName = "NUMBER")]
    public decimal Gcdeslen { get; set; }

    [Column("GCDES", TypeName = "LONG RAW")]
    public byte[] Gcdes { get; set; } = null!;

    [Column("HASHVALUE", TypeName = "NUMBER")]
    public decimal Hashvalue { get; set; }

    [Column("FREQUENCY", TypeName = "NUMBER")]
    public decimal? Frequency { get; set; }

    [ForeignKey("Fjgid")]
    [InverseProperty("MviewAdvGcs")]
    public virtual MviewAdvFjg Fjg { get; set; } = null!;
}
