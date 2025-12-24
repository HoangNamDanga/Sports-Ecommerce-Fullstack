using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hProductImage;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hProductImage
{
    public class GetDetail24hProductImageQuery : IQueryBase<DhnProductImageQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetDetail24hProductImageQueryHandler : IRequestBaseHandler<GetDetail24hProductImageQuery, DhnProductImageQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetDetail24hProductImageQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<DhnProductImageQuery> Handle(GetDetail24hProductImageQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisProductImage = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<DhnProductImage>(p => p.Id == request.Id) ?? throw new BaseException("Không tim thấy dữ liệu sản phẩm hình ảnh !");

            return _mapper.Map<DhnProductImageQuery>(exisProductImage);
        }
    }
}
