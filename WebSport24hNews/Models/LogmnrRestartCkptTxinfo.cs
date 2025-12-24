using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Session", "Xidusn", "Xidslt", "Xidsqn", "SessionNum", "SerialNum", "EffectiveScn")]
[Table("LOGMNR_RESTART_CKPT_TXINFO$")]
public partial class LogmnrRestartCkptTxinfo  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal Session { get; set; }

    [Key]
    [Column("XIDUSN", TypeName = "NUMBER")]
    public decimal Xidusn { get; set; }

    [Key]
    [Column("XIDSLT", TypeName = "NUMBER")]
    public decimal Xidslt { get; set; }

    [Key]
    [Column("XIDSQN", TypeName = "NUMBER")]
    public decimal Xidsqn { get; set; }

    [Key]
    [Column("SESSION_NUM", TypeName = "NUMBER")]
    public decimal SessionNum { get; set; }

    [Key]
    [Column("SERIAL_NUM", TypeName = "NUMBER")]
    public decimal SerialNum { get; set; }

    [Column("FLAG", TypeName = "NUMBER")]
    public decimal? Flag { get; set; }

    [Column("START_SCN", TypeName = "NUMBER")]
    public decimal? StartScn { get; set; }

    [Key]
    [Column("EFFECTIVE_SCN", TypeName = "NUMBER")]
    public decimal EffectiveScn { get; set; }

    [Column("OFFSET", TypeName = "NUMBER")]
    public decimal? Offset { get; set; }

    [Column("TX_DATA", TypeName = "BLOB")]
    public byte[]? TxData { get; set; }
}
