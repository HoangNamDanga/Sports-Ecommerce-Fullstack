using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Command.Handlerr._24hImage;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hProductImage
{
    //Hàm chỉnh sửa hình ảnh theo dạng upload file
    public class Update24hProductImageCommand : ICommandBase<bool>
    {
        public UploadProductImageDTO dto { get; set; }
    }
    public class Update24hProductImageCommandHandler : IRequestBaseHandler<Update24hProductImageCommand, bool>
    {
        private readonly IWebHostEnvironment _env;
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Update24hProductImageCommandHandler(IWebHostEnvironment env,IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public async Task<bool> Handle(Update24hProductImageCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            // Lấy entity hiện có theo Id (bạn cần có Id trong dto)
            var imageEntity = await _repositoryService.Table<DhnProductImage>().FirstOrDefaultAsync(i => i.Id == request.dto.Id);

            if (imageEntity == null)
                throw new BaseException("Ảnh sản phẩm không tồn tại !");

            //Cập nhật các trường thông tin trừ file ảnh
            imageEntity.IsThumbnail = request.dto.IsThumbnail ? "Y" : "N";
            imageEntity.DisplayOrder = request.dto.DisplayOrder ?? 0;
            imageEntity.AltText = request.dto.AltText ?? "";
            imageEntity.LastUpdateBy = _authorizeExtension.GetUser().Id;
            imageEntity.LastUpdateDate = DateTime.Now;

            //Nếu có file ảnh mới thì xử lý upload
            if(request.dto.Image != null && request.dto.Image.Length > 0)
            {
                //xóa file cũ (nếu muốn)
                var oldFilePath = Path.Combine(_env.WebRootPath, imageEntity.ImageUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString()));
                if (File.Exists(oldFilePath))
                {
                    File.Delete(oldFilePath);
                }

                //Tạo đường dẫn thứ mục
                var folderName = Path.Combine("uploads", "products", request.dto.ProductId.ToString());
                var uploadPath = Path.Combine(_env.WebRootPath, folderName);
                Directory.CreateDirectory(uploadPath);

                //Tạo tên file mới
                var fileExt = Path.GetExtension(request.dto.Image.FileName);
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                if (!allowedExtensions.Contains(fileExt.ToLower()))
                    throw new BaseException("Định dạng file không hợp lệ !");

                var unitqueFileName = $"product_{Guid.NewGuid()}{fileExt}";
                var filePath = Path.Combine(uploadPath, unitqueFileName);

                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.dto.Image.CopyToAsync(stream, cancellationToken);
                }

                //Cập nhật đường dẫn ảnh mới
                imageEntity.ImageUrl = $"/{folderName.Replace("\\", "/")}/{unitqueFileName}";
            }
            _repositoryService.Update(imageEntity);
            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi cập nhật ảnh sản phẩm !");

            return saveResult;
        }
    }
}
