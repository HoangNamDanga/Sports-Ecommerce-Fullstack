namespace WebSport24hNews.Application.Command.Modell._24hVideos
{
    public class UpdateVideoRequest
    {
        public decimal Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? YoutubeUrl { get; set; } // Có thể có để lấy videoId, embedUrl, thumbnailUrl
        public decimal? TeamId { get; set; }
        public decimal? LeagueId { get; set; }
        public decimal? AuthorId { get; set; }
        public string? Duration { get; set; }
        public DateTime? PublishedAt { get; set; }
        public decimal UpdateBy { get; set; }
    }
}
