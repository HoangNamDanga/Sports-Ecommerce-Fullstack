using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj")]
[Table("LOGMNR_PARTOBJ$")]
[Index("LogmnrUid", "Obj", Name = "LOGMNR_I1PARTOBJ$")]
public partial class LogmnrPartobj  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("PARTTYPE", TypeName = "NUMBER")]
    public decimal? Parttype { get; set; }

    [Column("PARTCNT", TypeName = "NUMBER")]
    public decimal? Partcnt { get; set; }

    [Column("PARTKEYCOLS", TypeName = "NUMBER")]
    public decimal? Partkeycols { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("DEFTS#", TypeName = "NUMBER")]
    public decimal? Defts { get; set; }

    [Column("DEFPCTFREE", TypeName = "NUMBER")]
    public decimal? Defpctfree { get; set; }

    [Column("DEFPCTUSED", TypeName = "NUMBER")]
    public decimal? Defpctused { get; set; }

    [Column("DEFPCTTHRES", TypeName = "NUMBER")]
    public decimal? Defpctthres { get; set; }

    [Column("DEFINITRANS", TypeName = "NUMBER")]
    public decimal? Definitrans { get; set; }

    [Column("DEFMAXTRANS", TypeName = "NUMBER")]
    public decimal? Defmaxtrans { get; set; }

    [Column("DEFTINIEXTS", TypeName = "NUMBER")]
    public decimal? Deftiniexts { get; set; }

    [Column("DEFEXTSIZE", TypeName = "NUMBER")]
    public decimal? Defextsize { get; set; }

    [Column("DEFMINEXTS", TypeName = "NUMBER")]
    public decimal? Defminexts { get; set; }

    [Column("DEFMAXEXTS", TypeName = "NUMBER")]
    public decimal? Defmaxexts { get; set; }

    [Column("DEFEXTPCT", TypeName = "NUMBER")]
    public decimal? Defextpct { get; set; }

    [Column("DEFLISTS", TypeName = "NUMBER")]
    public decimal? Deflists { get; set; }

    [Column("DEFGROUPS", TypeName = "NUMBER")]
    public decimal? Defgroups { get; set; }

    [Column("DEFLOGGING", TypeName = "NUMBER")]
    public decimal? Deflogging { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("DEFINCLCOL", TypeName = "NUMBER")]
    public decimal? Definclcol { get; set; }

    [Column("PARAMETERS")]
    [StringLength(3000)]
    [Unicode(false)]
    public string? Parameters { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
