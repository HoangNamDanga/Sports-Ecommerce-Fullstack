using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("ROLLING$CONNECTIONS")]
public partial class RollingConnection  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("SOURCE_RDBID", TypeName = "NUMBER")]
    public decimal? SourceRdbid { get; set; }

    [Column("DEST_RDBID", TypeName = "NUMBER")]
    public decimal? DestRdbid { get; set; }

    [Column("ATTRIBUTES", TypeName = "NUMBER")]
    public decimal? Attributes { get; set; }

    [Column("SERVICE_NAME")]
    [StringLength(256)]
    [Unicode(false)]
    public string? ServiceName { get; set; }

    [Column("CONN_HANDLE", TypeName = "NUMBER")]
    public decimal? ConnHandle { get; set; }

    [Column("CONNECT_TIME")]
    [Precision(6)]
    public DateTime? ConnectTime { get; set; }

    [Column("SEND_TIME")]
    [Precision(6)]
    public DateTime? SendTime { get; set; }

    [Column("DISCONNECT_TIME")]
    [Precision(6)]
    public DateTime? DisconnectTime { get; set; }

    [Column("UPDATE_TIME")]
    [Precision(6)]
    public DateTime? UpdateTime { get; set; }

    [Column("SOURCE_PID", TypeName = "NUMBER")]
    public decimal? SourcePid { get; set; }

    [Column("DEST_PID", TypeName = "NUMBER")]
    public decimal? DestPid { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Spare3 { get; set; }
}
