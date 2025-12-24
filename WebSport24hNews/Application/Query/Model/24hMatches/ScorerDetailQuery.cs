namespace WebSport24hNews.Application.Query.Model._24hMatches
{
    public class ScorerDetailQuery
    {
        public string PlayerName { get; set; }
        public string TimeScored { get; set; }  // vd: "49'", "90+5'"
        public string Note { get; set; } // vd: "Pen" hoặc ""
    }
}
