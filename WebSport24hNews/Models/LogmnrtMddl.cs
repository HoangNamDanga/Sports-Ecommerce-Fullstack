using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("SourceObj", "SourceRowid")]
[Table("LOGMNRT_MDDL$")]
public partial class LogmnrtMddl  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("SOURCE_OBJ#", TypeName = "NUMBER")]
    public decimal SourceObj { get; set; }

    [Key]
    [Column("SOURCE_ROWID", TypeName = "ROWID")]
    public string SourceRowid { get; set; } = null!;

    [Column("DEST_ROWID", TypeName = "ROWID")]
    public string DestRowid { get; set; } = null!;
}
