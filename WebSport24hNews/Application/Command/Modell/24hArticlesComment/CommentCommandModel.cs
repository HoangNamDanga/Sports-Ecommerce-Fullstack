using WebSport24hNews.Application.Query.Model._24hComment;

namespace WebSport24hNews.Application.Command.Modell._24hArticlesComment
{
    public class CommentCommandModel
    {
        public decimal ArticleId { get; set; }
        public decimal? UserId { get; set; }
        public string Content { get; set; } = null!;
        public decimal? ParentCommentId { get; set; }
    }
}
