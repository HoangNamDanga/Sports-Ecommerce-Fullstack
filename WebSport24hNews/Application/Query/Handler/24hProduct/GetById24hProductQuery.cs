using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hProduct;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hProduct
{
    public class GetById24hProductQuery : IQueryBase<DhnProductQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetById24hProductQueryHandler : IRequestBaseHandler<GetById24hProductQuery, DhnProductQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetById24hProductQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;

        }

        public async Task<DhnProductQuery> Handle(GetById24hProductQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisProduct = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<DhnProduct>(p => p.Id == request.Id)
                ?? throw new BaseException("Không tìm thấy sản phẩm !");

            return _mapper.Map<DhnProductQuery>(exisProduct);
        }
    }
}
