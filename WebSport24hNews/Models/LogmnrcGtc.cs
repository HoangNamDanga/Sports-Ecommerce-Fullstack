using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "Objv", "Intcol")]
[Table("LOGMNRC_GTCS")]
[Index("LogmnrUid", "Obj", "Objv", "Segcol", "Intcol", Name = "LOGMNRC_I2GTCS")]
public partial class LogmnrcGtc  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("OBJV#", TypeName = "NUMBER")]
    public decimal Objv { get; set; }

    [Column("SEGCOL#", TypeName = "NUMBER")]
    public decimal Segcol { get; set; }

    [Key]
    [Column("INTCOL#", TypeName = "NUMBER")]
    public decimal Intcol { get; set; }

    [Column("COLNAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Colname { get; set; } = null!;

    [Column("TYPE#", TypeName = "NUMBER")]
    public decimal Type { get; set; }

    [Column("LENGTH", TypeName = "NUMBER")]
    public decimal? Length { get; set; }

    [Column("PRECISION", TypeName = "NUMBER")]
    public decimal? Precision { get; set; }

    [Column("SCALE", TypeName = "NUMBER")]
    public decimal? Scale { get; set; }

    [Column("INTERVAL_LEADING_PRECISION", TypeName = "NUMBER")]
    public decimal? IntervalLeadingPrecision { get; set; }

    [Column("INTERVAL_TRAILING_PRECISION", TypeName = "NUMBER")]
    public decimal? IntervalTrailingPrecision { get; set; }

    [Column("PROPERTY", TypeName = "NUMBER")]
    public decimal? Property { get; set; }

    [Column("TOID")]
    public Guid? Toid { get; set; }

    [Column("CHARSETID", TypeName = "NUMBER")]
    public decimal? Charsetid { get; set; }

    [Column("CHARSETFORM", TypeName = "NUMBER")]
    public decimal? Charsetform { get; set; }

    [Column("TYPENAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Typename { get; set; }

    [Column("FQCOLNAME")]
    [Unicode(false)]
    public string? Fqcolname { get; set; }

    [Column("NUMINTCOLS", TypeName = "NUMBER")]
    public decimal? Numintcols { get; set; }

    [Column("NUMATTRS", TypeName = "NUMBER")]
    public decimal? Numattrs { get; set; }

    [Column("ADTORDER", TypeName = "NUMBER")]
    public decimal? Adtorder { get; set; }

    [Column("LOGMNR_SPARE1", TypeName = "NUMBER")]
    public decimal? LogmnrSpare1 { get; set; }

    [Column("LOGMNR_SPARE2", TypeName = "NUMBER")]
    public decimal? LogmnrSpare2 { get; set; }

    [Column("LOGMNR_SPARE3")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? LogmnrSpare3 { get; set; }

    [Column("LOGMNR_SPARE4", TypeName = "DATE")]
    public DateTime? LogmnrSpare4 { get; set; }

    [Column("LOGMNR_SPARE5", TypeName = "NUMBER")]
    public decimal? LogmnrSpare5 { get; set; }

    [Column("LOGMNR_SPARE6", TypeName = "NUMBER")]
    public decimal? LogmnrSpare6 { get; set; }

    [Column("LOGMNR_SPARE7", TypeName = "NUMBER")]
    public decimal? LogmnrSpare7 { get; set; }

    [Column("LOGMNR_SPARE8", TypeName = "NUMBER")]
    public decimal? LogmnrSpare8 { get; set; }

    [Column("LOGMNR_SPARE9", TypeName = "NUMBER")]
    public decimal? LogmnrSpare9 { get; set; }

    [Column("COL#", TypeName = "NUMBER")]
    public decimal? Col { get; set; }

    [Column("XTYPESCHEMANAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Xtypeschemaname { get; set; }

    [Column("XTYPENAME")]
    [Unicode(false)]
    public string? Xtypename { get; set; }

    [Column("XFQCOLNAME")]
    [Unicode(false)]
    public string? Xfqcolname { get; set; }

    [Column("XTOPINTCOL", TypeName = "NUMBER")]
    public decimal? Xtopintcol { get; set; }

    [Column("XREFFEDTABLEOBJN", TypeName = "NUMBER")]
    public decimal? Xreffedtableobjn { get; set; }

    [Column("XREFFEDTABLEOBJV", TypeName = "NUMBER")]
    public decimal? Xreffedtableobjv { get; set; }

    [Column("XCOLTYPEFLAGS", TypeName = "NUMBER")]
    public decimal? Xcoltypeflags { get; set; }

    [Column("XOPQTYPETYPE", TypeName = "NUMBER")]
    public decimal? Xopqtypetype { get; set; }

    [Column("XOPQTYPEFLAGS", TypeName = "NUMBER")]
    public decimal? Xopqtypeflags { get; set; }

    [Column("XOPQLOBINTCOL", TypeName = "NUMBER")]
    public decimal? Xopqlobintcol { get; set; }

    [Column("XOPQOBJINTCOL", TypeName = "NUMBER")]
    public decimal? Xopqobjintcol { get; set; }

    [Column("XXMLINTCOL", TypeName = "NUMBER")]
    public decimal? Xxmlintcol { get; set; }

    [Column("EAOWNER#", TypeName = "NUMBER")]
    public decimal? Eaowner { get; set; }

    [Column("EAMKEYID")]
    [StringLength(192)]
    [Unicode(false)]
    public string? Eamkeyid { get; set; }

    [Column("EAENCALG", TypeName = "NUMBER")]
    public decimal? Eaencalg { get; set; }

    [Column("EAINTALG", TypeName = "NUMBER")]
    public decimal? Eaintalg { get; set; }

    [Column("EACOLKLC")]
    public byte[]? Eacolklc { get; set; }

    [Column("EAKLCLEN", TypeName = "NUMBER")]
    public decimal? Eaklclen { get; set; }

    [Column("EAFLAGS", TypeName = "NUMBER")]
    public decimal? Eaflags { get; set; }

    [Column("LOGMNRDERIVEDFLAGS", TypeName = "NUMBER")]
    public decimal? Logmnrderivedflags { get; set; }

    [Column("COLLID", TypeName = "NUMBER")]
    public decimal? Collid { get; set; }

    [Column("COLLINTCOL#", TypeName = "NUMBER")]
    public decimal? Collintcol { get; set; }

    [Column("ACDRRESCOL#", TypeName = "NUMBER")]
    public decimal? Acdrrescol { get; set; }
}
