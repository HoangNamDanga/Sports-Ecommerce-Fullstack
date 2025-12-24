using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Toid", "Version", "Attribute")]
[Table("LOGMNR_ATTRIBUTE$")]
[Index("LogmnrUid", "Toid", "Version", "Attribute", Name = "LOGMNR_I1ATTRIBUTE$")]
public partial class LogmnrAttribute  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("VERSION#", TypeName = "NUMBER")]
    public decimal? Version { get; set; }

    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Key]
    [Column("ATTRIBUTE#", TypeName = "NUMBER")]
    public decimal? Attribute { get; set; }

    [Column("ATTR_TOID")]
    public Guid? AttrToid { get; set; }

    [Column("ATTR_VERSION#", TypeName = "NUMBER")]
    public decimal? AttrVersion { get; set; }

    [Column("SYNOBJ#", TypeName = "NUMBER")]
    public decimal? Synobj { get; set; }

    [Column("PROPERTIES", TypeName = "NUMBER")]
    public decimal? Properties { get; set; }

    [Column("CHARSETID", TypeName = "NUMBER")]
    public decimal? Charsetid { get; set; }

    [Column("CHARSETFORM", TypeName = "NUMBER")]
    public decimal? Charsetform { get; set; }

    [Column("LENGTH", TypeName = "NUMBER")]
    public decimal? Length { get; set; }

    [Column("PRECISION#", TypeName = "NUMBER")]
    public decimal? Precision { get; set; }

    [Column("SCALE", TypeName = "NUMBER")]
    public decimal? Scale { get; set; }

    [Column("EXTERNNAME")]
    [Unicode(false)]
    public string? Externname { get; set; }

    [Column("XFLAGS", TypeName = "NUMBER")]
    public decimal? Xflags { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SPARE4", TypeName = "NUMBER")]
    public decimal? Spare4 { get; set; }

    [Column("SPARE5", TypeName = "NUMBER")]
    public decimal? Spare5 { get; set; }

    [Column("SETTER", TypeName = "NUMBER")]
    public decimal? Setter { get; set; }

    [Column("GETTER", TypeName = "NUMBER")]
    public decimal? Getter { get; set; }

    [Key]
    [Column("TOID")]
    public Guid Toid { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
