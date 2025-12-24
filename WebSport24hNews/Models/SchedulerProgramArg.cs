using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
public partial class SchedulerProgramArg  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string Owner { get; set; } = null!;

    [Column("PROGRAM_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string ProgramName { get; set; } = null!;

    [Column("ARGUMENT_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? ArgumentName { get; set; }

    [Column("ARGUMENT_POSITION", TypeName = "NUMBER")]
    public decimal ArgumentPosition { get; set; }

    [Column("ARGUMENT_TYPE")]
    [StringLength(257)]
    [Unicode(false)]
    public string? ArgumentType { get; set; }

    [Column("METADATA_ATTRIBUTE")]
    [StringLength(19)]
    [Unicode(false)]
    public string? MetadataAttribute { get; set; }

    [Column("DEFAULT_VALUE")]
    [Unicode(false)]
    public string? DefaultValue { get; set; }

    [Column("OUT_ARGUMENT")]
    [StringLength(5)]
    [Unicode(false)]
    public string? OutArgument { get; set; }
}
