namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    public interface IEngine
    {
        void ConfigureRequestPipeline(IApplicationBuilder application);

        T Resolve<T>(string name = null, params Autofac.Core.Parameter[] parameters) where T : class;

        object Resolve(Type type, string name, params Autofac.Core.Parameter[] parameters);

        IEnumerable<T> ResolveAll<T>();

        object ResolveUnregistered(Type type);
    }
}
