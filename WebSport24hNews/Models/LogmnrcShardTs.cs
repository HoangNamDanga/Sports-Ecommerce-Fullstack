using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "TablespaceName", "StartScn")]
[Table("LOGMNRC_SHARD_TS")]
[Index("LogmnrUid", "DropScn", Name = "LOGMNRC_I1SHARD_TS")]
public partial class LogmnrcShardTs  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("TABLESPACE_NAME")]
    [StringLength(90)]
    [Unicode(false)]
    public string TablespaceName { get; set; } = null!;

    [Column("CHUNK_NUMBER", TypeName = "NUMBER")]
    public decimal ChunkNumber { get; set; }

    [Key]
    [Column("START_SCN", TypeName = "NUMBER")]
    public decimal StartScn { get; set; }

    [Column("DROP_SCN", TypeName = "NUMBER")]
    public decimal? DropScn { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
