using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("AQ$_QUEUE_TABLES")]
[Index("Objno", "Schema", "Flags", Name = "I1_QUEUE_TABLES")]
public partial class AqQueueTables  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SCHEMA")]
    [StringLength(128)]
    [Unicode(false)]
    public string Schema { get; set; } = null!;

    [Column("NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("UDATA_TYPE", TypeName = "NUMBER")]
    public decimal UdataType { get; set; }

    [Key]
    [Column("OBJNO", TypeName = "NUMBER")]
    public decimal Objno { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal Flags { get; set; }

    [Column("SORT_COLS", TypeName = "NUMBER")]
    public decimal SortCols { get; set; }

    [Column("TIMEZONE")]
    [StringLength(64)]
    [Unicode(false)]
    public string? Timezone { get; set; }

    [Column("TABLE_COMMENT")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? TableComment { get; set; }
}
