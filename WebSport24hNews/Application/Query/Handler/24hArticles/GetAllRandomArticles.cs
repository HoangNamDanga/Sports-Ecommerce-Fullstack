using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.Application.Query.Model._24hArticlesComment;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;

namespace WebSport24hNews.Application.Query.Handler._24hArticles
{
    public class GetAllRandomArticles : IQueryBase<IEnumerable<ArticlesQuery>>
    {
    }
    public class GetFourArticleByLeagueIdQueryHandler : IRequestBaseHandler<GetAllRandomArticles, IEnumerable<ArticlesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetFourArticleByLeagueIdQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<ArticlesQuery>> Handle(GetAllRandomArticles request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");
            // Lấy toàn bộ bài viết từ bảng articles, theo thứ tự ngẫu nhiên
            string sql = @"
                SELECT 
                    a.id AS Id,
                    a.title AS Title,
                    a.content AS Content,
                    a.summary AS Summary,
                    a.author_id AS AuthorId,
                    a.team_id AS TeamId,
                    a.published_at AS PublishedAt,
                    a.slug AS Slug,
                    a.featured_image AS FeaturedImage,
                    a.view_count AS ViewCount,
                    a.is_featured AS IsFeatured,
                    a.create_by AS CreateBy,
                    a.create_date AS CreateDate,
                    a.last_update_by AS LastUpdateBy,
                    a.last_update_date AS LastUpdateDate,
                    a.category_id AS CategoryId
                FROM articles a
                ORDER BY DBMS_RANDOM.VALUE";

            var result = await _repositoryService.QueryAsync<ArticlesQuery>(sql);
            return result.ToList();
        }
    }
}
