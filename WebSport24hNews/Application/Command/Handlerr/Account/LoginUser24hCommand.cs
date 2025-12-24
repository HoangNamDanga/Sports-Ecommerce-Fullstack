using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Security.Claims;
using WebSport24hNews.Application.Command.Modell.Account;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr.Account
{
    public class LoginUser24hCommand : ICommandBase<LoginUser24hResponse>
    {
        public LoginUser24h loginUser24h { get; set; }
    }
    public class LoginUser24hQueryHandler : IRequestBaseHandler<LoginUser24hCommand, LoginUser24hResponse>
    {
        private readonly IConfiguration _configuration;

        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public LoginUser24hQueryHandler(IRepositoryService repositoryService, IConfiguration configuration,IMapper mapper,  IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
            _configuration = configuration;
        }

        public async Task<LoginUser24hResponse> Handle(LoginUser24hCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var user = await _repositoryService
                .Where<User24h>(u => u.Username == request.loginUser24h.Username && (u.Inactive.Equals(0) || u.Inactive == null))
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.loginUser24h.Password, user.Password))
                return new LoginUser24hResponse
                {
                    IsAuthenticated = false,
                    Message = "Tài khoản hoặc mật khẩu không hợp lệ !"
                };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username ?? ""),
                new Claim("Role", user.Role ?? ""),
                new Claim("Empid", user.Empid?.ToString() ?? "0")
            };

            string accToken = _authorizeExtension.GenerateJWT(claims, 120); // 2 giờ
            string refreshToken = await _authorizeExtension.GenerateRefreshToken(user.Id.ToString());

            var newTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken,
                ExpiryDate = Extension.Now().AddDays(_configuration.GetValue<int>("Jwt:ExpiresInDays")),
                CreatedDate = Extension.Now(),
                Revoked = "N"
            };
            await _repositoryService.AddAsync(newTokenEntity, cancellationToken);

            //Lưu log
            var log = new ApproveLoginUsers24h
            {
                UserId = user.Id,
                IsLogin = true,
                IsLogout = false,
                Ip = _authorizeExtension.Token != null ? _authorizeExtension.GetClientIp() ?? "Unknown" : "Unknown"
            };


            var logDb = _mapper.Map<ApproveLoginUser24h>(log);
            var result = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;

            return new LoginUser24hResponse
            {
                IsAuthenticated = result,
                RefreshToken = refreshToken, // <-- THÊM DÒNG NÀY
                AccessToken = accToken,
                Fullname = user.Fullname,
                Message = "Đăng nhập thành công !"
            };
        }
    }

}
