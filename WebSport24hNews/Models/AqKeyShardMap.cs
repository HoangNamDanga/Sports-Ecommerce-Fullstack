using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("AQ$_KEY_SHARD_MAP")]
[Index("Queue", "Key", Name = "AQ$_KEY_SHARD_MAP_PK", IsUnique = true)]
public partial class AqKeyShardMap  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("QUEUE", TypeName = "NUMBER")]
    public decimal Queue { get; set; }

    [Column("KEY")]
    [StringLength(128)]
    [Unicode(false)]
    public string Key { get; set; } = null!;

    [Column("SHARD", TypeName = "NUMBER")]
    public decimal Shard { get; set; }

    [Column("DELAY_SHARD", TypeName = "NUMBER")]
    public decimal DelayShard { get; set; }
}
