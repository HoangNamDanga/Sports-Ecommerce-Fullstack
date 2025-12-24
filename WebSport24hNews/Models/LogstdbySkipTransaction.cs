using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGSTDBY$SKIP_TRANSACTION")]
public partial class LogstdbySkipTransaction  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("XIDUSN", TypeName = "NUMBER")]
    public decimal? Xidusn { get; set; }

    [Column("XIDSLT", TypeName = "NUMBER")]
    public decimal? Xidslt { get; set; }

    [Column("XIDSQN", TypeName = "NUMBER")]
    public decimal? Xidsqn { get; set; }

    [Column("ACTIVE", TypeName = "NUMBER")]
    public decimal? Active { get; set; }

    [Column("COMMIT_SCN", TypeName = "NUMBER")]
    public decimal? CommitScn { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare3 { get; set; }

    [Column("CON_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? ConName { get; set; }
}
