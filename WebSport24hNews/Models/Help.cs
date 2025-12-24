using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("Topic", "Seq")]
[Table("HELP")]
public partial class Help  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("TOPIC")]
    [StringLength(50)]
    [Unicode(false)]
    public string Topic { get; set; } = null!;

    [Key]
    [Column("SEQ", TypeName = "NUMBER")]
    public decimal Seq { get; set; }

    [Column("INFO")]
    [StringLength(80)]
    [Unicode(false)]
    public string? Info { get; set; }
}
