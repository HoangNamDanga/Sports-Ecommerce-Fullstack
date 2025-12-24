using System.Security.Claims;

namespace WebSport24hNews.HoangNam.Service.Sercurity
{
    public interface IAuthorizeExtensionService
    {
        bool IsAuthenticated { get; }

        string UserName { get; }

        long Empid { get; }

        string Token { get; }

        string AcessToken { get; }

        string RoleHealCheck { get; }

        string GenerateJWT(IList<Claim> claims, int time);

        string ClaimType(string type);

        Task<string> GenerateRefreshToken(string id);
        string GetClientIp();
        Task<UserMasterBaseModel> GetUser();

        Task<bool> CheckAuthKey(string key);

        Task<string> CheckRefreshToken(string id, string token);
    }
}
