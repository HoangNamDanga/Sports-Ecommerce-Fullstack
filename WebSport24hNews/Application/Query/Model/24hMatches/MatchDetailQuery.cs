namespace WebSport24hNews.Application.Query.Model._24hMatches
{

    //DTO phục vụ API trả ra kết quả 1 trận đấu cũng như thông tin về đội hình ra sân , thay người dự bị
    public class MatchDetailQuery
    {
        public decimal Id { get; set; }
        public string LeagueName { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime? MatchDate { get; set; }
        public decimal? HomeScore { get; set; }
        public decimal? AwayScore { get; set; }

        public string? AggregateScore { get; set; } // Tỷ số sau 2 lượt trận, nếu có
        public List<ScorerDetailQuery> HomeScorers { get; set; }
        public List<ScorerDetailQuery> AwayScorers { get; set; }

        public LineupDetailQuery HomeLineup { get; set; }
        public LineupDetailQuery AwayLineup { get; set; }
    }
}
