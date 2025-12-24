namespace WebSport24hNews.Application.Query.Model._24hProductVariant
{
    public class DhnNewsArticleDto
    {
        public decimal Id { get; set; }                  // Khớp với entity (NUMBER in Oracle)
        public string? Title { get; set; }               // Nullable string
        public string? ImageUrl { get; set; }            // Nullable string
        public DateTime? PublishedDate { get; set; }     // Nullable date
        public string? Author { get; set; }
    }
}
