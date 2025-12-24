using WebSport24hNews.Application.Command.Modell._24hComment;

namespace WebSport24hNews.Application.Command.Modell._24hArticlesComment
{
    public class ArticlesCommentCommand
    {
        public decimal Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public string? Summary { get; set; }

        public decimal? AuthorId { get; set; }

        public decimal? TeamId { get; set; }
        public DateTime? PublishedAt { get; set; }

        public string? Slug { get; set; }

        public string? FeaturedImage { get; set; }

        public decimal? ViewCount { get; set; }
        public decimal? CategoryId { get; set; }

        public bool? IsFeatured { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public IEnumerable<CommentCommand> commentCommand { get; set; }
    }
}
