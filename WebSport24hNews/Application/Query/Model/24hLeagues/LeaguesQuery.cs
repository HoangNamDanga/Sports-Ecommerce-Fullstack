using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSport24hNews.Application.Query.Model._24hLeagues
{
    public class LeaguesQuery
    {
        public decimal Id { get; set; }
        public string? LeagueName { get; set; }

        public string? RegionCountry { get; set; }

        public bool? Division { get; set; }
        public DateTime? SeasonStart { get; set; }

        public DateTime? SeasonEnd { get; set; }
        public string? LogoUrl { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }
        public decimal? LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
