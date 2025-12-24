using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Model._24hRelatedArticles
{
    public class RelatedArticlesQuery
    {

        public decimal Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string? Slug { get; set; }
        public string? FeaturedImage { get; set; }
        public decimal? CategoryId { get; set; }
    }
}
