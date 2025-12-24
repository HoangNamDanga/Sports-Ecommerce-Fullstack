using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Baseobjv", "Keyobj")]
[Table("LOGMNRP_CTAS_PART_MAP")]
[Index("LogmnrUid", "Baseobj", "Baseobjv", "Part", Name = "LOGMNRP_CTAS_PART_MAP_I")]
public partial class LogmnrpCtasPartMap  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Column("BASEOBJ#", TypeName = "NUMBER")]
    public decimal Baseobj { get; set; }

    [Key]
    [Column("BASEOBJV#", TypeName = "NUMBER")]
    public decimal Baseobjv { get; set; }

    [Key]
    [Column("KEYOBJ#", TypeName = "NUMBER")]
    public decimal Keyobj { get; set; }

    [Column("PART#", TypeName = "NUMBER")]
    public decimal Part { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
