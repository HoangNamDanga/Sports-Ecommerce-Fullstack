using AutoMapper;
using Dapper;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.Controllers;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;

namespace WebSport24hNews.Application.Query.Handler._24hArticles
{
    //gọi ở home bên font end
    public class GetList24hSelectTopHomeQuery : IQueryBase<ArticlesQuery>
    {
    }
    public class GetList24hSelectTopHomeQueryHandler : IRequestBaseHandler<GetList24hSelectTopHomeQuery, ArticlesQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hSelectTopHomeQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<ArticlesQuery> Handle(GetList24hSelectTopHomeQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new BaseException("Yêu cầu không hợp lệ!");

            var sql = @"
                SELECT
                    ID AS Id,
                    TITLE AS Title,
                    CONTENT AS Content,
                    SUMMARY AS Summary,
                    AUTHOR_ID AS AuthorId,
                    TEAM_ID AS TeamId,
                    PUBLISHED_AT AS PublishedAt,
                    SLUG AS Slug,
                    FEATURED_IMAGE AS FeaturedImage,
                    VIEW_COUNT AS ViewCount,
                    IS_FEATURED AS IsFeatured,
                    CREATE_BY AS CreateBy,
                    CREATE_DATE AS CreateDate,
                    LAST_UPDATE_BY AS LastUpdateBy,
                    LAST_UPDATE_DATE AS LastUpdateDate,
                    CATEGORY_ID AS CategoryId
                FROM ARTICLES
                WHERE TRUNC(PUBLISHED_AT) <= TRUNC(SYSDATE)
                ORDER BY PUBLISHED_AT DESC, ID DESC
                FETCH FIRST 1 ROWS ONLY";

            using var connection = _repositoryService.GetDbConnection();

            var result = await connection.QueryFirstOrDefaultAsync<ArticlesQuery>(sql); // bí danh phải giống field trong ArticlesQuery

            if (result == null)
                throw new BaseException("Không tìm thấy bài viết mới nhất!");
            Console.WriteLine(result.CreateBy);
            Console.WriteLine(result.CategoryId);
            return result;
        }
    }
}
