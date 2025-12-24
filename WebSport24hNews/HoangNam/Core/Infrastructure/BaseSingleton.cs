namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    public class BaseSingleton
    {
        public static IDictionary<Type, object> AllSingletons { get; }

        static BaseSingleton()
        {
            AllSingletons = new Dictionary<Type, object>();
        }
    }
}
