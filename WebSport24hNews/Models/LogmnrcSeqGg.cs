using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebSport24hNews.Models;

[PrimaryKey("LogmnrUid", "Obj", "CommitScn")]
[Table("LOGMNRC_SEQ_GG")]
[Index("LogmnrUid", "DropScn", Name = "LOGMNRC_I2SEQGG")]
public partial class LogmnrcSeqGg  : WebSport24hNews.HoangNam.Core.Infrastructure.IAggregateRoot
{
    [Key]
    [Column("LOGMNR_UID", TypeName = "NUMBER")]
    public decimal LogmnrUid { get; set; }

    [Key]
    [Column("OBJ#", TypeName = "NUMBER")]
    public decimal Obj { get; set; }

    [Key]
    [Column("COMMIT_SCN", TypeName = "NUMBER")]
    public decimal CommitScn { get; set; }

    [Column("DROP_SCN", TypeName = "NUMBER")]
    public decimal? DropScn { get; set; }

    [Column("SEQ_FLAGS", TypeName = "NUMBER")]
    public decimal SeqFlags { get; set; }

    [Column("OWNER#", TypeName = "NUMBER")]
    public decimal Owner { get; set; }

    [Column("OWNERNAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Ownername { get; set; } = null!;

    [Column("OBJNAME")]
    [StringLength(384)]
    [Unicode(false)]
    public string Objname { get; set; } = null!;

    [Column("SEQCACHE", TypeName = "NUMBER")]
    public decimal? Seqcache { get; set; }

    [Column("SEQINC", TypeName = "NUMBER")]
    public decimal? Seqinc { get; set; }

    [Column("SPARE1", TypeName = "NUMBER")]
    public decimal? Spare1 { get; set; }

    [Column("SPARE2", TypeName = "NUMBER")]
    public decimal? Spare2 { get; set; }

    [Column("SPARE3")]
    [Unicode(false)]
    public string? Spare3 { get; set; }

    [Column("SPARE4")]
    [Unicode(false)]
    public string? Spare4 { get; set; }
}
