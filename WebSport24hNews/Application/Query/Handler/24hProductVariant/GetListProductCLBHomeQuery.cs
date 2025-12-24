using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebSport24hNews.Application.Command.Modell._24hProductVariant;
using WebSport24hNews.Application.Query.Model._24hProductVariant;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hProductVariant
{
    public class GetListProductCLBHomeQuery : IQueryBase<IEnumerable<DhnProductDto>>
    {
    }
    public class GetListProductCLBHomeQueryHandler : IRequestBaseHandler<GetListProductCLBHomeQuery, IEnumerable<DhnProductDto>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetListProductCLBHomeQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;

        }

        public async Task<IEnumerable<DhnProductDto>> Handle(GetListProductCLBHomeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            // Lấy thông tin sản phẩm và ảnh thumbnail chính duy nhất cho mỗi sản phẩm
            var productsWithThumbnails = await (from p in _repositoryService.Table<DhnProduct>()
                                                where p.CategoryId == 2
                                                select new
                                                {
                                                    Product = p,
                                                    ThumbnailImage = _repositoryService.Table<DhnProductImage>()
                                                                                    .FirstOrDefault(pi => pi.ProductId == p.Id && pi.IsThumbnail == "Y")
                                                })
                                               .ToListAsync(cancellationToken);

            // Lấy tất cả các biến thể liên quan
            var productIds = productsWithThumbnails.Select(x => x.Product.Id).ToList();

            var allVariants = await _repositoryService.Table<DhnProductVariant>()
                                                    // Chắc chắn ProductId của DhnProductVariant không null trước khi so sánh
                                                    .Where(pv => pv.ProductId.HasValue && productIds.Contains(pv.ProductId.Value)) // <--- SỬA DÒNG NÀY
                                                    .ToListAsync(cancellationToken);


            // Bước 2: Xử lý nhóm và ánh xạ sang DTO đã nhóm trong bộ nhớ
            var groupedResult = productsWithThumbnails
                .Select(pWithThumb => new DhnProductDto
                {
                    ProductID = pWithThumb.Product.Id,
                    ProductName = pWithThumb.Product.ProductName,
                    Brand = pWithThumb.Product.Brand,
                    ThumbnailUrl = pWithThumb.ThumbnailImage?.ImageUrl,
                    Variants = allVariants
                                        .Where(v => v.ProductId.HasValue && v.ProductId.Value == pWithThumb.Product.Id) // <--- VÀ SỬA DÒNG NÀY
                                        .Select(pv => new DhnProductVariantDetailDto
                                        {
                                            VariantPrice = (pWithThumb.Product.CurrentPrice ?? 0) + (pv.AdditionalPrice ?? 0),
                                            MaterialType = pv.Attribute1,
                                            ProductSize = pv.ProductSize,
                                            Color = pv.Color
                                        })
                                        .OrderBy(v => v.VariantPrice)
                                        .ToList()
                })
                .OrderBy(p => p.ProductName)
                .ToList();

            return groupedResult;
        }
    }
}
