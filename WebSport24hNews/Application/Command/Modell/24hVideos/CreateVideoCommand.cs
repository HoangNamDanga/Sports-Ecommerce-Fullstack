namespace WebSport24hNews.Application.Command.Modell._24hVideos
{
    public class CreateVideoCommand
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string YoutubeUrl { get; set; } = null!; // Link Youtube input (ví dụ https://youtu.be/abc123)
        public decimal? TeamId { get; set; }
        public decimal? LeagueId { get; set; }
        public decimal? AuthorId { get; set; }
        public string? Duration { get; set; }
        public DateTime? PublishedAt { get; set; }
        public decimal CreateBy { get; set; }
    }
}
