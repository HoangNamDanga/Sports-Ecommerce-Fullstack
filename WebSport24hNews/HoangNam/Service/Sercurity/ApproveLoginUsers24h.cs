using WebSport24hNews.Models;

namespace WebSport24hNews.HoangNam.Service.Sercurity
{
    public class ApproveLoginUsers24h
    {
        public decimal Id { get; set; } // Thêm Id để khớp với cột ID trong bảng

        public decimal? UserId { get; set; }

        public string? Ip { get; set; }

        public bool? IsLogin { get; set; }

        public bool? IsLogout { get; set; }

        public virtual User24h? User { get; set; }
    }
}
