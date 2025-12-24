using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj")]
[Table("LOGMNRC_GSII")]
public partial class LogmnrcGsii  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Column("BO#", TypeName = "NUMBER")]
    public decimal Bo { get; set; }

    [Column("INDTYPE#", TypeName = "NUMBER")]
    public decimal Indtype { get; set; }

    [Column("DROP_SCN", TypeName = "NUMBER")]
    public decimal? DropScn { get; set; }

    [Column("LOGMNR_SPARE1", TypeName = "NUMBER")]
    public decimal? LogmnrSpare1 { get; set; }

    [Column("LOGMNR_SPARE2", TypeName = "NUMBER")]
    public decimal? LogmnrSpare2 { get; set; }

    [Column("LOGMNR_SPARE3")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? LogmnrSpare3 { get; set; }

    [Column("LOGMNR_SPARE4", TypeName = "DATE")]
    public DateTime? LogmnrSpare4 { get; set; }
}
