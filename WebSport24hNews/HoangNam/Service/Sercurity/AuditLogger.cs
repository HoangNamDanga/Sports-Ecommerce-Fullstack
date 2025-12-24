using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.Models;

namespace WebSport24hNews.HoangNam.Service.Sercurity
{
    public class AuditLogger : IAuditLogger
    {
        private readonly IRepositoryService _repositoryService;

        public AuditLogger(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public async Task LogAsync(string username, string action, string? note = null, string? phone = null, string? fullname = null)
        {
            var log = new UserAuditlog24h
            {
                Username = username,
                Action = action,
                Note = note,
                Phone = phone,
                Fullname = fullname
            };

            await _repositoryService.AddAsync(log);
        }
    }
}
