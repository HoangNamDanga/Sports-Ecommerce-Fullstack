using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Model._24hProductImage
{
    public class DhnProductImageQuery
    {

        public decimal Id { get; set; }


        public decimal? ProductId { get; set; }


        public string? ImageUrl { get; set; }


        public string? IsThumbnail { get; set; }


        public decimal? DisplayOrder { get; set; }


        public string? AltText { get; set; }

        public string? Attribute1 { get; set; }

        public string? Attribute2 { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
