using AutoMapper;
using WebSport24hNews.Application.Command.Handlerr.Account;
using WebSport24hNews.Application.Command.Modell.Account;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr.Account
{
    public class LogoutUser24hCommand : ICommandBase<LogoutUser24hResponse>
    {
        public decimal UserId { get; set; }
        public string RefreshToken { get; set; }
    }
    public class LogoutUser24hCommandHandler : IRequestBaseHandler<LogoutUser24hCommand, LogoutUser24hResponse>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public LogoutUser24hCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<LogoutUser24hResponse> Handle(LogoutUser24hCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.UserId == null || string.IsNullOrEmpty(request.RefreshToken))
                throw new BaseException("Yêu cầu không hợp lệ!");

            // Kiểm tra xem user có tồn tại không
            var user = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<User24h>(u => u.Id == request.UserId);
            if (user == null)
                throw new BaseException("Người dùng không tồn tại!");

            // Ghi lại thông tin đăng xuất vào log
            var log = new ApproveLoginUsers24h
            {
                UserId = request.UserId,
                IsLogin = false,
                IsLogout = true,
                Ip = _authorizeExtension.GetClientIp() ?? "Unknown"
            };

            var logDb = _mapper.Map<ApproveLoginUser24h>(log);
            await _repositoryService.AddAsync(logDb, cancellationToken);

            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi tạo phê duyệt Login");

            return new LogoutUser24hResponse
            {
                IsLoggedOut = saveResult,
                Message = "Đăng xuất thành công!"
            };
        }
    }
}
