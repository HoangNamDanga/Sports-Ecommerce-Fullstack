using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("SQLPLUS_PRODUCT_PROFILE")]
public partial class SqlplusProductProfile  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("PRODUCT")]
    [StringLength(30)]
    [Unicode(false)]
    public string Product { get; set; } = null!;

    [Column("USERID")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Userid { get; set; }

    [Column("ATTRIBUTE")]
    [StringLength(240)]
    [Unicode(false)]
    public string? Attribute { get; set; }

    [Column("SCOPE")]
    [StringLength(240)]
    [Unicode(false)]
    public string? Scope { get; set; }

    [Column("NUMERIC_VALUE", TypeName = "NUMBER(15,2)")]
    public decimal? NumericValue { get; set; }

    [Column("CHAR_VALUE")]
    [StringLength(240)]
    [Unicode(false)]
    public string? CharValue { get; set; }

    [Column("DATE_VALUE", TypeName = "DATE")]
    public DateTime? DateValue { get; set; }

    [Column("LONG_VALUE", TypeName = "LONG")]
    public string? LongValue { get; set; }
}
