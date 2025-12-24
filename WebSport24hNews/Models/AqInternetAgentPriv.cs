using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("AQ$_INTERNET_AGENT_PRIVS")]
[Index("AgentName", "DbUsername", Name = "UNQ_PAIRS", IsUnique = true)]
public partial class AqInternetAgentPriv  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("AGENT_NAME")]
    [StringLength(512)]
    [Unicode(false)]
    public string AgentName { get; set; } = null!;

    [Column("DB_USERNAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string DbUsername { get; set; } = null!;

    [ForeignKey("AgentName")]
    public virtual AqInternetAgent AgentNameNavigation { get; set; } = null!;
}
