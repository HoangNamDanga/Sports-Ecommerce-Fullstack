using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("OL$NODES")]
public partial class OlNode  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("OL_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? OlName { get; set; }

    [Column("CATEGORY")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Category { get; set; }

    [Column("NODE_ID", TypeName = "NUMBER")]
    public decimal? NodeId { get; set; }

    [Column("PARENT_ID", TypeName = "NUMBER")]
    public decimal? ParentId { get; set; }

    [Column("NODE_TYPE", TypeName = "NUMBER")]
    public decimal? NodeType { get; set; }

    [Column("NODE_TEXTLEN", TypeName = "NUMBER")]
    public decimal? NodeTextlen { get; set; }

    [Column("NODE_TEXTOFF", TypeName = "NUMBER")]
    public decimal? NodeTextoff { get; set; }

    [Column("NODE_NAME")]
    [StringLength(64)]
    [Unicode(false)]
    public string? NodeName { get; set; }
}
