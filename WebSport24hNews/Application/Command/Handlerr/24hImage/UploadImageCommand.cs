using System.Net.WebSockets;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;

namespace WebSport24hNews.Application.Command.Handlerr._24hImage
{
    public class UploadImageCommand : ICommandBase<string> // trả ra string
    {
        public IFormFile File { get; set; }
        public UploadImageCommand(IFormFile file)
        {
            File = file;
        }
    }

    public class UploadImageCommandHandler : IRequestBaseHandler<UploadImageCommand, string>
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<UploadImageCommandHandler> _logger;

        public UploadImageCommandHandler(IWebHostEnvironment env, ILogger<UploadImageCommandHandler> logger)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _logger = logger;
        }

        public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            if (request is null) throw new BaseException("Yêu cầu không hợp lệ !");

            var file = request.File;

            if (file == null || file.Length == 0)
                throw new BaseException("File không hợp lệ !");


            _logger.LogInformation("WebRootPath: {Path}", _env.WebRootPath);
            //Tạo thư mục lưu ảnh theo ngày ((vd: wwwroot/uploads/2025/05))

            var uploadDir = Path.Combine(_env.WebRootPath, "uploads", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"));
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            // Tạo tên file mới tránh trùng (vd: guid.jpg)
            var fileExt = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExt}";

            var filePath = Path.Combine(uploadDir, fileName);

            //Lưu file vào thư mục
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            //Tạo Url ảnh (giả sử host www.yourdomain.com)
            var url = $"http://localhost:5149/uploads/{DateTime.Now:yyyy}/{DateTime.Now:MM}/{fileName}";

            _logger.LogInformation("File uploaded: {Url}", url);

            return url;
        }
    }


}
