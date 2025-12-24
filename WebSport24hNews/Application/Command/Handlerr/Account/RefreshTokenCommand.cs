using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class RefreshTokenCommand : ICommandBase<RefreshTokenResponse>
    {
        public RefreshTokenRequest refreshTokenRequest { get; set; }
    }
    public class RefreshTokenCommandHandler : IRequestBaseHandler<RefreshTokenCommand, RefreshTokenResponse>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public RefreshTokenCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension, IConfiguration configuration)
        {
            _configuration = configuration;
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.refreshTokenRequest.RefreshToken)) throw new BaseException("Refresh-Token không hợp lệ !");

            var resRefreshToken = await _repositoryService.TransactionSmartAwaitAsync(async () =>
            {

                if (string.IsNullOrWhiteSpace(request.refreshTokenRequest.RefreshToken))
                    throw new BaseException("Refresh token không hợp lệ !");

                var tokenEntity = await _repositoryService.FirstOrDefaultAsync<RefreshToken>(
                    rf => rf.Token == request.refreshTokenRequest.RefreshToken && (rf.Revoked == "N" || rf.Revoked == null)); // SO SÁNH == N ĐỂ LẤY ĐÚNG TOKEN CHƯA BỊ THU HỒI
                    

                if (tokenEntity == null || tokenEntity.ExpiryDate < Extension.Now())
                    throw new BaseException("Refresh token hết hạn hoặc không tồn tại !");

                //lấy user
                var user = await _repositoryService.FirstOrDefaultAsync<User24h>(u => u.Id == tokenEntity.UserId, cancellationToken);

                if (user == null)
                    throw new BaseException("Người dùng không tồn tại !");

                //Refresh Token Rotation: Là một cơ chế bảo mật quan trọng được sử dụng cùng với Refresh Token để giảm thiểu rui ro trong trg hợp token bị đánh cắp
                // Người dùng đăng nhập - Yêu cầu Access Token mới - Máy chủ cấp Access Token và Refresh Token mới - Refresh Token cũ bị vô hiệu hóa - Ứng dụng cập nhật Refresh Token mới

                tokenEntity.Revoked = "Y"; // Thu hồi refresh cũ


                Console.WriteLine("user day =>>>>>>>>>>" , user.Fullname);
                //tạo refresh mới
                string newRefreshToken = await _authorizeExtension.GenerateRefreshToken(user.Id.ToString());


                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username ?? ""),
                new Claim("Role", user.Role ?? ""),
                new Claim("Empid", user.Empid?.ToString() ?? "0")
            };

                string accessToken = _authorizeExtension.GenerateJWT(claims, 120); // 2 giờ

                var newTokenEntity = new RefreshToken
                {
                    UserId = user.Id,
                    Token = newRefreshToken,
                    ExpiryDate = Extension.Now().AddDays(_configuration.GetValue<int>("Jwt:ExpiresInDays")),
                    CreatedDate = Extension.Now(),
                    Revoked = "N" //Token chưa bị thu hồi (vẫn còn hiệu lực) ✅
                };
                await _repositoryService.AddAsync(newTokenEntity, cancellationToken);

                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
   
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi tạo Token !");

                return new RefreshTokenResponse
                {
                    AccessToken = accessToken,
                    fullName = user.Fullname,
                    RefreshToken = newRefreshToken,
                };
            }, cancellationToken);
            return  resRefreshToken;
        }
    }
}
