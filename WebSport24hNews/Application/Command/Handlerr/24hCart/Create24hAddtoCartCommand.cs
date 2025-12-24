using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Command.Modell._24hCart;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hCart
{
    public class Create24hAddtoCartCommand : ICommandBase<decimal>
    {
        public AddToCartDto addToCard { get; set; }
    }
    public class Create24hAddtoCartCommandHandler : IRequestBaseHandler<Create24hAddtoCartCommand, decimal>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hAddtoCartCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;

        }

        public async Task<decimal> Handle(Create24hAddtoCartCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var cartId = await _repositoryService.TransactionSmartAwaitAsync(async () =>
            {
                var dto = request.addToCard;

                // 1. Tìm giỏ hàng Active kèm items
                var cart = await _repositoryService.Table<DhnCart>()
                    .Include(c => c.DhnCartItems)
                    .FirstOrDefaultAsync(c =>
                        c.Status == "ACTIVE" && (c.UserId == dto.UserId || (dto.UserId == null && c.SessionId == dto.SessionId)), cancellationToken);

                // 2. Tạo mới nếu không tồn tại
                if (cart == null)
                {
                    cart = new DhnCart
                    {
                        UserId = dto.UserId,
                        SessionId = dto.SessionId,
                        TotalAmount = 0,
                        TotalItems = 0,
                        Status = "ACTIVE",
                        CreateBy = _authorizeExtension.GetUser().Id,
                        CreateDate = Extension.Now()
                    };

                    await _repositoryService.AddAsync(cart, cancellationToken);
                    var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                    if (!saveResult)
                        throw new BaseException("Xảy ra lỗi khi tạo giỏ hàng");
                }

                // 3. Tìm item trong cart (dùng collection đã load)
                var existingItem = cart.DhnCartItems.FirstOrDefault(i => i.ProductId == dto.ProductId);

                var unitPrice = dto.VariantPrice ?? 0;
                var quantity = dto.Quantity;

                if (existingItem == null)
                {
                    var newItem = new DhnCartItem
                    {
                        CartId = cart.Id,
                        ProductId = dto.ProductId,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        TotalPrice = quantity * unitPrice,
                        Attribute1 = dto.ProductSize,
                        Attribute2 = dto.MaterialType,
                        CreateBy = _authorizeExtension.GetUser().Id,
                        CreateDate = Extension.Now()
                    };

                    await _repositoryService.AddAsync(newItem, cancellationToken);
                }
                else
                {
                    existingItem.Quantity += quantity;
                    existingItem.TotalPrice = existingItem.Quantity * (existingItem.UnitPrice ?? 0);
                    existingItem.LastUpdateBy = _authorizeExtension.GetUser().Id;
                    existingItem.LastUpdateDate = Extension.Now();

                    _repositoryService.Update(existingItem);
                }

                // 4. Cập nhật tổng giá trị và số lượng
                cart.TotalAmount = cart.DhnCartItems.Sum(i => i.TotalPrice ?? 0);
                cart.TotalItems = cart.DhnCartItems.Count;

                cart.LastUpdateBy = _authorizeExtension.Empid;
                cart.LastUpdateDate = Extension.Now();

                _repositoryService.Update(cart);

                var saveResultEnd = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResultEnd)
                    throw new BaseException("Xảy ra lỗi khi cập nhật giá trị và số lượng sản phẩm trong giỏ hàng !");

                return cart.Id;
            }, cancellationToken);

            return cartId;
        }
    }
}
