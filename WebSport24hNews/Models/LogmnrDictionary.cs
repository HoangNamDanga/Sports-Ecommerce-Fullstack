using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("LOGMNR_DICTIONARY$")]
[Index("LogmnrUid", Name = "LOGMNR_I1DICTIONARY$")]
public partial class LogmnrDictionary  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("DB_NAME")]
    [StringLength(27)]
    [Unicode(false)]
    public string? DbName { get; set; }

    [Column("DB_ID", TypeName = "NUMBER(20)")]
    public decimal? DbId { get; set; }

    [Column("DB_CREATED")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DbCreated { get; set; }

    [Column("DB_DICT_CREATED")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DbDictCreated { get; set; }

    [Column("DB_DICT_SCN", TypeName = "NUMBER(22)")]
    public decimal? DbDictScn { get; set; }

    [Column("DB_THREAD_MAP")]
    [MaxLength(8)]
    public byte[]? DbThreadMap { get; set; }

    [Column("DB_TXN_SCNBAS", TypeName = "NUMBER(22)")]
    public decimal? DbTxnScnbas { get; set; }

    [Column("DB_TXN_SCNWRP", TypeName = "NUMBER(22)")]
    public decimal? DbTxnScnwrp { get; set; }

    [Column("DB_RESETLOGS_CHANGE#", TypeName = "NUMBER(22)")]
    public decimal? DbResetlogsChange { get; set; }

    [Column("DB_RESETLOGS_TIME")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DbResetlogsTime { get; set; }

    [Column("DB_VERSION_TIME")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DbVersionTime { get; set; }

    [Column("DB_REDO_TYPE_ID")]
    [StringLength(8)]
    [Unicode(false)]
    public string? DbRedoTypeId { get; set; }

    [Column("DB_REDO_RELEASE")]
    [StringLength(60)]
    [Unicode(false)]
    public string? DbRedoRelease { get; set; }

    [Column("DB_CHARACTER_SET")]
    [StringLength(192)]
    [Unicode(false)]
    public string? DbCharacterSet { get; set; }

    [Column("DB_VERSION")]
    [StringLength(240)]
    [Unicode(false)]
    public string? DbVersion { get; set; }

    [Column("DB_STATUS")]
    [StringLength(240)]
    [Unicode(false)]
    public string? DbStatus { get; set; }

    [Column("DB_GLOBAL_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? DbGlobalName { get; set; }

    [Column("DB_DICT_MAXOBJECTS", TypeName = "NUMBER(22)")]
    public decimal? DbDictMaxobjects { get; set; }

    [Column("DB_DICT_OBJECTCOUNT", TypeName = "NUMBER(22)")]
    public decimal DbDictObjectcount { get; set; }

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }

    [Column("PDB_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? PdbName { get; set; }

    [Column("PDB_ID", TypeName = "NUMBER")]
    public decimal? PdbId { get; set; }

    [Column("PDB_UID", TypeName = "NUMBER")]
    public decimal? PdbUid { get; set; }

    [Column("PDB_DBID", TypeName = "NUMBER")]
    public decimal? PdbDbid { get; set; }

    [Column("PDB_GUID")]
    public Guid? PdbGuid { get; set; }

    [Column("PDB_CREATE_SCN", TypeName = "NUMBER")]
    public decimal? PdbCreateScn { get; set; }

    [Column("PDB_COUNT", TypeName = "NUMBER")]
    public decimal? PdbCount { get; set; }

    [Column("PDB_GLOBAL_NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? PdbGlobalName { get; set; }

    [Column("FED_ROOT_CON_ID#", TypeName = "NUMBER")]
    public decimal? FedRootConId { get; set; }
}
