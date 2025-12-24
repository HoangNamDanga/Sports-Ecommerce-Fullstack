using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("AQ$_QUEUES")]
[Index("Name", "TableObjno", Name = "AQ$_QUEUES_CHECK", IsUnique = true)]
[Index("Name", "Eventid", "TableObjno", Name = "I1_QUEUES")]
public partial class AqQueues  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OID")]
    public Guid Oid { get; set; }

    [Column("EVENTID", TypeName = "NUMBER")]
    public decimal Eventid { get; set; }

    [Column("NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("TABLE_OBJNO", TypeName = "NUMBER")]
    public decimal TableObjno { get; set; }

    [Column("USAGE", TypeName = "NUMBER")]
    public decimal Usage { get; set; }

    [Column("ENABLE_FLAG", TypeName = "NUMBER")]
    public decimal EnableFlag { get; set; }

    [Column("MAX_RETRIES", TypeName = "NUMBER")]
    public decimal? MaxRetries { get; set; }

    [Column("RETRY_DELAY", TypeName = "NUMBER")]
    public decimal? RetryDelay { get; set; }

    [Column("PROPERTIES", TypeName = "NUMBER")]
    public decimal? Properties { get; set; }

    [Column("RET_TIME", TypeName = "NUMBER")]
    public decimal? RetTime { get; set; }

    [Column("QUEUE_COMMENT")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? QueueComment { get; set; }

    [Column("MEMORY_THRESHOLD", TypeName = "NUMBER")]
    public decimal? MemoryThreshold { get; set; }

    [Column("SERVICE_NAME")]
    [StringLength(64)]
    [Unicode(false)]
    public string? ServiceName { get; set; }

    [Column("NETWORK_NAME")]
    [StringLength(256)]
    [Unicode(false)]
    public string? NetworkName { get; set; }

    [Column("SUB_OID")]
    public Guid? SubOid { get; set; }

    [Column("SHARDED", TypeName = "NUMBER")]
    public decimal? Sharded { get; set; }

    [Column("BASE_QUEUE", TypeName = "NUMBER")]
    public decimal? BaseQueue { get; set; }
}
