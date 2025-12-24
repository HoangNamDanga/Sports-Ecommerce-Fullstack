namespace WebSport24hNews.Application.Command.Modell._24hPlayers
{
    public class PlayersCommand
    {
        public decimal Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Nationality { get; set; }

        public DateTime? BirthDate { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public string? Position { get; set; }

        public decimal? TeamId { get; set; }
        public byte? JerseyNumber { get; set; }

        public string? PhotoUrl { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
