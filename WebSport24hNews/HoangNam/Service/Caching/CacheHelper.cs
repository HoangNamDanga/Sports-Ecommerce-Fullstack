namespace WebSport24hNews.HoangNam.Service.Caching
{
    public static class CacheHelper
    {
        public static class CacheConfig
        {
            public static class ProviderNames
            {
                public static readonly string InMemory = "Base:Caching:InMemory";

                public static readonly string Redis = "Base:Caching:Redis";

                public static readonly string Hybrid = "Base:HybridCaching";
            }

            public static class ConfigSectionNames
            {
                public static readonly string InMemory = "Caching:InMemory";

                public static readonly string Redis = "Caching:Redis";

                public static readonly string RedisBus = "Caching:RedisBus";
            }

            public static readonly string CacheName = "Base:Caching";

            public static readonly string HybridTopicName = "Base:Caching:Hybrid";

            public const string WithJson_Name = "myjson";

            public const string InMemory = "localCache";

            public const string Redis = "redisCache";

            public const string TopicName = "hybridCacheTopic";

            public const string HybridName = "hybridCache";
        }
    }
}
