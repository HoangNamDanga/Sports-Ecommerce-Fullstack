using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj")]
[Table("LOGMNR_TABCOMPART$")]
[Index("LogmnrUid", "Obj", Name = "LOGMNR_I1TABCOMPART$")]
[Index("LogmnrUid", "Bo", Name = "LOGMNR_I2TABCOMPART$")]
public partial class LogmnrTabcompart  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OBJ#", TypeName = "NUMBER(22)")]
    public decimal? Obj { get; set; }

    [Column("BO#", TypeName = "NUMBER(22)")]
    public decimal? Bo { get; set; }

    [Column("PART#", TypeName = "NUMBER(22)")]
    public decimal Part { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
