using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("REPL_VALID_COMPAT")]
public partial class ReplValidCompat  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("COMPAT", TypeName = "NUMBER")]
    public decimal? Compat { get; set; }
}
