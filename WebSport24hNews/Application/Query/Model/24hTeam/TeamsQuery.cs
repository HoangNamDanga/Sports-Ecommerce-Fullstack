using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Model._24hTeam
{
    public class TeamsQuery
    {
        public decimal Id { get; set; }

        public string TeamName { get; set; } = null!;

        public string? TeamCode { get; set; }

        public string? Country { get; set; }

        public string? LogoUrl { get; set; }

        public decimal? LeagueId { get; set; }

        public decimal? FoundedYear { get; set; }

        public string? Stadium { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
