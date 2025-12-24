using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Private plan table for estimate_mview_size operations
/// </summary>
[Keyless]
[Table("MVIEW$_ADV_PLAN")]
public partial class MviewAdvPlan  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("STATEMENT_ID")]
    [StringLength(30)]
    [Unicode(false)]
    public string? StatementId { get; set; }

    [Column("TIMESTAMP", TypeName = "DATE")]
    public DateTime? Timestamp { get; set; }

    [Column("REMARKS")]
    [StringLength(80)]
    [Unicode(false)]
    public string? Remarks { get; set; }

    [Column("OPERATION")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Operation { get; set; }

    [Column("OPTIONS")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Options { get; set; }

    [Column("OBJECT_NODE")]
    [StringLength(128)]
    [Unicode(false)]
    public string? ObjectNode { get; set; }

    [Column("OBJECT_OWNER")]
    [StringLength(128)]
    [Unicode(false)]
    public string? ObjectOwner { get; set; }

    [Column("OBJECT_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? ObjectName { get; set; }

    [Column("OBJECT_INSTANCE", TypeName = "NUMBER(38)")]
    public decimal? ObjectInstance { get; set; }

    [Column("OBJECT_TYPE")]
    [StringLength(30)]
    [Unicode(false)]
    public string? ObjectType { get; set; }

    [Column("OPTIMIZER")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Optimizer { get; set; }

    [Column("SEARCH_COLUMNS", TypeName = "NUMBER")]
    public decimal? SearchColumns { get; set; }

    [Column("ID", TypeName = "NUMBER(38)")]
    public decimal? Id { get; set; }

    [Column("PARENT_ID", TypeName = "NUMBER(38)")]
    public decimal? ParentId { get; set; }

    [Column("POSITION", TypeName = "NUMBER(38)")]
    public decimal? Position { get; set; }

    [Column("COST", TypeName = "NUMBER(38)")]
    public decimal? Cost { get; set; }

    [Column("CARDINALITY", TypeName = "NUMBER(38)")]
    public decimal? Cardinality { get; set; }

    [Column("BYTES", TypeName = "NUMBER(38)")]
    public decimal? Bytes { get; set; }

    [Column("OTHER_TAG")]
    [StringLength(255)]
    [Unicode(false)]
    public string? OtherTag { get; set; }

    [Column("PARTITION_START")]
    [StringLength(255)]
    [Unicode(false)]
    public string? PartitionStart { get; set; }

    [Column("PARTITION_STOP")]
    [StringLength(255)]
    [Unicode(false)]
    public string? PartitionStop { get; set; }

    [Column("PARTITION_ID", TypeName = "NUMBER(38)")]
    public decimal? PartitionId { get; set; }

    [Column("OTHER", TypeName = "LONG")]
    public string? Other { get; set; }

    [Column("DISTRIBUTION")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Distribution { get; set; }

    [Column("CPU_COST", TypeName = "NUMBER(38)")]
    public decimal? CpuCost { get; set; }

    [Column("IO_COST", TypeName = "NUMBER(38)")]
    public decimal? IoCost { get; set; }

    [Column("TEMP_SPACE", TypeName = "NUMBER(38)")]
    public decimal? TempSpace { get; set; }
}
