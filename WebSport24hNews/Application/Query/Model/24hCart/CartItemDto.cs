namespace WebSport24hNews.Application.Query.Handler._24hCart
{
    public class CartItemDto
    {
        public decimal Id { get; set; }
        public decimal ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Quantity { get; set; }
        public string? ThumbnailUrl { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? ProductSize { get; set; }
        public string? MaterialType { get; set; }
    }
}
