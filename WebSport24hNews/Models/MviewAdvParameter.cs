using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

/// <summary>
/// Summary advisor tuning parameters
/// </summary>
[Table("MVIEW$_ADV_PARAMETERS")]
public partial class MviewAdvParameter  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("PARAMETER_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string ParameterName { get; set; } = null!;

    [Column("PARAMETER_TYPE", TypeName = "NUMBER")]
    public decimal ParameterType { get; set; }

    [Column("STRING_VALUE")]
    [StringLength(30)]
    [Unicode(false)]
    public string? StringValue { get; set; }

    [Column("DATE_VALUE", TypeName = "DATE")]
    public DateTime? DateValue { get; set; }

    [Column("NUMERICAL_VALUE", TypeName = "NUMBER")]
    public decimal? NumericalValue { get; set; }
}
