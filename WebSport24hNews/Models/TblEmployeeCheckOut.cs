using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("TBL_EMPLOYEE_CHECK_OUT")]
public partial class TblEmployeeCheckOut  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("COMPANY_CODE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CompanyCode { get; set; }

    [Column("DEPARTMENT_CODE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? DepartmentCode { get; set; }

    [Column("EMPLOYEE_CODE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? EmployeeCode { get; set; }

    [Column("EMPLOYEE_NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string? EmployeeName { get; set; }

    [Column("POSITION")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Position { get; set; }

    [Column("JOB_TITLE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? JobTitle { get; set; }

    [Column("WORK_LOCATION")]
    [StringLength(100)]
    [Unicode(false)]
    public string? WorkLocation { get; set; }

    [Column("CHECK_IN_TIME", TypeName = "DATE")]
    public DateTime? CheckInTime { get; set; }

    [Column("CHECK_OUT_TIME", TypeName = "DATE")]
    public DateTime? CheckOutTime { get; set; }

    [Column("ATTRIBUTE1")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute1 { get; set; }

    [Column("ATTRIBUTE2")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute2 { get; set; }

    [Column("ATTRIBUTE3")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute3 { get; set; }

    [Column("ATTRIBUTE4")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute4 { get; set; }

    [Column("ATTRIBUTE5")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute5 { get; set; }

    [Column("ATTRIBUTE6")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute6 { get; set; }

    [Column("ATTRIBUTE7")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute7 { get; set; }

    [Column("ATTRIBUTE8")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute8 { get; set; }

    [Column("ATTRIBUTE9")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute9 { get; set; }

    [Column("ATTRIBUTE10")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute10 { get; set; }

    [Column("ATTRIBUTE11")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute11 { get; set; }

    [Column("ATTRIBUTE12")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute12 { get; set; }

    [Column("ATTRIBUTE13")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute13 { get; set; }

    [Column("ATTRIBUTE14")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute14 { get; set; }

    [Column("ATTRIBUTE15")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Attribute15 { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
