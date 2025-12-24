using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Modell._24hMatches
{
    public class MatchesCommand
    {
        public decimal Id { get; set; }
        public decimal? HomeTeamId { get; set; }
        public decimal? AwayTeamId { get; set; }

        public decimal? LeagueId { get; set; }

        public DateTime? MatchDate { get; set; }

        public string? Stadium { get; set; }

        public byte? FirstHalfScoreHome { get; set; }
        public byte? FirstHalfScoreAway { get; set; }

        public byte? FullTimeScoreHome { get; set; }

        public byte? FullTimeScoreAway { get; set; }

        public string? Status { get; set; }

        public string? Referee { get; set; }
        public decimal? Attendance { get; set; }

        public decimal CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? LastUpdateBy { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
