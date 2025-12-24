namespace WebSport24hNews.Application.Query.Model._24hComment
{
    public class CommentsSingleQuery
    {
        public decimal Id { get; set; }

        public decimal? ArticleId { get; set; }

        public decimal? UserId { get; set; }


        public string Content { get; set; } = null!;

        public decimal? ParentCommentId { get; set; }

        public bool? IsApproved { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
