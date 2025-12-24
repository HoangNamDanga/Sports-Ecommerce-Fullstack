namespace WebSport24hNews.HoangNam.Service.Sercurity
{
    public interface IAuditLogger
    {
        Task LogAsync(string username, string action, string? note = null, string? phone = null, string? fullname = null);
    }
}
