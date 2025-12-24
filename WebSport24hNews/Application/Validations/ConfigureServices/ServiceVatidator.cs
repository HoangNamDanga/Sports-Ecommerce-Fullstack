using FluentValidation;
using WebSport24hNews.Application.Command.Handlerr._24hProductImage;
using WebSport24hNews.Application.Command.Modell._24hProduct;
using WebSport24hNews.Application.Command.Modell.Account;

namespace WebSport24hNews.Application.Validations.ConfigureServices
{
    public static class ServiceVatidator
    {
        //khai báo ở đây và đăng kí service cho toàn bộ nhũng th đc khai báo
        public static void AddValidator(this IServiceCollection services)
        {
            services.AddTransient <IValidator<RegisterUser24hCommand>, RegisterUser24hCommandValidator>();

            services.AddTransient<IValidator<DhnProductImageCommand>, Dhn24hProductImageCommandValidator>();

            services.AddTransient<IValidator<DhnProductCommand>, Dhn24hProductCommandValidator>();
        }
    }
}
