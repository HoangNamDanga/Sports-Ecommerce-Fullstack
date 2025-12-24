using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.Models;

namespace WebSport24hNews.HoangNam.Service.Sercurity
{
    public class AuthorizeExtensionService : IAuthorizeExtensionService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IRepositoryService _repositoryService;
        private readonly HoangNamWebContext _dbContext; // Inject DbContext (đã thêm database first)

        public AuthorizeExtensionService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, HoangNamWebContext dbContext, IRepositoryService repositoryService)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _dbContext = dbContext;
            _repositoryService = repositoryService;
        }

        //Property này trả về một giá trị boolean cho biết người dùng hiện tại đã được xác thực (logged in) hay chưa.
        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public string UserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        public long Empid
        {
            get
            {
                var empidClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("Empid");
                return empidClaim != null && long.TryParse(empidClaim.Value, out var empid) ? empid : 0;
            }
        }

        //Láy token headers
        public string Token => _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();

        public string AcessToken => Token;

        public string RoleHealCheck => _httpContextAccessor.HttpContext?.User?.FindFirst("RoleHealCheck")?.Value;

        public string GenerateJWT(IList<Claim> claims, int time)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(time), // vì có tiem rồi nên ko cần sử dụng hạn bên kia
                SigningCredentials = credentials,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string ClaimType(string type) => type;

        public async Task<string> GenerateRefreshToken(string id)
        {
            return Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
        }

        public async Task<UserMasterBaseModel> GetUser()
        {
            if (IsAuthenticated) // nếu có đăng nhập
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
                {
                    var userEntity = await _dbContext.User24hs
                        .Where(u => u.Id == userId)
                        .Select(u => new UserMasterBaseModel
                        {
                            Id = u.Id,
                            Username = u.Username,
                            Password = u.Password,
                            Inactive = u.Inactive,
                            Role = u.Role,
                            Phone = u.Phone,
                            Fullname = u.Fullname,
                            Modifydate = u.Modifydate,
                            Modifyby = u.Modifyby,
                            Createdate = u.Createdate,
                            Createby = u.Createby,
                            Tokenactive = u.Tokenactive,
                            Dateactive = u.Dateactive,
                            Codeactive = u.Codeactive,
                            Datecodeactive = u.Datecodeactive,
                            Center = u.Center,
                            Addgoogle = u.Addgoogle,
                            Empid = u.Empid.HasValue ? (long)u.Empid.Value : 0,
                            ListApproveLogin = null, // tạm để null
                        })
                        .FirstOrDefaultAsync();

                    if (userEntity != null)
                    {
                        userEntity.ListApproveLogin = await _dbContext.ApproveLoginUser24hs
                            .Where(al => al.UserId == userId)
                            .Select(al => new ApproveLoginUsers24h
                            {
                                Id = al.Id,
                                UserId = al.UserId,
                                Ip = al.Ip,
                                IsLogin = al.Islogin,
                                IsLogout = al.Islogout,
                                // Map các trường khác nếu có
                            })
                            .ToListAsync();
                    }

                    return userEntity;
                }
            }
            return null;
        }
        public async Task<string> CheckRefreshToken(string id, string token)
        {
            // TODO : Kiểm tra refreshToken trong database
            // Nếu hợp lệ, tạo JWT mới và (có thể) vô hiệu hóa refreshToken cũ
            if (true)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()), // Đảm bảo id là string khi tạo claim
                    new Claim(ClaimTypes.Name, UserName),
                    new Claim("Empid", Empid.ToString()),

                    // Thêm các claims khác cần thiết
                };
                return GenerateJWT(claims, _configuration.GetValue<int>("Jwt:ExpireTime"));
            }
            return null;
        }

        public string GetClientIp()
        {
            return _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "Unknown"; // chạy qua thfi xem có giá trị trong RemoteIp ko
        }



        public async Task<bool> CheckAuthKey(string key)
        {
            var validKeys = _configuration.GetSection("AuthKeys").Get<List<string>>();
            return validKeys?.Contains(key) ?? false;
        }

    }
}
