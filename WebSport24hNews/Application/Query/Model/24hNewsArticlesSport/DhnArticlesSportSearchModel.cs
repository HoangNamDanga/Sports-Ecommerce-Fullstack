using WebSport24hNews.HoangNam.Core.Infrastructure;

namespace WebSport24hNews.Application.Query.Model._24hNewsArticlesSport
{
    public class DhnArticlesSportSearchModel : BaseSearchModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
