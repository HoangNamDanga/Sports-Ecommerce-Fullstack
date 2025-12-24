namespace WebSport24hNews.Application.Command.Modell._24hLeagues
{
    public class LeaguesCommand
    {
        public decimal Id { get; set; }
        public string? LeagueName { get; set; }

        public string? RegionCountry { get; set; }

        public bool? Division { get; set; }
        public DateTime? SeasonStart { get; set; }

        public DateTime? SeasonEnd { get; set; }
        public string? LogoUrl { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
