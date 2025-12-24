namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    public interface IPagedList<T> where T : class
    {
        int Count { get; set; }
        IList<T> Lists { get; set; }
    }
}
