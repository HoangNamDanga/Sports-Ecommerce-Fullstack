using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSport24hNews.HoangNam.Service.Sercurity
{
    public class UserMasterBaseModel
    {
        [Key]
        [Column("ID", TypeName = "NUMBER")]
        public decimal Id { get; set; }

        [Column("USERNAME")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Username { get; set; }

        [Column("PASSWORD")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Password { get; set; }

        [Column("INACTIVE", TypeName = "NUMBER(1)")]
        public bool? Inactive { get; set; }

        [Column("ROLE")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Role { get; set; }

        [Column("PHONE")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Phone { get; set; }

        [Column("FULLNAME")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Fullname { get; set; }

        [Column("MODIFYDATE", TypeName = "DATE")]
        public DateTime? Modifydate { get; set; }

        [Column("MODIFYBY")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Modifyby { get; set; }

        [Column("CREATEDATE", TypeName = "DATE")]
        public DateTime? Createdate { get; set; }

        [Column("CREATEBY")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Createby { get; set; }

        [Column("TOKENACTIVE")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Tokenactive { get; set; }

        [Column("DATEACTIVE", TypeName = "DATE")]
        public DateTime? Dateactive { get; set; }

        [Column("CODEACTIVE")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Codeactive { get; set; }

        [Column("DATECODEACTIVE", TypeName = "DATE")]
        public DateTime? Datecodeactive { get; set; }

        [Column("CENTER")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Center { get; set; }

        [Column("ADDGOOGLE", TypeName = "NUMBER(1)")]
        public bool? Addgoogle { get; set; }

        [Column("EMPID", TypeName = "NUMBER")]
        public decimal? Empid { get; set; }
        public IEnumerable<ApproveLoginUsers24h> ListApproveLogin { get; set; }
        public UserMasterBaseModel()
        {
            ListApproveLogin = new List<ApproveLoginUsers24h>();
        }
    }
}
