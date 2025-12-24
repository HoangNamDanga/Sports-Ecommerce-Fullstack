namespace WebSport24hNews.Application.Query.Model._24hMatches
{
    //DTO cho mỗi khối giải đấu (dữ liệu trả về từ API) Mỗi khối là 1 leagueName
    public class LeagueFixturesQuery
    {
        public string LeagueName { get; set; } // Tên giải đấu
        public List<FixtureMatchQuery> Matches { get; set; } // Danh sách các trận đấu thuộc giải đó
    }
}
