namespace WebSport24hNews.Application.Query.Model._24hMatches
{

    //lớp dto cho mỗi trận đấu trong lịch thi đấu
    public class FixtureMatchQuery
    {
        public decimal Id { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string MatchDateTime { get; set; } // Định dạng chuỗi '25/05 22:00'
        public string Status { get; set; }
    }
}
