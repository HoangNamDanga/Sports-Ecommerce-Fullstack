using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("AQ$_INTERNET_AGENTS")]
public partial class AqInternetAgent  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("AGENT_NAME")]
    [StringLength(512)]
    [Unicode(false)]
    public string AgentName { get; set; } = null!;

    [Column("PROTOCOL", TypeName = "NUMBER(38)")]
    public decimal Protocol { get; set; }

    [Column("SPARE1")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Spare1 { get; set; }
}
