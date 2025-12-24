using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSport24hNews.Application.Query.Model._24hCategories
{
    public class CategoriesQuery
    {
        public decimal Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Slug { get; set; }
        public decimal? ParentId { get; set; }

        public decimal? DisplayOrder { get; set; }
        public decimal? LeagueId { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
