using AutoMapper;
using Dapper;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.Application.Query.Model._24hArticlesComment;
using WebSport24hNews.Application.Query.Model._24hComment;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;

namespace WebSport24hNews.Application.Query.Handler._24hArticles
{
    public class GetList24hEightArticlesQuery : IQueryBase<IEnumerable<ArticlesCommentQuery>>
    {
    }
    public class GetList24hEightArticlesQueryHandler : IRequestBaseHandler<GetList24hEightArticlesQuery,IEnumerable<ArticlesCommentQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hEightArticlesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }


        //lấy 8 bài viết mới nhất - Chưa code 1 - n
        public async Task<IEnumerable<ArticlesCommentQuery>> Handle(GetList24hEightArticlesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
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
                WHERE PUBLISHED_AT <= SYSDATE
                ORDER BY PUBLISHED_AT DESC, ID DESC
                FETCH FIRST 8 ROWS ONLY";

            using var connection = _repositoryService.GetDbConnection();

            var articles = (await connection.QueryAsync<ArticlesCommentQuery>(sql)).ToList();

            if (!articles.Any())
                throw new BaseException("Không tìm thấy bài viết nào!");

            // Gán danh sách comment rỗng để tránh lỗi binding JSON
            foreach (var article in articles)
            {
                article.commentQuery = new List<CommentQuery>();
            }

            return articles;
        }
    }
}
