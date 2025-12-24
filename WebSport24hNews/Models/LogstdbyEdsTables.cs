using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Owner", "TableName")]
[Table("LOGSTDBY$EDS_TABLES")]
public partial class LogstdbyEdsTables  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string Owner { get; set; } = null!;

    [Key]
    [Column("TABLE_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string TableName { get; set; } = null!;

    [Column("SHADOW_TABLE_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? ShadowTableName { get; set; }

    [Column("BASE_TRIGGER_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? BaseTriggerName { get; set; }

    [Column("SHADOW_TRIGGER_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? ShadowTriggerName { get; set; }

    [Column("DBLINK")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Dblink { get; set; }

    [Column("FLAGS", TypeName = "NUMBER")]
    public decimal? Flags { get; set; }

    [Column("STATE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? State { get; set; }

    [Column("OBJV", TypeName = "NUMBER")]
    public decimal? Objv { get; set; }

    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal? Obj { get; set; }

    [Column("SOBJ#", TypeName = "NUMBER")]
    public decimal? Sobj { get; set; }

    [Column("CTIME")]
    [Precision(6)]
    public DateTime? Ctime { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("MVIEW_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? MviewName { get; set; }

    [Column("MVIEW_LOG_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? MviewLogName { get; set; }

    [Column("MVIEW_TRIGGER_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? MviewTriggerName { get; set; }
}
