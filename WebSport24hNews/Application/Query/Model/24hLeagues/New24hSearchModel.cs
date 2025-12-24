using WebSport24hNews.HoangNam.Core.Infrastructure;

namespace WebSport24hNews.Application.Query.Model._24hLeagues
{
    public class New24hSearchModel : BaseSearchModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
