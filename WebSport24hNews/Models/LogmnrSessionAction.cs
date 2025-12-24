using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Logmnrsession", "Actionname")]
[Table("LOGMNR_SESSION_ACTIONS$")]
public partial class LogmnrSessionAction  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("FLAGSRUNTIME", TypeName = "NUMBER")]
    public decimal? Flagsruntime { get; set; }

    [Column("DROPSCN", TypeName = "NUMBER")]
    public decimal? Dropscn { get; set; }

    [Column("MODIFYTIME")]
    [Precision(6)]
    public DateTime? Modifytime { get; set; }

    [Column("DISPATCHTIME")]
    [Precision(6)]
    public DateTime? Dispatchtime { get; set; }

    [Column("DROPTIME")]
    [Precision(6)]
    public DateTime? Droptime { get; set; }

    [Column("LCRCOUNT", TypeName = "NUMBER")]
    public decimal? Lcrcount { get; set; }

    [Key]
    [Column("ACTIONNAME")]
    [StringLength(30)]
    [Unicode(false)]
    public string Actionname { get; set; } = null!;

    [Key]
    [Column("LOGMNRSESSION#", TypeName = "NUMBER")]
    public decimal Logmnrsession { get; set; }

    [Column("PROCESSROLE#", TypeName = "NUMBER")]
    public decimal Processrole { get; set; }

    [Column("ACTIONTYPE#", TypeName = "NUMBER")]
    public decimal Actiontype { get; set; }

    [Column("FLAGSDEFINETIME", TypeName = "NUMBER")]
    public decimal? Flagsdefinetime { get; set; }

    [Column("CREATETIME")]
    [Precision(6)]
    public DateTime? Createtime { get; set; }

    [Column("XIDUSN", TypeName = "NUMBER")]
    public decimal? Xidusn { get; set; }

    [Column("XIDSLT", TypeName = "NUMBER")]
    public decimal? Xidslt { get; set; }

    [Column("XIDSQN", TypeName = "NUMBER")]
    public decimal? Xidsqn { get; set; }

    [Column("THREAD#", TypeName = "NUMBER")]
    public decimal? Thread { get; set; }

    [Column("STARTSCN", TypeName = "NUMBER")]
    public decimal? Startscn { get; set; }

    [Column("STARTSUBSCN", TypeName = "NUMBER")]
    public decimal? Startsubscn { get; set; }

    [Column("ENDSCN", TypeName = "NUMBER")]
    public decimal? Endscn { get; set; }

    [Column("ENDSUBSCN", TypeName = "NUMBER")]
    public decimal? Endsubscn { get; set; }

    [Column("RBASQN", TypeName = "NUMBER")]
    public decimal? Rbasqn { get; set; }

    [Column("RBABLK", TypeName = "NUMBER")]
    public decimal? Rbablk { get; set; }

    [Column("RBABYTE", TypeName = "NUMBER")]
    public decimal? Rbabyte { get; set; }

    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal? Session { get; set; }

    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal? Obj { get; set; }

    [Column("ATTR1", TypeName = "NUMBER")]
    public decimal? Attr1 { get; set; }

    [Column("ATTR2", TypeName = "NUMBER")]
    public decimal? Attr2 { get; set; }

    [Column("ATTR3", TypeName = "NUMBER")]
    public decimal? Attr3 { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Precision(6)]
    public DateTime? Spare3 { get; set; }

    [Column("SPARE4")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Spare4 { get; set; }

    [Column("PDBID", TypeName = "NUMBER")]
    public decimal? Pdbid { get; set; }

    [Column("PDB_NAME")]
    [StringLength(390)]
    [Unicode(false)]
    public string? PdbName { get; set; }
}
