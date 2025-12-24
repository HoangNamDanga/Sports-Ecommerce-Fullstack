using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;
using WebSport24hNews.Application.Query.Model._24hRelatedArticles;

namespace WebSport24hNews.Application.Query.Model._24hArticles
{
    public class ArticlesQuery
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


        public bool? IsFeatured { get; set; }

        public decimal CreateBy { get; set; }


        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }


        public DateTime LastUpdateDate { get; set; }


        public decimal? CategoryId { get; set; }
        // nếu quản hệ 1-n thì mở comment. public IEnumerable<RelatedArticlesQuery> relatedArticlesQuery { get; set; }
    }
}
