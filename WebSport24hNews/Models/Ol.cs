using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("OL$")]
[Index("OlName", Name = "OL$NAME", IsUnique = true)]
[Index("Signature", "Category", Name = "OL$SIGNATURE", IsUnique = true)]
public partial class Ol  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("OL_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? OlName { get; set; }

    [Column("SQL_TEXT", TypeName = "LONG")]
    public string? SqlText { get; set; }

    [Column("TEXTLEN", TypeName = "NUMBER")]
    public decimal? Textlen { get; set; }

    [Column("SIGNATURE")]
    public Guid? Signature { get; set; }

    [Column("HASH_VALUE", TypeName = "NUMBER")]
    public decimal? HashValue { get; set; }

    [Column("HASH_VALUE2", TypeName = "NUMBER")]
    public decimal? HashValue2 { get; set; }

    [Column("CATEGORY")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Category { get; set; }

    [Column("VERSION")]
    [StringLength(64)]
    [Unicode(false)]
    public string? Version { get; set; }

    [Column("CREATOR")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Creator { get; set; }

    [Column("TIMESTAMP", TypeName = "DATE")]
    public DateTime? Timestamp { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("HINTCOUNT", TypeName = "NUMBER")]
    public decimal? Hintcount { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? Spare2 { get; set; }
}
