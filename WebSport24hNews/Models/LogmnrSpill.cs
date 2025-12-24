using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Session", "Pdbid", "Xidusn", "Xidslt", "Xidsqn", "Chunk", "Startidx", "Endidx", "Flag", "Sequence")]
[Table("LOGMNR_SPILL$")]
public partial class LogmnrSpill  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
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
    [Column("CHUNK", TypeName = "NUMBER")]
    public decimal Chunk { get; set; }

    [Key]
    [Column("STARTIDX", TypeName = "NUMBER")]
    public decimal Startidx { get; set; }

    [Key]
    [Column("ENDIDX", TypeName = "NUMBER")]
    public decimal Endidx { get; set; }

    [Key]
    [Column("FLAG", TypeName = "NUMBER")]
    public decimal Flag { get; set; }

    [Key]
    [Column("SEQUENCE#", TypeName = "NUMBER")]
    public decimal Sequence { get; set; }

    [Column("SPILL_DATA", TypeName = "BLOB")]
    public byte[]? SpillData { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Key]
    [Column("PDBID", TypeName = "NUMBER")]
    public decimal Pdbid { get; set; }
}
