namespace WebSport24hNews.Application.Query.Model._24hPlayers
{
    public class TopGoalPlayerQuery
    {
        public decimal PlayerId { get; set; }
        public string? PlayerName { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}
