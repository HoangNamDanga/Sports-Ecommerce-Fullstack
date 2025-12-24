using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("LOGMNR_PROFILE_TABLE_STATS$")]
public partial class LogmnrProfileTableStats  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("OWNER")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Owner { get; set; }

    [Column("NAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Key]
    [Column("OBJID", TypeName = "NUMBER")]
    public decimal Objid { get; set; }

    [Column("OPNUM", TypeName = "NUMBER")]
    public decimal? Opnum { get; set; }

    [Column("TLSBYUNSUPPOPNUM", TypeName = "NUMBER")]
    public decimal? Tlsbyunsuppopnum { get; set; }

    [Column("OGGUNSUPPOPNUM", TypeName = "NUMBER")]
    public decimal? Oggunsuppopnum { get; set; }

    [Column("OGGFETCHOPNUM", TypeName = "NUMBER")]
    public decimal? Oggfetchopnum { get; set; }

    [Column("OGGPLSQLOPNUM", TypeName = "NUMBER")]
    public decimal? Oggplsqlopnum { get; set; }

    [Column("PARTNUM", TypeName = "NUMBER")]
    public decimal? Partnum { get; set; }

    [Column("INSERTNUM", TypeName = "NUMBER")]
    public decimal? Insertnum { get; set; }

    [Column("UPDATENUM", TypeName = "NUMBER")]
    public decimal? Updatenum { get; set; }

    [Column("DELETENUM", TypeName = "NUMBER")]
    public decimal? Deletenum { get; set; }

    [Column("DDLNUM", TypeName = "NUMBER")]
    public decimal? Ddlnum { get; set; }

    [Column("PROPERTY1", TypeName = "NUMBER")]
    public decimal? Property1 { get; set; }

    [Column("PROPERTY2", TypeName = "NUMBER")]
    public decimal? Property2 { get; set; }

    [Column("PARTITIONATTR", TypeName = "NUMBER")]
    public decimal? Partitionattr { get; set; }

    [Column("REDOSIZE", TypeName = "NUMBER")]
    public decimal? Redosize { get; set; }

    [Column("MAXLOBSIZE", TypeName = "NUMBER")]
    public decimal? Maxlobsize { get; set; }

    [Column("REDORATE", TypeName = "NUMBER")]
    public decimal? Redorate { get; set; }

    [Column("SPARE1")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Spare1 { get; set; }

    [Column("SPARE2")]
    [StringLength(384)]
    [Unicode(false)]
    public string? Spare2 { get; set; }

    [Column("SPARE3", TypeName = "NUMBER")]
    public decimal? Spare3 { get; set; }

    [Column("SPARE4", TypeName = "NUMBER")]
    public decimal? Spare4 { get; set; }

    [Column("SPARE5", TypeName = "NUMBER")]
    public decimal? Spare5 { get; set; }

    [Column("SPARE6", TypeName = "NUMBER")]
    public decimal? Spare6 { get; set; }
}
