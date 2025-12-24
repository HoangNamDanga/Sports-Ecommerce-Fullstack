namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    public class PagedList<T> : IPagedList<T> where T : class // triển khai interface
    {
        public int Count { get; set; }
        public IList<T> Lists { get; set; }

        public PagedList()
        {
            Lists = new List<T>();
        }
    }
}
