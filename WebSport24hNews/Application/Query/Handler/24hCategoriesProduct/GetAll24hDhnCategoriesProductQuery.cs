using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hCategoriesProduct;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hCategoriesProduct
{
    public class GetAll24hDhnCategoriesProductQuery : IQueryBase<IEnumerable<DhnCategoriesQuery>>
    {
    }
    public class GetAll24hDhnCategoriesProductQueryHandler : IRequestBaseHandler<GetAll24hDhnCategoriesProductQuery, IEnumerable<DhnCategoriesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetAll24hDhnCategoriesProductQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<DhnCategoriesQuery>> Handle(GetAll24hDhnCategoriesProductQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ ");

            return await _repositoryService.Table<DhnCategory>().ProjectTo<DhnCategoriesQuery>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
