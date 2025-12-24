using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hArticles
{
    public class GetDetail24hArticlesQuery : IQueryBase<ArticlesQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetDetail24hArticlesQueryHandler : IRequestBaseHandler<GetDetail24hArticlesQuery, ArticlesQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetDetail24hArticlesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<ArticlesQuery> Handle(GetDetail24hArticlesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisArticles = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Article>(a => a.Id == request.Id);
            if (exisArticles == null)
                throw new BaseException("Không tim thấy bài viết !");

            return _mapper.Map<ArticlesQuery>(exisArticles);
        }
    }
}
