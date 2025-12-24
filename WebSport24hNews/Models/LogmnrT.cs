using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Ts")]
[Table("LOGMNR_TS$")]
[Index("LogmnrUid", "Ts", Name = "LOGMNR_I1TS$")]
public partial class LogmnrT  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("TS#", TypeName = "NUMBER(22)")]
    public decimal? Ts { get; set; }

    [Column("NAME")]
    [StringLength(90)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("OWNER#", TypeName = "NUMBER(22)")]
    public decimal? Owner { get; set; }

    [Column("BLOCKSIZE", TypeName = "NUMBER(22)")]
    public decimal Blocksize { get; set; }

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
