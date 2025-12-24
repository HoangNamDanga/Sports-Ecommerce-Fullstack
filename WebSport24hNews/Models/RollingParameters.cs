using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("ROLLING$PARAMETERS")]
public partial class RollingParameters  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SCOPE", TypeName = "NUMBER")]
    public decimal? Scope { get; set; }

    [Column("NAME")]
    [StringLength(32)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("ID", TypeName = "NUMBER")]
    public decimal? Id { get; set; }

    [Column("DESCRIP")]
    [StringLength(256)]
    [Unicode(false)]
    public string? Descrip { get; set; }

    [Column("TYPE", TypeName = "NUMBER")]
    public decimal? Type { get; set; }

    [Column("DATATYPE", TypeName = "NUMBER")]
    public decimal? Datatype { get; set; }

    [Column("ATTRIBUTES", TypeName = "NUMBER")]
    public decimal? Attributes { get; set; }

    [Column("CURVAL")]
    [StringLength(1024)]
    [Unicode(false)]
    public string? Curval { get; set; }

    [Column("LSTVAL")]
    [StringLength(1024)]
    [Unicode(false)]
    public string? Lstval { get; set; }

    [Column("DEFVAL")]
    [StringLength(1024)]
    [Unicode(false)]
    public string? Defval { get; set; }

    [Column("MINVAL", TypeName = "NUMBER")]
    public decimal? Minval { get; set; }

    [Column("MAXVAL", TypeName = "NUMBER")]
    public decimal? Maxval { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
