using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj")]
[Table("LOGMNR_OBJ$")]
[Index("LogmnrUid", "Obj", Name = "LOGMNR_I1OBJ$")]
[Index("LogmnrUid", "Oid", Name = "LOGMNR_I2OBJ$")]
[Index("LogmnrUid", "Name", Name = "LOGMNR_I3OBJ$")]
public partial class LogmnrObj  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("OBJV#", TypeName = "NUMBER(22)")]
    public decimal? Objv { get; set; }

    [Column("OWNER#", TypeName = "NUMBER(22)")]
    public decimal? Owner { get; set; }

    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("NAMESPACE", TypeName = "NUMBER(22)")]
    public decimal? Namespace { get; set; }

    [Column("SUBNAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Subname { get; set; }

    [Column("TYPE#", TypeName = "NUMBER(22)")]
    public decimal? Type { get; set; }

    [Column("OID$")]
    public Guid? Oid { get; set; }

    [Column("REMOTEOWNER")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Remoteowner { get; set; }

    [Column("LINKNAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Linkname { get; set; }

    [Column("FLAGS", TypeName = "NUMBER(22)")]
    public decimal? Flags { get; set; }

    [Column("SPARE3", TypeName = "NUMBER(22)")]
    public decimal? Spare3 { get; set; }

    [Column("STIME", TypeName = "DATE")]
    public DateTime? Stime { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER(22)")]
    public decimal Obj { get; set; }

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
