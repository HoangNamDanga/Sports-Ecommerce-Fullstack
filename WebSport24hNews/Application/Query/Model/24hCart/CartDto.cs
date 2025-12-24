namespace WebSport24hNews.Application.Query.Handler._24hCart
{
    public class CartDto
    {
        public decimal Id { get; set; }
        public decimal? UserId { get; set; }
        public string? SessionId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalItems { get; set; }
        public List<CartItemDto> Items { get; set; } = new();
    }
}
