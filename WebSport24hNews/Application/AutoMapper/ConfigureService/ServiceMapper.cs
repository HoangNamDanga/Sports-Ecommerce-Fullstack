using Microsoft.AspNetCore.Identity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.AutoMapper.ConfigureService
{
    public static class ServiceMapper
    {
        //suwr dung auto.fact 
        //Đây là cách tạo cấu hình dịch vụ. bên programs chỉ cần gọi AddMapper, tương tự các cái khác như 
        //public static IServiceCollection AddUser24hServices(this IServiceCollection services)
        //{
        //    services.AddScoped<IPasswordHasher<User24h>, PasswordHasher<User24h>>();
        //    // thêm các service khác nếu cần

        //    return services;
        //}
        public static void AddMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(HoangNamProfile).Assembly);
        }
    }
}
