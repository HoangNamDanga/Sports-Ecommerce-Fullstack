using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;

namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    public class BaseEngine : IEngine
    {
        public virtual IServiceProvider ServiceProvider { get; protected set; }

        protected IServiceProvider GetServiceProvider(IServiceScope scope = null)
        {
            if (scope == null)
            {
                return ((ServiceProvider?.GetService<IHttpContextAccessor>())?.HttpContext)?.RequestServices ?? ServiceProvider;
            }

            return scope.ServiceProvider;
        }

        public void ConfigureRequestPipeline(IApplicationBuilder application)
        {
            ServiceProvider = application.ApplicationServices;
        }



        public virtual IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }

        public virtual object ResolveUnregistered(Type type)
        {
            Exception innerException = null;
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo constructorInfo in constructors)
            {
                try
                {
                    IEnumerable<object> source = constructorInfo.GetParameters().Select(delegate (ParameterInfo parameter)
                    {
                        object obj = Resolve(parameter.ParameterType, null);
                        if (obj == null)
                        {
                            throw new BaseException("Unknown dependency");
                        }

                        return obj;
                    });
                    return Activator.CreateInstance(type, source.ToArray());
                }
                catch (Exception ex)
                {
                    innerException = ex;
                }
            }

            throw new BaseException("No constructor was found that had all the dependencies satisfied.", innerException);
        }



        public T Resolve<T>(string name = null, params Autofac.Core.Parameter[] parameters) where T : class
        {
            return (T)Resolve(typeof(T), name);
        }

        public object Resolve(Type type, string name, params Autofac.Core.Parameter[] parameters)
        {
            IServiceProvider serviceProvider = GetServiceProvider();
            if (serviceProvider == null)
            {
                return null;
            }

            return (!string.IsNullOrEmpty(name)) ? serviceProvider.GetAutofacRoot().ResolveNamed(name, type, parameters) : serviceProvider.GetService(type);
        }
    }
}
