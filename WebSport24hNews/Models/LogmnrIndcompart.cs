using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj")]
[Table("LOGMNR_INDCOMPART$")]
[Index("LogmnrUid", "Obj", Name = "LOGMNR_I1INDCOMPART$")]
public partial class LogmnrIndcompart  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal? Obj { get; set; }

    [Column("DATAOBJ#", TypeName = "NUMBER")]
    public decimal? Dataobj { get; set; }

    [Column("BO#", TypeName = "NUMBER")]
    public decimal? Bo { get; set; }

    [Column("PART#", TypeName = "NUMBER")]
    public decimal Part { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
