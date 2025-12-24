using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("PLAYERS")]
public partial class Player  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("FIRST_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [Column("LAST_NAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column("NATIONALITY")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Nationality { get; set; }

    [Column("BIRTH_DATE", TypeName = "DATE")]
    public DateTime? BirthDate { get; set; }

    [Column("HEIGHT", TypeName = "NUMBER(3,2)")]
    public decimal? Height { get; set; }

    [Column("WEIGHT", TypeName = "NUMBER(3,1)")]
    public decimal? Weight { get; set; }

    [Column("POSITION")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Position { get; set; }

    [Column("TEAM_ID", TypeName = "NUMBER")]
    public decimal? TeamId { get; set; }

    [Column("JERSEY_NUMBER")]
    [Precision(2)]
    public byte? JerseyNumber { get; set; }

    [Column("PHOTO_URL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? PhotoUrl { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
