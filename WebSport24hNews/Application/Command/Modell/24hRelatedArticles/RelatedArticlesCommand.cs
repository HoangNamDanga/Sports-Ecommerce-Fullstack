namespace WebSport24hNews.Application.Command.Modell._24hRelatedArticles
{
    public class RelatedArticlesCommand
    {
        public decimal PrimaryArticleId { get; set; }


        public decimal RelatedArticleId { get; set; }

        public string? RelationType { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
