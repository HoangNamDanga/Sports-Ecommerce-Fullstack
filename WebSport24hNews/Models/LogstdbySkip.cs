using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGSTDBY$SKIP")]
[Index("UseLike", "Schema", "Name", Name = "LOGSTDBY$SKIP_IDX1")]
[Index("StatementOpt", Name = "LOGSTDBY$SKIP_IDX2")]
public partial class LogstdbySkip  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("ERROR", TypeName = "NUMBER")]
    public decimal? Error { get; set; }

    [Column("STATEMENT_OPT")]
    [StringLength(128)]
    [Unicode(false)]
    public string? StatementOpt { get; set; }

    [Column("SCHEMA")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Schema { get; set; }

    [Column("NAME")]
    [StringLength(261)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("USE_LIKE", TypeName = "NUMBER")]
    public decimal? UseLike { get; set; }

    [Column("ESC")]
    [StringLength(1)]
    [Unicode(false)]
    public string? Esc { get; set; }

    [Column("PROC")]
    [StringLength(392)]
    [Unicode(false)]
    public string? Proc { get; set; }

    [Column("ACTIVE", TypeName = "NUMBER")]
    public decimal? Active { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
