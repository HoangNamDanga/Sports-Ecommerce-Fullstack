using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Session", "CkptScn", "Xidusn", "Xidslt", "Xidsqn", "Pdbid", "SessionNum", "SerialNum")]
[Table("LOGMNR_RESTART_CKPT$")]
public partial class LogmnrRestartCkpt  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal Session { get; set; }

    [Column("VALID", TypeName = "NUMBER")]
    public decimal? Valid { get; set; }

    [Key]
    [Column("CKPT_SCN", TypeName = "NUMBER")]
    public decimal CkptScn { get; set; }

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

    [Column("CKPT_INFO", TypeName = "BLOB")]
    public byte[]? CkptInfo { get; set; }

    [Column("FLAG", TypeName = "NUMBER")]
    public decimal? Flag { get; set; }

    [Column("OFFSET", TypeName = "NUMBER")]
    public decimal? Offset { get; set; }

    [Column("CLIENT_DATA", TypeName = "BLOB")]
    public byte[]? ClientData { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Key]
    [Column("PDBID", TypeName = "NUMBER")]
    public decimal Pdbid { get; set; }
}
