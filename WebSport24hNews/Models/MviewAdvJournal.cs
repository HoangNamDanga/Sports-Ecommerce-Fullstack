using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Summary advisor journal table for debugging and information
/// </summary>
[PrimaryKey("Runid", "Seq")]
[Table("MVIEW$_ADV_JOURNAL")]
public partial class MviewAdvJournal  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("RUNID#", TypeName = "NUMBER")]
    public decimal Runid { get; set; }

    [Key]
    [Column("SEQ#", TypeName = "NUMBER")]
    public decimal Seq { get; set; }

    [Column("TIMESTAMP", TypeName = "DATE")]
    public DateTime Timestamp { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal Flags { get; set; }

    [Column("NUM", TypeName = "NUMBER")]
    public decimal? Num { get; set; }

    [Column("TEXT", TypeName = "LONG")]
    public string? Text { get; set; }

    [Column("TEXTLEN", TypeName = "NUMBER")]
    public decimal? Textlen { get; set; }

    [ForeignKey("Runid")]
    [InverseProperty("MviewAdvJournals")]
    public virtual MviewAdvLog Run { get; set; } = null!;
}
