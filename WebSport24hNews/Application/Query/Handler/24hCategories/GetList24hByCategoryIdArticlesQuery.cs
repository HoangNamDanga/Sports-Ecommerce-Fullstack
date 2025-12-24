using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.Application.Query.Model._24hCategories;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hCategories
{
    public class GetList24hByCategoryIdArticlesQuery : IQueryBase<IEnumerable<ArticlesQuery>>
    {
        public decimal categoryId { get; set; }
    }
    public class GetList24hByCategoryIdArticlesQueryHandler : IRequestBaseHandler<GetList24hByCategoryIdArticlesQuery, IEnumerable<ArticlesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hByCategoryIdArticlesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<ArticlesQuery>> Handle(GetList24hByCategoryIdArticlesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var articlesList = await _repositoryService.WhereTracking<Article>(a => a.CategoryId == request.categoryId).OrderByDescending(a => a.PublishedAt).ToListAsync();

            return _mapper.Map<IEnumerable<ArticlesQuery>>(articlesList);
        }
    }
}
