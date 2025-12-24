using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "TablespaceName")]
[Table("LOGMNR_SHARD_TS")]
[Index("LogmnrUid", "TablespaceName", Name = "LOGMNR_I1SHARD_TS")]
public partial class LogmnrShardT  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
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

    [Column("START_SCNBAS", TypeName = "NUMBER")]
    public decimal? StartScnbas { get; set; }

    [Column("START_SCNWRP", TypeName = "NUMBER")]
    public decimal? StartScnwrp { get; set; }
}
