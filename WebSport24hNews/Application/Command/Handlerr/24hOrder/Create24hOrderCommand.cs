using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hOrder;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hOrder
{
    public class Create24hOrderCommand : ICommandBase<bool>
    {
        public CreateOrderDto dto { get; set; }
    }
    public class Create24hOrderCommandHandler : IRequestBaseHandler<Create24hOrderCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hOrderCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hOrderCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;

            var orderTransaction = await _repositoryService.TransactionSmartAwaitAsync(async () =>
            {
                var order = _mapper.Map<DhnOrder>(request.dto);
                order.CreateBy = userId;
                order.CreateDate = Extension.Now();


                await _repositoryService.AddAsync(order, cancellationToken);
                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;

                if (!saveResult)
                    throw new BaseException("Tạo đơn hàng lỗi , vui lòng tạo lại !");

                foreach (var item in request.dto.Items)
                {
                    var orderItem = new DhnOrderItem
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        VariantId = item.VariantId,
                        Quantity = item.Quantity,
                        PricePerItem = item.PricePerItem,
                        CreateBy = userId,
                        CreateDate = DateTime.Now,
                        LastUpdateDate = DateTime.Now
                    };

                    await _repositoryService.AddAsync(orderItem, cancellationToken);
                }

                saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult) throw new BaseException("Tạo lỗi !");

                return saveResult;
            }, cancellationToken);
            return orderTransaction;
        }
    }
}
