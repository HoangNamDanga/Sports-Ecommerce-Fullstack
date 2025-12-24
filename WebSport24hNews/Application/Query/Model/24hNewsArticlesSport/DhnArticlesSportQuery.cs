using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Model._24hNewsArticlesSport
{
    public class DhnArticlesSportQuery
    {

        public decimal Id { get; set; }

        public string? Title { get; set; }
        public string? Content { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string? Author { get; set; }

        public decimal? Views { get; set; }

        public string? Attribute1 { get; set; }

        public string? Attribute2 { get; set; }
        public string? Attribute3 { get; set; }

        public string? Attribute4 { get; set; }

        public string? Attribute5 { get; set; }

        public string? Attribute6 { get; set; }

        public string? Attribute7 { get; set; }

        public string? Attribute8 { get; set; }

        public string? Attribute9 { get; set; }
        public string? Attribute10 { get; set; }
        public string? Attribute11 { get; set; }

        public string? Attribute12 { get; set; }

        public string? Attribute13 { get; set; }

        public string? Attribute14 { get; set; }

        public string? Attribute15 { get; set; }


        public decimal CreateBy { get; set; }


        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
