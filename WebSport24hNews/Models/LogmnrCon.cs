using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Con")]
[Table("LOGMNR_CON$")]
[Index("LogmnrUid", "Con", Name = "LOGMNR_I1CON$")]
public partial class LogmnrCon  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("OWNER#", TypeName = "NUMBER")]
    public decimal Owner { get; set; }

    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Key]
    [Column("CON#", TypeName = "NUMBER")]
    public decimal Con { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }

    [Column("START_SCNBAS", TypeName = "NUMBER")]
    public decimal? StartScnbas { get; set; }

    [Column("START_SCNWRP", TypeName = "NUMBER")]
    public decimal? StartScnwrp { get; set; }
}
