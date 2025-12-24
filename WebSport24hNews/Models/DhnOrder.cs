using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("DHN_ORDERS")]
public partial class DhnOrder  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID", TypeName = "NUMBER")]
    public decimal Id { get; set; }

    [Column("CUSTOMER_NAME")]
    [StringLength(255)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

    [Column("PHONE_NUMBER")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column("PROVINCE")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Province { get; set; }

    [Column("DISTRICT")]
    [StringLength(100)]
    [Unicode(false)]
    public string? District { get; set; }

    [Column("WARD")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Ward { get; set; }

    [Column("SHIPPING_ADDRESS")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ShippingAddress { get; set; }

    [Column("DELIVERY_NOTES", TypeName = "CLOB")]
    public string? DeliveryNotes { get; set; }

    [Column("TOTAL_AMOUT", TypeName = "NUMBER(10,2)")]
    public decimal? TotalAmout { get; set; }

    [Column("PAYMENT_METHOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentMethod { get; set; }

    [Column("ORDER_STATUS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OrderStatus { get; set; }

    [Column("ATTRIBUTE1")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute1 { get; set; }

    [Column("ATTRIBUTE2")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute2 { get; set; }

    [Column("ATTRIBUTE3")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute3 { get; set; }

    [Column("ATTRIBUTE4")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute4 { get; set; }

    [Column("ATTRIBUTE5")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute5 { get; set; }

    [Column("ATTRIBUTE6")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute6 { get; set; }

    [Column("ATTRIBUTE7")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute7 { get; set; }

    [Column("ATTRIBUTE8")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute8 { get; set; }

    [Column("ATTRIBUTE9")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute9 { get; set; }

    [Column("ATTRIBUTE10")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute10 { get; set; }

    [Column("ATTRIBUTE11")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute11 { get; set; }

    [Column("ATTRIBUTE12")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute12 { get; set; }

    [Column("ATTRIBUTE13")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute13 { get; set; }

    [Column("ATTRIBUTE14")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Attribute14 { get; set; }

    [Column("ATTRIBUTE15")]
    [StringLength(100)]
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
