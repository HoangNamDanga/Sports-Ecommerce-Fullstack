using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Owner")]
[Table("LOGMNR_ENC$")]
[Index("LogmnrUid", "Obj", "Owner", Name = "LOGMNR_I1ENC$")]
public partial class LogmnrEnc  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal? Obj { get; set; }

    [Key]
    [Column("OWNER#", TypeName = "NUMBER")]
    public decimal? Owner { get; set; }

    [Column("ENCALG", TypeName = "NUMBER")]
    public decimal? Encalg { get; set; }

    [Column("INTALG", TypeName = "NUMBER")]
    public decimal? Intalg { get; set; }

    [Column("COLKLC")]
    public byte[]? Colklc { get; set; }

    [Column("KLCLEN", TypeName = "NUMBER")]
    public decimal? Klclen { get; set; }

    [Column("FLAG", TypeName = "NUMBER")]
    public decimal? Flag { get; set; }

    [Column("MKEYID")]
    [StringLength(192)]
    [Unicode(false)]
    public string Mkeyid { get; set; } = null!;

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
