namespace WebSport24hNews.Application.Query.Model._24hProductVariant
{
    public class DhnProductDto
    {
        public decimal ProductID { get; set; }
        public string? ProductName { get; set; }
        public decimal? CategoryId { get; set; }
        public decimal? CurrentPrice { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public string? ThumbnailUrl { get; set; } // Thumbnail chính của sản phẩm

        // Danh sách các biến thể của sản phẩm này
        public List<DhnProductVariantDetailDto> Variants { get; set; } = new List<DhnProductVariantDetailDto>();
        //public List<DhnNewsArticleDto>? RelatedArticles { get; set; } // Bổ sung
    }
}
