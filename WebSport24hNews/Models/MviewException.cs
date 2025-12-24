using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
public partial class MviewException  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("RUNID", TypeName = "NUMBER")]
    public decimal? Runid { get; set; }

    [Column("OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Owner { get; set; }

    [Column("TABLE_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? TableName { get; set; }

    [Column("DIMENSION_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? DimensionName { get; set; }

    [Column("RELATIONSHIP")]
    [StringLength(11)]
    [Unicode(false)]
    public string? Relationship { get; set; }

    [Column("BAD_ROWID", TypeName = "ROWID")]
    public string? BadRowid { get; set; }
}
