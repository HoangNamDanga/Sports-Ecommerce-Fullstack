namespace WebSport24hNews.Application.Query.Model._24hMatches
{
    public class MatchesResultQuery
    {
        public decimal Id { get; set; }
        public string LeagueName { get; set; } // Đây là cột từ JOIN LEAGUES
        public string HomeTeam { get; set; }   // Đây là cột từ JOIN TEAMS
        public string AwayTeam { get; set; }   // Đây là cột từ JOIN TEAMS
        public DateTime? MatchDate { get; set; }
        public decimal? HomeScore { get; set; }    // Tên khớp với AS HOME_SCORE
        public decimal? AwayScore { get; set; }    // Tên khớp với AS AWAY_SCORE
        public string Status { get; set; }
    }
}
