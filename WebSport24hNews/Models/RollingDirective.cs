using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("ROLLING$DIRECTIVES")]
public partial class RollingDirective  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("DIRECTID", TypeName = "NUMBER")]
    public decimal? Directid { get; set; }

    [Column("PHASE", TypeName = "NUMBER")]
    public decimal? Phase { get; set; }

    [Column("TASKID", TypeName = "NUMBER")]
    public decimal? Taskid { get; set; }

    [Column("FEATURE")]
    [StringLength(32)]
    [Unicode(false)]
    public string? Feature { get; set; }

    [Column("DESCRIPTION")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("TARGET", TypeName = "NUMBER")]
    public decimal? Target { get; set; }

    [Column("FLAGS")]
    [StringLength(64)]
    [Unicode(false)]
    public string? Flags { get; set; }

    [Column("OPCODE", TypeName = "NUMBER")]
    public decimal? Opcode { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? P1 { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? P2 { get; set; }

    [StringLength(256)]
    [Unicode(false)]
    public string? P3 { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
