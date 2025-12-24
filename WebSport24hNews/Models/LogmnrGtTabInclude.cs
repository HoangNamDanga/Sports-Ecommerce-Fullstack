using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("LOGMNR_GT_TAB_INCLUDE$")]
public partial class LogmnrGtTabInclude  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SCHEMA_NAME")]
    [StringLength(390)]
    [Unicode(false)]
    public string? SchemaName { get; set; }

    [Column("TABLE_NAME")]
    [StringLength(390)]
    [Unicode(false)]
    public string? TableName { get; set; }

    [Column("PDB_NAME")]
    [StringLength(390)]
    [Unicode(false)]
    public string? PdbName { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
