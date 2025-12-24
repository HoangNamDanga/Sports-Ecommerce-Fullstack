using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Session", "DbId", "ResetScn", "ResetTimestamp")]
[Table("LOGMNR_SESSION_EVOLVE$")]
public partial class LogmnrSessionEvolve  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("BRANCH_LEVEL", TypeName = "NUMBER")]
    public decimal? BranchLevel { get; set; }

    [Key]
    [Column("SESSION#", TypeName = "NUMBER")]
    public decimal Session { get; set; }

    [Key]
    [Column("DB_ID", TypeName = "NUMBER")]
    public decimal DbId { get; set; }

    [Key]
    [Column("RESET_SCN", TypeName = "NUMBER")]
    public decimal ResetScn { get; set; }

    [Key]
    [Column("RESET_TIMESTAMP", TypeName = "NUMBER")]
    public decimal ResetTimestamp { get; set; }

    [Column("PREV_RESET_SCN", TypeName = "NUMBER")]
    public decimal? PrevResetScn { get; set; }

    [Column("PREV_RESET_TIMESTAMP", TypeName = "NUMBER")]
    public decimal? PrevResetTimestamp { get; set; }

    [Column("STATUS", TypeName = "NUMBER")]
    public decimal? Status { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SPARE4", TypeName = "DATE")]
    public DateTime? Spare4 { get; set; }
}
