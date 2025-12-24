using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Table for storing canonical form of Clique queries
/// </summary>
[Table("MVIEW$_ADV_CLIQUE")]
public partial class MviewAdvClique  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("CLIQUEID#", TypeName = "NUMBER")]
    public decimal Cliqueid { get; set; }

    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Column("CLIQUEDESLEN", TypeName = "NUMBER")]
    public decimal Cliquedeslen { get; set; }

    [Column("CLIQUEDES", TypeName = "LONG RAW")]
    public byte[] Cliquedes { get; set; } = null!;

    [Column("HASHVALUE", TypeName = "NUMBER")]
    public decimal Hashvalue { get; set; }

    [Column("FREQUENCY", TypeName = "NUMBER")]
    public decimal Frequency { get; set; }

    [Column("BYTECOST", TypeName = "NUMBER")]
    public decimal Bytecost { get; set; }

    [Column("ROWSIZE", TypeName = "NUMBER")]
    public decimal Rowsize { get; set; }

    [Column("NUMROWS", TypeName = "NUMBER")]
    public decimal Numrows { get; set; }

    [ForeignKey("Runid")]
    [InverseProperty("MviewAdvCliques")]
    public virtual MviewAdvLog Run { get; set; } = null!;
}
