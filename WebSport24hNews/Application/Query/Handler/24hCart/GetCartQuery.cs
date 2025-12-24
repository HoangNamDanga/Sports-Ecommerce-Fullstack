using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hCart
{
    public class GetCartQuery : IQueryBase<CartDto?>
    {
        public decimal? UserId { get; set; }
        public string? SessionId { get; set; }
    }
    public class GetCartQueryHandler : IRequestBaseHandler<GetCartQuery, CartDto?>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetCartQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;

        }

        public async Task<CartDto?> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var cart = await _repositoryService.Table<DhnCart>()
                .Include(c => c.DhnCartItems)
                    .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.DhnProductImages) // <-- Đảm bảo dòng này có
                .FirstOrDefaultAsync(c =>
                    c.Status == "ACTIVE" && (request.UserId != null ? c.UserId == request.UserId : c.SessionId == request.SessionId), cancellationToken);

            if (cart == null)
                return null;

            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                SessionId = cart.SessionId,
                TotalAmount = cart.TotalAmount,
                TotalItems = cart.DhnCartItems.Count,
                Items = cart.DhnCartItems.Select(item => new CartItemDto
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    ProductName = item.Product?.ProductName,
                    Quantity = item.Quantity ?? 0,
                    UnitPrice = item.UnitPrice,
                    // Lấy ThumbnailUrl: ưu tiên IsThumbnail == "Y", nếu không có thì lấy ảnh đầu tiên theo DisplayOrder, hoặc ảnh bất kỳ
                    ThumbnailUrl = item.Product?.DhnProductImages
                            .FirstOrDefault(img => img.IsThumbnail == "Y")?.ImageUrl
                       ?? item.Product?.DhnProductImages
                            .OrderBy(img => img.DisplayOrder)
                            .FirstOrDefault()?.ImageUrl,
                    TotalPrice = item.TotalPrice,
                    ProductSize = item.Attribute1,
                    MaterialType = item.Attribute2
                }).ToList()
            };
        }
    }
}
