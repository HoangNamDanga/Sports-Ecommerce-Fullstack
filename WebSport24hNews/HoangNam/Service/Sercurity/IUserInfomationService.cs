namespace WebSport24hNews.HoangNam.Service.Sercurity
{
    public interface IUserInfomationService
    {
        Task<bool> GetAuthozireByUserId(string idUser, string authRole);
    }
}
