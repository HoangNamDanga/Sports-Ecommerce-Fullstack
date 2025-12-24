using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Intcol")]
[Table("LOGMNR_SEED$")]
[Index("LogmnrUid", "Obj", "Intcol", Name = "LOGMNR_I1SEED$")]
[Index("LogmnrUid", "Schemaname", "TableName", "ColName", "Obj", "Intcol", Name = "LOGMNR_I2SEED$")]
public partial class LogmnrSeed  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SEED_VERSION", TypeName = "NUMBER(22)")]
    public decimal? SeedVersion { get; set; }

    [Column("GATHER_VERSION", TypeName = "NUMBER(22)")]
    public decimal? GatherVersion { get; set; }

    [Column("SCHEMANAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Schemaname { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal? Obj { get; set; }

    [Column("OBJV#", TypeName = "NUMBER(22)")]
    public decimal? Objv { get; set; }

    [Column("TABLE_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? TableName { get; set; }

    [Column("COL_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? ColName { get; set; }

    [Column("COL#", TypeName = "NUMBER")]
    public decimal? Col { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal? Intcol { get; set; }

    [Column("SEGCOL#", TypeName = "NUMBER")]
    public decimal? Segcol { get; set; }

    [Column("TYPE#", TypeName = "NUMBER")]
    public decimal? Type { get; set; }

    [Column("LENGTH", TypeName = "NUMBER")]
    public decimal? Length { get; set; }

    [Column("PRECISION#", TypeName = "NUMBER")]
    public decimal? Precision { get; set; }

    [Column("SCALE", TypeName = "NUMBER")]
    public decimal? Scale { get; set; }

    [Column("NULL$", TypeName = "NUMBER")]
    public decimal Null { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
