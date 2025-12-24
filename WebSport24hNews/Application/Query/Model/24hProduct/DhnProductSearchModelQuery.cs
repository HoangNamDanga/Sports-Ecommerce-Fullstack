using WebSport24hNews.HoangNam.Core.Infrastructure;

namespace WebSport24hNews.Application.Query.Model._24hProduct
{
    public class DhnProductSearchModelQuery : BaseSearchModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
