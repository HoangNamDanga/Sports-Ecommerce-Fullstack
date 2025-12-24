using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Name")]
[Table("LOGMNR_KOPM$")]
[Index("LogmnrUid", "Name", Name = "LOGMNR_I1KOPM$")]
public partial class LogmnrKopm  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("LENGTH", TypeName = "NUMBER")]
    public decimal? Length { get; set; }

    [Column("METADATA")]
    [MaxLength(255)]
    public byte[]? Metadata { get; set; }

    [Key]
    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER(22)")]
    public decimal? LogmnrUid { get; set; }

    [Column("LOGMNR_FLAGS", TypeName = "NUMBER(22)")]
    public decimal? LogmnrFlags { get; set; }
}
