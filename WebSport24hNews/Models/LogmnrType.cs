using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Toid", "Version")]
[Table("LOGMNR_TYPE$")]
[Index("LogmnrUid", "Toid", "Version", Name = "LOGMNR_I1TYPE$")]
public partial class LogmnrType  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("VERSION#", TypeName = "NUMBER")]
    public decimal? Version { get; set; }

    [Column("VERSION")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Version1 { get; set; }

    [Column("TVOID")]
    public Guid? Tvoid { get; set; }

    [Column("TYPECODE", TypeName = "NUMBER")]
    public decimal? Typecode { get; set; }

    [Column("PROPERTIES", TypeName = "NUMBER")]
    public decimal? Properties { get; set; }

    [Column("ATTRIBUTES", TypeName = "NUMBER")]
    public decimal? Attributes { get; set; }

    [Column("METHODS", TypeName = "NUMBER")]
    public decimal? Methods { get; set; }

    [Column("HIDDENMETHODS", TypeName = "NUMBER")]
    public decimal? Hiddenmethods { get; set; }

    [Column("SUPERTYPES", TypeName = "NUMBER")]
    public decimal? Supertypes { get; set; }

    [Column("SUBTYPES", TypeName = "NUMBER")]
    public decimal? Subtypes { get; set; }

    [Column("EXTERNTYPE", TypeName = "NUMBER")]
    public decimal? Externtype { get; set; }

    [Column("EXTERNNAME")]
    [Unicode(false)]
    public string? Externname { get; set; }

    [Column("HELPERCLASSNAME")]
    [Unicode(false)]
    public string? Helperclassname { get; set; }

    [Column("LOCAL_ATTRS", TypeName = "NUMBER")]
    public decimal? LocalAttrs { get; set; }

    [Column("LOCAL_METHODS", TypeName = "NUMBER")]
    public decimal? LocalMethods { get; set; }

    [Column("TYPEID")]
    public Guid? Typeid { get; set; }

    [Column("ROOTTOID")]
    public Guid? Roottoid { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SUPERTOID")]
    public Guid? Supertoid { get; set; }

    [Column("HASHCODE")]
    [MaxLength(17)]
    public byte[]? Hashcode { get; set; }

    [Key]
    [Column("TOID")]
    public Guid Toid { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
