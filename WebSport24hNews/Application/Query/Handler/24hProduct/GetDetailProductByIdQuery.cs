using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hProductVariant;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hProduct
{
    public class GetDetailProductByIdQuery : IQueryBase<DhnProductDto>
    {
        public decimal? ProductId { get; set; }
    }
    public class GetDetailProductByIdQueryHandler : IRequestBaseHandler<GetDetailProductByIdQuery, DhnProductDto>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetDetailProductByIdQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;

        }

        public async Task<DhnProductDto> Handle(GetDetailProductByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request), "Yêu cầu không hợp lệ !");


            // 1. Truy vấn sản phẩm chính, eagerly load các biến thể và ảnh
            var product = await _repositoryService.Table<DhnProduct>().Include(p => p.DhnProductVariants).Include(p => p.DhnProductImages)
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync(p => p.Id == request.ProductId);

            //2. xử lý trường hợp không tìm thấy sản phẩm
            if (product == null)
                throw new BaseException($"Không tìm thấy sản phẩm với ID : {request.ProductId}");
            

            //tìm ảnh có thumbnail là 'Y' . Nếu không có , thumbnail sẽ là null
            var thumbnailUrl = product.DhnProductImages?.FirstOrDefault(pi => pi.IsThumbnail == "Y")?.ImageUrl;

            //4. Ánh xạ dữ liệu từ entity sang DTO
            var productDto = new DhnProductDto
            {
                ProductID = product.Id,
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                Brand = product.Brand,
                CurrentPrice = product.CurrentPrice,
                ThumbnailUrl = thumbnailUrl,
                Description = product.Description,

                Variants = product.DhnProductVariants.Select(v => new DhnProductVariantDetailDto
                {
                    // Sử dụng CurrentPrice của sản phẩm cha cho giá cơ sở của biến thể
                    VariantPrice = (product.CurrentPrice ?? 0M) + (v.AdditionalPrice ?? 0M),
                    MaterialType = v.Attribute1, // Giả định Attribute1 là MaterialType
                    ProductSize = v.ProductSize,
                    Color = v.Color,

                }).OrderBy(v => v.VariantPrice).ToList(),
            };

            return productDto;
        }
    }
}
