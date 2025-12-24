namespace WebSport24hNews.Application.Query.Model._24hMatches
{
    public class FixturesDTOCategory
    {
        public decimal Id { get; set; }
        public string LeagueName { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string Status { get; set; } // "SCHEDULED", "FINISHED", ...
        public decimal? HomeScore { get; set; } // có thể null nếu chưa đá
        public decimal? AwayScore { get; set; } // có thể null nếu chưa đá
    }
}
