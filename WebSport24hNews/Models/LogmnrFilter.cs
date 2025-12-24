using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGMNR_FILTER$")]
public partial class LogmnrFilter  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal? Session { get; set; }

    [Column("FILTER_TYPE")]
    [StringLength(30)]
    [Unicode(false)]
    public string? FilterType { get; set; }

    [Column("ATTR1", TypeName = "NUMBER")]
    public decimal? Attr1 { get; set; }

    [Column("ATTR2", TypeName = "NUMBER")]
    public decimal? Attr2 { get; set; }

    [Column("ATTR3", TypeName = "NUMBER")]
    public decimal? Attr3 { get; set; }

    [Column("ATTR4", TypeName = "NUMBER")]
    public decimal? Attr4 { get; set; }

    [Column("ATTR5", TypeName = "NUMBER")]
    public decimal? Attr5 { get; set; }

    [Column("ATTR6", TypeName = "NUMBER")]
    public decimal? Attr6 { get; set; }

    [Column("FILTER_SCN", TypeName = "NUMBER")]
    public decimal? FilterScn { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "DATE")]
    public DateTime? Spare3 { get; set; }

    [Column("ATTR7")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Attr7 { get; set; }

    [Column("ATTR8")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Attr8 { get; set; }

    [Column("ATTR9")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Attr9 { get; set; }

    [Column("ATTR10")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Attr10 { get; set; }

    [Column("ATTR11")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Attr11 { get; set; }
}
