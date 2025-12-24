namespace WebSport24hNews.Application.Query.Model._24hArticles
{
    public class ArticlesThreeCategoriesMasterQuery
    {
       public string? CategoryName { get; set; }
       public List<ArticlesThreeCategoriesQuery> articles { get; set; }
    }
}
