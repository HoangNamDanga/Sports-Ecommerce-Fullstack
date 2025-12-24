using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Name")]
[Table("LOGMNR_PROPS$")]
[Index("LogmnrUid", "Name", Name = "LOGMNR_I1PROPS$")]
public partial class LogmnrProp  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("VALUE$")]
    [Unicode(false)]
    public string? Value { get; set; }

    [Column("COMMENT$")]
    [Unicode(false)]
    public string? Comment { get; set; }

    [Key]
    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
