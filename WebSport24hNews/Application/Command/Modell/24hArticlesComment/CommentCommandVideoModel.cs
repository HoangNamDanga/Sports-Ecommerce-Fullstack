namespace WebSport24hNews.Application.Command.Modell._24hVideos
{
    public class CommentCommandVideoModel
    {
        public decimal VideoId { get; set; }
        public decimal? UserId { get; set; }
        public string Content { get; set; } = null!;
        public decimal? ParentCommentId { get; set; }
    }
}
