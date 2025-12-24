using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hImage
{

    //Xử lý thêm mới
    public class UploadProductImageCommand : ICommandBase<decimal>
    {
        public UploadProductImageDTO dto { get; set; }


    }
    public class UploadProductImageCommandHandler : IRequestBaseHandler<UploadProductImageCommand, decimal>
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<UploadProductImageCommandHandler> _logger;
        private readonly IRepositoryService _repositoryService;
        private readonly IAuthorizeExtensionService _authorizeExtension;
        public  UploadProductImageCommandHandler(IWebHostEnvironment env, ILogger<UploadProductImageCommandHandler> logger, IRepositoryService repositoryService, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _logger = logger;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<decimal> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;
            var dto = request.dto;

            //Tạo đường dẫn thư mục
            var folderName = Path.Combine("uploads", "products", dto.ProductId.ToString());
            var uploadPath = Path.Combine(_env.WebRootPath, folderName);
            Directory.CreateDirectory(uploadPath);

            //Tạo tên file duy nhất
            var fileExt = Path.GetExtension(dto.Image.FileName);

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            if (!allowedExtensions.Contains(fileExt.ToLower()))
                throw new BaseException("Định dạng file không hợp lệ.");


            var uniqueFileName = $"product_{Guid.NewGuid()}{fileExt}";
            var filePath = Path.Combine(uploadPath, uniqueFileName);


            //Ghi file vào hệ thống
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream,cancellationToken);
            }

            //Tạo Url lưu Db
            var imgUrl = $"/{folderName.Replace("\\", "/")}/{uniqueFileName}";

            //TaỌ Entity mới
            var imageEntity = new DhnProductImage
            {
                ProductId = dto.ProductId,
                ImageUrl = imgUrl,
                IsThumbnail = dto.IsThumbnail ? "Y" : "N",
                DisplayOrder = dto.DisplayOrder ?? 0,
                AltText = dto.AltText ?? "",
                CreateBy = userId,
                CreateDate = DateTime.Now,
            };

            await _repositoryService.AddAsync(imageEntity);

            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi tạo ảnh !");

            return imageEntity.Id;
        }
    }
}
