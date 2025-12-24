namespace WebSport24hNews.Application.Command.Modell._24hCart
{
    public class AddToCartDto
    {
        public decimal? UserId { get; set; }
        public string? SessionId { get; set; }
        public decimal ProductId { get; set; }
        public decimal Quantity { get; set; }

        public string? ProductSize { get; set; }
        public string? MaterialType { get; set; }
        public decimal? VariantPrice { get; set; }
    }
}
