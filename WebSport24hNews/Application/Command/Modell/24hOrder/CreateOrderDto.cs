namespace WebSport24hNews.Application.Command.Modell._24hOrder
{
    public class CreateOrderDto
    {
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Province { get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? ShippingAddress { get; set; }
        public string? DeliveryNotes { get; set; }
        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();
    }
}
