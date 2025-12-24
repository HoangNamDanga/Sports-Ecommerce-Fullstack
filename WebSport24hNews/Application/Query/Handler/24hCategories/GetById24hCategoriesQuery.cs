using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.Application.Query.Model._24hCategories;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hCategories
{
    public class GetById24hCategoriesQuery : IQueryBase<CategoriesQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetById24hCategoriesQueryHandler : IRequestBaseHandler<GetById24hCategoriesQuery, CategoriesQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetById24hCategoriesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<CategoriesQuery> Handle(GetById24hCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisCategories = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Category>(a => a.Id == request.Id);
            if (exisCategories == null)
                throw new BaseException("Không tim thấy bài viết !");

            return _mapper.Map<CategoriesQuery>(exisCategories);
        }
    }
}
