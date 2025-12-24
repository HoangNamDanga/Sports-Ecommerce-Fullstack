using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("DHN_IMPORT_WARRANTY_DATUM")]
public partial class DhnImportWarrantyDatum  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID")]
    [Precision(15)]
    public long Id { get; set; }

    [Column("MACTY")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Macty { get; set; }

    [Column("TENCTY")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Tencty { get; set; }

    [Column("SOCTY")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Socty { get; set; }

    [Column("NGAYCT")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Ngayct { get; set; }

    [Column("MAVACH")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Mavach { get; set; }

    [Column("MAVATTU")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Mavattu { get; set; }

    [Column("TENVATTU")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Tenvattu { get; set; }

    [Column("MAKH")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Makh { get; set; }

    [Column("DIENGIAI")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Diengiai { get; set; }

    [Column("MAKHO")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Makho { get; set; }

    [Column("ONGBA")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Ongba { get; set; }

    [Column("TENKH")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Tenkh { get; set; }

    [Column("HANBHCTY")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Hanbhcty { get; set; }

    [Column("SOCTGOC")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Soctgoc { get; set; }

    [Column("MAVACHCHA")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Mavachcha { get; set; }

    [Column("THAYTHEBOI")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Thaytheboi { get; set; }

    [Column("MAVACH1")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Mavach1 { get; set; }

    [Column("TENNX")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Tennx { get; set; }

    [Column("STTREC")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Sttrec { get; set; }

    [Column("MACT")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Mact { get; set; }

    [Column("MACTGOC")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Mactgoc { get; set; }

    [Column("NGAYCTGOC")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Ngayctgoc { get; set; }

    [Column("MATTMV")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Mattmv { get; set; }

    [Column("TENTTMV")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Tenttmv { get; set; }

    [Column("DIENGIAIBARCODE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Diengiaibarcode { get; set; }

    [Column("NXT")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Nxt { get; set; }

    [Column("SORT")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Sort { get; set; }

    [Column("BOLD")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Bold { get; set; }

    [Column("ATTRIBUTE1")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Attribute1 { get; set; }

    [Column("ATTRIBUTE2")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Attribute2 { get; set; }

    [Column("ATTRIBUTE3")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Attribute3 { get; set; }

    [Column("HANBHNCC")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Hanbhncc { get; set; }

    [Column("THAY_THE_CHO")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ThayTheCho { get; set; }
}
