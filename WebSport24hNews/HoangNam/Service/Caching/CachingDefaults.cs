namespace WebSport24hNews.HoangNam.Service.Caching
{
    public static class CachingDefaults
    {
        public static string DataProtectionKeysName = "DataProtectionKeys";

        public static int CacheTime => 8640;

        public static int ShortTermCacheTime => 5;

        public static int DayCacheTime => 1440;

        public static int MonthCacheTime => 43200;

        public static int MaxCacheTime => int.MaxValue;

        public static int BundledFilesCacheTime { get; set; } = 120;


        public static string EntityByIdCacheKey => "base.{0}.byid-{1}";

        public static string EntityPrefix => "base.{0}";
    }
}
