using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hCategoriesProduct;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hCategoriesProduct
{
    public class GetDetail24hDhnCategoriesProductQuery : IQueryBase<DhnCategoriesQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetDetail24hDhnCategoriesProductQueryHandler : IRequestBaseHandler<GetDetail24hDhnCategoriesProductQuery, DhnCategoriesQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetDetail24hDhnCategoriesProductQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<DhnCategoriesQuery> Handle(GetDetail24hDhnCategoriesProductQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisCategory = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<DhnCategory>(c => c.Id == request.Id) ?? throw new BaseException("Không tìm thấy thể loại danh mục sản phẩm !");

            return _mapper.Map<DhnCategoriesQuery>(exisCategory);
        }
    }
}
