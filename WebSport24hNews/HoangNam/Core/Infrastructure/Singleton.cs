namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    public class Singleton<T> : BaseSingleton
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
                BaseSingleton.AllSingletons[typeof(T)] = value;
            }
        }
    }
}
