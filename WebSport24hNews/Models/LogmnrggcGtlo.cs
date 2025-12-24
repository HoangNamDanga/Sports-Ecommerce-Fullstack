using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Keyobj", "Baseobjv")]
[Table("LOGMNRGGC_GTLO")]
[Index("LogmnrUid", "Baseobj", "Baseobjv", Name = "LOGMNRGGC_I2GTLO")]
[Index("LogmnrUid", "DropScn", Name = "LOGMNRGGC_I3GTLO")]
public partial class LogmnrggcGtlo  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("KEYOBJ#", TypeName = "NUMBER")]
    public decimal Keyobj { get; set; }

    [Column("LVLCNT", TypeName = "NUMBER")]
    public decimal Lvlcnt { get; set; }

    [Column("BASEOBJ#", TypeName = "NUMBER")]
    public decimal Baseobj { get; set; }

    [Key]
    [Column("BASEOBJV#", TypeName = "NUMBER")]
    public decimal Baseobjv { get; set; }

    [Column("LVL1OBJ#", TypeName = "NUMBER")]
    public decimal? Lvl1obj { get; set; }

    [Column("LVL2OBJ#", TypeName = "NUMBER")]
    public decimal? Lvl2obj { get; set; }

    [Column("LVL0TYPE#", TypeName = "NUMBER")]
    public decimal Lvl0type { get; set; }

    [Column("LVL1TYPE#", TypeName = "NUMBER")]
    public decimal? Lvl1type { get; set; }

    [Column("LVL2TYPE#", TypeName = "NUMBER")]
    public decimal? Lvl2type { get; set; }

    [Column("OWNER#", TypeName = "NUMBER")]
    public decimal? Owner { get; set; }

    [Column("OWNERNAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Ownername { get; set; } = null!;

    [Column("LVL0NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Lvl0name { get; set; } = null!;

    [Column("LVL1NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Lvl1name { get; set; }

    [Column("LVL2NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Lvl2name { get; set; }

    [Column("INTCOLS", TypeName = "NUMBER")]
    public decimal Intcols { get; set; }

    [Column("COLS", TypeName = "NUMBER")]
    public decimal? Cols { get; set; }

    [Column("KERNELCOLS", TypeName = "NUMBER")]
    public decimal? Kernelcols { get; set; }

    [Column("TAB_FLAGS", TypeName = "NUMBER")]
    public decimal? TabFlags { get; set; }

    [Column("TRIGFLAG", TypeName = "NUMBER")]
    public decimal? Trigflag { get; set; }

    [Column("ASSOC#", TypeName = "NUMBER")]
    public decimal? Assoc { get; set; }

    [Column("OBJ_FLAGS", TypeName = "NUMBER")]
    public decimal? ObjFlags { get; set; }

    [Column("TS#", TypeName = "NUMBER")]
    public decimal? Ts { get; set; }

    [Column("TSNAME")]
    [StringLength(90)]
    [Unicode(false)]
    public string? Tsname { get; set; }

    [Column("PROPERTY", TypeName = "NUMBER")]
    public decimal? Property { get; set; }

    [Column("START_SCN", TypeName = "NUMBER")]
    public decimal StartScn { get; set; }

    [Column("DROP_SCN", TypeName = "NUMBER")]
    public decimal? DropScn { get; set; }

    [Column("XIDUSN", TypeName = "NUMBER")]
    public decimal? Xidusn { get; set; }

    [Column("XIDSLT", TypeName = "NUMBER")]
    public decimal? Xidslt { get; set; }

    [Column("XIDSQN", TypeName = "NUMBER")]
    public decimal? Xidsqn { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

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

    [Column("PARTTYPE", TypeName = "NUMBER")]
    public decimal? Parttype { get; set; }

    [Column("SUBPARTTYPE", TypeName = "NUMBER")]
    public decimal? Subparttype { get; set; }

    [Column("UNSUPPORTEDCOLS", TypeName = "NUMBER")]
    public decimal? Unsupportedcols { get; set; }

    [Column("COMPLEXTYPECOLS", TypeName = "NUMBER")]
    public decimal? Complextypecols { get; set; }

    [Column("NTPARENTOBJNUM", TypeName = "NUMBER")]
    public decimal? Ntparentobjnum { get; set; }

    [Column("NTPARENTOBJVERSION", TypeName = "NUMBER")]
    public decimal? Ntparentobjversion { get; set; }

    [Column("NTPARENTINTCOLNUM", TypeName = "NUMBER")]
    public decimal? Ntparentintcolnum { get; set; }

    [Column("LOGMNRTLOFLAGS", TypeName = "NUMBER")]
    public decimal? Logmnrtloflags { get; set; }

    [Column("LOGMNRMCV")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Logmnrmcv { get; set; }

    [Column("ACDRFLAGS", TypeName = "NUMBER")]
    public decimal? Acdrflags { get; set; }

    [Column("ACDRTSOBJ#", TypeName = "NUMBER")]
    public decimal? Acdrtsobj { get; set; }

    [Column("ACDRROWTSINTCOL#", TypeName = "NUMBER")]
    public decimal? Acdrrowtsintcol { get; set; }
}
