using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Model._24hProduct
{
    public class DhnProductQuery
    {

        public decimal Id { get; set; }

        public string? ProductName { get; set; }


        public decimal? CategoryId { get; set; }

        public decimal? OriginalPrice { get; set; }

        public decimal? CurrentPrice { get; set; }


        public string? Brand { get; set; }


        public string? Description { get; set; }


        public decimal? StockQuantity { get; set; }


        public string? IsBestSeller { get; set; }


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
