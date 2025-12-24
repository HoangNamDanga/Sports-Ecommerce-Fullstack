using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Model.DhnProducts
{
    public class DhnBestSellerProductQuery
    {
        public decimal Id { get; set; }
        public string? ProductName { get; set; }
        public decimal? CurrentPrice { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public string? ThumbnailUrl { get; set; }
    }
}
