using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
public partial class MviewLog  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("FILTERID", TypeName = "NUMBER")]
    public decimal? Filterid { get; set; }

    [Column("RUN_BEGIN", TypeName = "DATE")]
    public DateTime? RunBegin { get; set; }

    [Column("RUN_END", TypeName = "DATE")]
    public DateTime? RunEnd { get; set; }

    [Column("TYPE")]
    [StringLength(11)]
    [Unicode(false)]
    public string? Type { get; set; }

    [Column("STATUS")]
    [StringLength(11)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("MESSAGE")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Message { get; set; }

    [Column("COMPLETED", TypeName = "NUMBER")]
    public decimal? Completed { get; set; }

    [Column("TOTAL", TypeName = "NUMBER")]
    public decimal? Total { get; set; }

    [Column("ERROR_CODE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ErrorCode { get; set; }
}
