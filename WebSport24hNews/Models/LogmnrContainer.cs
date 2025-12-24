using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj")]
[Table("LOGMNR_CONTAINER$")]
[Index("LogmnrUid", "ConId", Name = "LOGMNR_I1CONTAINER$")]
public partial class LogmnrContainer  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Column("CON_ID#", TypeName = "NUMBER")]
    public decimal ConId { get; set; }

    [Column("DBID", TypeName = "NUMBER")]
    public decimal Dbid { get; set; }

    [Column("CON_UID", TypeName = "NUMBER")]
    public decimal ConUid { get; set; }

    [Column("CREATE_SCNWRP", TypeName = "NUMBER")]
    public decimal CreateScnwrp { get; set; }

    [Column("CREATE_SCNBAS", TypeName = "NUMBER")]
    public decimal CreateScnbas { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal Status { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }

    [Column("VSN", TypeName = "NUMBER")]
    public decimal? Vsn { get; set; }

    [Column("FED_ROOT_CON_ID#", TypeName = "NUMBER")]
    public decimal? FedRootConId { get; set; }
}
