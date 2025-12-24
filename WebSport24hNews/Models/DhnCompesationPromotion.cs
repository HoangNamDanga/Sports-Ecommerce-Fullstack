using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Table("DHN_COMPESATION_PROMOTION")]
public partial class DhnCompesationPromotion  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("ID")]
    [Precision(15)]
    public long Id { get; set; }

    [Column("CODE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Code { get; set; }

    [Column("SOURCE_DOCUMENT_NUMBER")]
    [StringLength(255)]
    [Unicode(false)]
    public string? SourceDocumentNumber { get; set; }

    [Column("ORDER_ID")]
    [Precision(15)]
    public long? OrderId { get; set; }

    [Column("BRANCH_ID")]
    [Precision(15)]
    public long? BranchId { get; set; }

    [Column("FROM_INV_SUB_ID")]
    [Precision(15)]
    public long? FromInvSubId { get; set; }

    [Column("DELIVERY_PERSON_ID")]
    [Precision(15)]
    public long? DeliveryPersonId { get; set; }

    [Column("CUSTOMER_RECEIVED_ID")]
    [Precision(15)]
    public long? CustomerReceivedId { get; set; }

    [Column("LOCATION_ID")]
    [Precision(15)]
    public long? LocationId { get; set; }

    [Column("MANAGE_ID")]
    [Precision(15)]
    public long? ManageId { get; set; }

    [Column("APPROVER_BY")]
    [Precision(15)]
    public long? ApproverBy { get; set; }

    [Column("REQUESTCHECKED", TypeName = "NUMBER(1)")]
    public bool? Requestchecked { get; set; }

    [Column("NOTE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Note { get; set; }

    [Column("SOURCE_CODE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? SourceCode { get; set; }

    [Column("CREATE_BY", TypeName = "NUMBER")]
    public decimal CreateBy { get; set; }

    [Column("CREATE_DATE", TypeName = "DATE")]
    public DateTime CreateDate { get; set; }

    [Column("LAST_UPDATE_BY", TypeName = "NUMBER")]
    public decimal? LastUpdateBy { get; set; }

    [Column("LAST_UPDATE_DATE", TypeName = "DATE")]
    public DateTime LastUpdateDate { get; set; }
}
