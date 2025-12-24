using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Modell._24hProductVariant
{
    public class DhnProductVariantDto
    {
        public decimal ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? Brand { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public decimal VariantPrice { get; set; }
        public string? MaterialType { get; set; }
        public string? ProductSize { get; set; }
        public string? Color { get; set; }

        public string? ThumbnailUrl { get; set; }
    }
}
