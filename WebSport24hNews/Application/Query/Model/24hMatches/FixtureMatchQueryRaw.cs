namespace WebSport24hNews.Application.Query.Model._24hMatches
{
    //Việc dùng bảng tạm (temporary table) trong SQL thường được áp dụng trong những tình huống mà bạn cần lưu trữ tạm thời kết quả trung gian để tiếp tục xử lý phức tạp.
    //Dapper sẽ sử dụng để ánh xạ từng hàng dữ liệu "thô" mà Stored Procedure của bạn trả về thông qua REF CURSOR
    //Bảng tạm
    public class FixtureMatchQueryRaw
    {
        // Khớp với M.ID AS MatchId
        public int MatchId { get; set; }

        // Khớp với L.LEAGUE_NAME AS LeagueName
        public string LeagueName { get; set; }

        // Khớp với HT.TEAM_NAME AS HomeTeamName
        public string HomeTeamName { get; set; }

        // Khớp với AT.TEAM_NAME AS AwayTeamName
        public string AwayTeamName { get; set; }

        // Khớp với TO_CHAR(M.MATCH_DATE, 'YYYY-MM-DD HH24:MI') AS MatchDateTime
        // Quan trọng: Nó là string vì đã được format trong SP
        public string MatchDateTime { get; set; }

        // Khớp với M.STATUS AS Status
        public string Status { get; set; }
    }
}
