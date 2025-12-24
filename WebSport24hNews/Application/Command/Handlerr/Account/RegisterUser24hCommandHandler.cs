using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebSport24hNews.Application.Command.Modell.Account;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr.Account
{
    public class RegisterUser24hCommandHandler : ICommandBase<RegisterUser24hResponse>
    {
        public RegisterUser24hCommand registerUser24h { get; set; }
    }
    public class RegisterUser24hCommandHandlerBase : IRequestBaseHandler<RegisterUser24hCommandHandler, RegisterUser24hResponse>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IPasswordHasher<User24h> _passwordHasher;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;
        private readonly IAuditLogger _auditLogger;
        public RegisterUser24hCommandHandlerBase(IRepositoryService repositoryService, 
            IMapper mapper, IPasswordHasher<User24h> passwordHasher,
            IAuthorizeExtensionService authorizeExtension, IAuditLogger auditLogger)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authorizeExtension = authorizeExtension;
            _auditLogger = auditLogger;
        }

        public async Task<RegisterUser24hResponse> Handle(RegisterUser24hCommandHandler request, CancellationToken cancellationToken)
        {
            if (request is null) throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;
            var resRegister = await _repositoryService.TransactionSmartAwaitAsync(async () =>
            {
                var exisUsernameUser = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<User24h>(u => u.Username.Equals(request.registerUser24h.Username) || (request.registerUser24h.Phone != null && request.registerUser24h.Phone.Equals(u.Phone)));

                if (exisUsernameUser != null)
                    return new RegisterUser24hResponse
                    {
                        Success = false,
                        Message = "Tài khoản or số điện thoại đã tồn tại vui lòng nhập lại thông tin !",
                    };

                var newUser = _mapper.Map<User24h>(request.registerUser24h);
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(request.registerUser24h.Password);
                newUser.Role = "User";
                await _repositoryService.AddAsync(newUser,cancellationToken);

                await _auditLogger.LogAsync(newUser.Username, "TẠO TÀI KHOẢN MỚI !", "Tạo người dùng từ RegisterUser24h", newUser.Phone, newUser.Fullname);


                var saveResult  = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;

                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi tạo tài khoản !");

                return new RegisterUser24hResponse
                {
                    Success = true,
                    Message = "Đăng ký thành công !"
                };
            }, cancellationToken);

            return resRegister;
        }
    }
}
