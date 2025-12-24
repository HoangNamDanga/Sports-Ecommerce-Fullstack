using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("LOGMNR_DICTSTATE$")]
public partial class LogmnrDictstate  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("START_SCNBAS", TypeName = "NUMBER")]
    public decimal? StartScnbas { get; set; }

    [Column("START_SCNWRP", TypeName = "NUMBER")]
    public decimal? StartScnwrp { get; set; }

    [Column("END_SCNBAS", TypeName = "NUMBER")]
    public decimal? EndScnbas { get; set; }

    [Column("END_SCNWRP", TypeName = "NUMBER")]
    public decimal? EndScnwrp { get; set; }

    [Column("REDO_THREAD", TypeName = "NUMBER")]
    public decimal? RedoThread { get; set; }

    [Column("RBASQN", TypeName = "NUMBER")]
    public decimal? Rbasqn { get; set; }

    [Column("RBABLK", TypeName = "NUMBER")]
    public decimal? Rbablk { get; set; }

    [Column("RBABYTE", TypeName = "NUMBER")]
    public decimal? Rbabyte { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
