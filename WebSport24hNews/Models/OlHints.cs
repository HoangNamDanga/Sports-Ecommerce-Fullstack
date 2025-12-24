using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[Keyless]
[Table("OL$HINTS")]
[Index("OlName", "Hint", Name = "OL$HNT_NUM", IsUnique = true)]
public partial class OlHints  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Column("OL_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? OlName { get; set; }

    [Column("HINT#", TypeName = "NUMBER")]
    public decimal? Hint { get; set; }

    [Column("CATEGORY")]
    [StringLength(128)]
    [Unicode(false)]
    public string? Category { get; set; }

    [Column("HINT_TYPE", TypeName = "NUMBER")]
    public decimal? HintType { get; set; }

    [Column("HINT_TEXT")]
    [StringLength(512)]
    [Unicode(false)]
    public string? HintText { get; set; }

    [Column("STAGE#", TypeName = "NUMBER")]
    public decimal? Stage { get; set; }

    [Column("NODE#", TypeName = "NUMBER")]
    public decimal? Node { get; set; }

    [Column("TABLE_NAME")]
    [StringLength(128)]
    [Unicode(false)]
    public string? TableName { get; set; }

    [Column("TABLE_TIN", TypeName = "NUMBER")]
    public decimal? TableTin { get; set; }

    [Column("TABLE_POS", TypeName = "NUMBER")]
    public decimal? TablePos { get; set; }

    [Column("REF_ID", TypeName = "NUMBER")]
    public decimal? RefId { get; set; }

    [Column("USER_TABLE_NAME")]
    [StringLength(260)]
    [Unicode(false)]
    public string? UserTableName { get; set; }

    [Column("COST", TypeName = "FLOAT")]
    public decimal? Cost { get; set; }

    [Column("CARDINALITY", TypeName = "FLOAT")]
    public decimal? Cardinality { get; set; }

    [Column("BYTES", TypeName = "FLOAT")]
    public decimal? Bytes { get; set; }

    [Column("HINT_TEXTOFF", TypeName = "NUMBER")]
    public decimal? HintTextoff { get; set; }

    [Column("HINT_TEXTLEN", TypeName = "NUMBER")]
    public decimal? HintTextlen { get; set; }

    [Column("JOIN_PRED")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? JoinPred { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("HINT_STRING", TypeName = "CLOB")]
    public string? HintString { get; set; }
}
