namespace WebSport24hNews.HoangNam.Core.Extensions
{
    public static class Collection
    {
        public static void Remove<TSource>(this IList<TSource> source, Func<TSource, bool> func)
        {
            if (!source.AnyList())
            {
                return;
            }

            List<TSource> list = source.Where(func).ToList();
            foreach (TSource item in list)
            {
                source.Remove(item);
            }
        }

        public static bool AnyList<TSource>(this IEnumerable<TSource> source)
        {
            return source != null && source.Any() && source.Count() > 0;
        }

        public static bool NumberZero(this int source)
        {
            return source < 1;
        }

        public static int NumberZero(this int source, int s)
        {
            return (source < 1) ? s : source;
        }

        public static bool CheckTryParseNumber(string id)
        {
            int result;
            return int.TryParse(id, out result);
        }

        public static void AddRange<T>(this ICollection<T> initial, IEnumerable<T> other)
        {
            if (other == null)
            {
                return;
            }

            if (initial is List<T> list)
            {
                list.AddRange(other);
                return;
            }

            foreach (T item in other)
            {
                initial.Add(item);
            }
        }

        public static SyncedCollection<T> AsSynchronized<T>(this ICollection<T> source)
        {
            return source.AsSynchronized(new object());
        }

        public static SyncedCollection<T> AsSynchronized<T>(this ICollection<T> source, object syncRoot)
        {
            return (source is SyncedCollection<T> syncedCollection) ? syncedCollection : new SyncedCollection<T>(source, syncRoot);
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count == 0;
        }
    }
}
