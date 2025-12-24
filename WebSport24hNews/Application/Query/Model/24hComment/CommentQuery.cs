namespace WebSport24hNews.Application.Query.Model._24hComment
{
    public class CommentQuery
    {
        public decimal Id { get; set; }

        public decimal? ArticleId { get; set; }

        public decimal? UserId { get; set; }

        public decimal? VideoId { get; set; }
        public string Content { get; set; } = null!;

        public decimal? ParentCommentId { get; set; }
        // ✅ Hiển thị UI
        public string? FullName { get; set; }  // Lấy từ bảng User
        public string? AvatarUrl { get; set; } // Nếu có ảnh đại diện
        public bool? IsApproved { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }

        public DateTime LastUpdateDate { get; set; }
        public List<CommentQuery> Children { get; set; } = new List<CommentQuery>();

        //thiết lập quan hệ cha-con trong danh sách comment, cấu trúc cây bình luận dựa vào id và parrentCommentId. Việc này giúp phân biệt các bình luận gốc và các bình luận phản hồi (reply)
    }
}
