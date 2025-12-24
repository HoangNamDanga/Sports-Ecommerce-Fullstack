using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
public partial class MviewWorkload  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("WORKLOADID", TypeName = "NUMBER")]
    public decimal Workloadid { get; set; }

    [Column("IMPORT_TIME", TypeName = "DATE")]
    public DateTime ImportTime { get; set; }

    [Column("QUERYID", TypeName = "NUMBER")]
    public decimal Queryid { get; set; }

    [Column("APPLICATION")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Application { get; set; }

    [Column("CARDINALITY", TypeName = "NUMBER")]
    public decimal? Cardinality { get; set; }

    [Column("RESULTSIZE", TypeName = "NUMBER")]
    public decimal? Resultsize { get; set; }

    [Column("LASTUSE", TypeName = "DATE")]
    public DateTime? Lastuse { get; set; }

    [Column("FREQUENCY", TypeName = "NUMBER")]
    public decimal? Frequency { get; set; }

    [Column("OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string Owner { get; set; } = null!;

    [Column("PRIORITY", TypeName = "NUMBER")]
    public decimal? Priority { get; set; }

    [Column("QUERY", TypeName = "LONG")]
    public string Query { get; set; } = null!;

    [Column("RESPONSETIME", TypeName = "NUMBER")]
    public decimal? Responsetime { get; set; }
}
