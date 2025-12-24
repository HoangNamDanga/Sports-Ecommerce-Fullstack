using System.Runtime.CompilerServices;

namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    public class EngineContext
    {
        public static IEngine EngineResolve => Current;

        public static IEngine Current => Singleton<IEngine>.Instance ?? Create();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create()
        {
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new BaseEngine());
        }

        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }
    }
}
