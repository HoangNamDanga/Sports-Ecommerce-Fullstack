namespace WebSport24hNews.Application.Query.Model.ArticlesCommentQuery
{
    public class CommentModelQuery
    {
        public decimal Id { get; set; }
        public decimal ArticleId { get; set; }

        // Nội dung của bình luận
        public string Content { get; set; }
        public decimal? ParentCommentId { get; set; }
        public string AuthorFullname { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
