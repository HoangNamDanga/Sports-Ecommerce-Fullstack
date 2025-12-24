using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
public partial class SchedulerJobArgs  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Owner { get; set; }

    [Column("JOB_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? JobName { get; set; }

    [Column("ARGUMENT_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? ArgumentName { get; set; }

    [Column("ARGUMENT_POSITION", TypeName = "NUMBER")]
    public decimal? ArgumentPosition { get; set; }

    [Column("ARGUMENT_TYPE")]
    [StringLength(257)]
    [Unicode(false)]
    public string? ArgumentType { get; set; }

    [Column("VALUE")]
    [Unicode(false)]
    public string? Value { get; set; }

    [Column("OUT_ARGUMENT")]
    [StringLength(5)]
    [Unicode(false)]
    public string? OutArgument { get; set; }
}
