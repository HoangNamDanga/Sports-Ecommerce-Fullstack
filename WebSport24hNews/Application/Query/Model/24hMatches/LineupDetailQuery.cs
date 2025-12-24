namespace WebSport24hNews.Application.Query.Model._24hMatches
{
    public class LineupDetailQuery
    {
        public string Formation { get; set; }   // ví dụ: "4-3-3" hoặc "4-2-3-1"
        public List<PlayerDetailQuery> Starters { get; set; }       // đá chính
        public List<SubstitutionDetailQuery> Substitutions { get; set; } // thay người
    }
}
