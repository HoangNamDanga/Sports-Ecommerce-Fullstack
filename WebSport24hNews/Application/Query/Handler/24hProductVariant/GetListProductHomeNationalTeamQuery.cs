using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hProductVariant;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hProductVariant
{
    public class GetListProductHomeNationalTeamQuery  : IQueryBase<IEnumerable<DhnProductDto>>
    {
    }

    public class GetListProductHomeNationalTeamQueryHandler : IRequestBaseHandler<GetListProductHomeNationalTeamQuery, IEnumerable<DhnProductDto>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetListProductHomeNationalTeamQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;

        }

        public async Task<IEnumerable<DhnProductDto>> Handle(GetListProductHomeNationalTeamQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            // Bước 1: Lấy thông tin sản phẩm và ảnh thumbnail chính duy nhất cho tất cả sản phẩm của Category 1
            // Sắp xếp ở đây để có thứ tự cho việc chọn ra 4 sản phẩm sau này
            var productsWithThumbnails = await (from p in _repositoryService.Table<DhnProduct>().AsNoTracking()
                                                where p.CategoryId == 1
                                                orderby p.ProductName // Tiêu chí sắp xếp để chọn 4 sản phẩm
                                                select new
                                                {
                                                    Product = p,
                                                    ThumbnailImage = _repositoryService.Table<DhnProductImage>()
                                                                                    .FirstOrDefault(pi => pi.ProductId == p.Id && pi.IsThumbnail == "Y")
                                                })
                                               // KHÔNG CÓ .Take(4) Ở ĐÂY NỮA
                                               .ToListAsync(cancellationToken);

            // Lấy tất cả các biến thể liên quan đến các ProductId đã lấy
            var productIds = productsWithThumbnails.Select(x => x.Product.Id).ToList();

            var allVariants = await _repositoryService.Table<DhnProductVariant>()
                                                    .Where(pv => pv.ProductId.HasValue && productIds.Contains(pv.ProductId.Value))
                                                    .ToListAsync(cancellationToken);

            // Bước 2: Xử lý nhóm, lọc sản phẩm không có biến thể, sau đó lấy 4 sản phẩm
            var groupedResult = productsWithThumbnails
                .Select(pWithThumb => new DhnProductDto
                {
                    ProductID = pWithThumb.Product.Id,
                    ProductName = pWithThumb.Product.ProductName,
                    Brand = pWithThumb.Product.Brand,
                    ThumbnailUrl = pWithThumb.ThumbnailImage?.ImageUrl,
                    Variants = allVariants
                                        .Where(v => v.ProductId.HasValue && v.ProductId.Value == pWithThumb.Product.Id)
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
                .Where(pDto => pDto.Variants != null && pDto.Variants.Any()) // <--- LỌC CÁC SP KHÔNG CÓ BIẾN THỂ TRƯỚC
                .OrderBy(p => p.ProductName) // Sắp xếp lại sau khi lọc (nếu cần)
                .Take(4) // <--- CHỈ LẤY 4 SẢN PHẨM SAU KHI ĐÃ LỌC CÓ BIẾN THỂ
                .ToList();

            return groupedResult;
        }
    }
}
