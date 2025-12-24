using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;

namespace WebSport24hNews.Application.Query.Handler._24hArticles
{
    public class Get24hRandomArticlesQuery : IQueryBase<IEnumerable<ArticlesQuery>>
    {
    }
    public class Get24hRandomArticlesQueryHandler : IRequestBaseHandler<Get24hRandomArticlesQuery, IEnumerable<ArticlesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Get24hRandomArticlesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<ArticlesQuery>> Handle(Get24hRandomArticlesQuery request, CancellationToken cancellationToken)
        {
            //query lấy ra 3 bài viết mỗi bài thuộc 1 thể loại ngẫu nhiên.
            string sql = @"
                    SELECT *
                    FROM (
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
                            a.category_id AS CategoryId,
                            ROW_NUMBER() OVER (PARTITION BY a.category_id ORDER BY DBMS_RANDOM.VALUE) AS rn
                        FROM articles a
                        WHERE a.category_id IN (
                            SELECT id
                            FROM (
                                SELECT id
                                FROM categories c
                                WHERE EXISTS (SELECT 1 FROM articles a2 WHERE a2.category_id = c.id)
                                ORDER BY DBMS_RANDOM.VALUE
                            )
                            WHERE ROWNUM <= 3
                        )
                    )
                    WHERE rn = 1
                    ORDER BY DBMS_RANDOM.VALUE
                    FETCH FIRST 3 ROWS ONLY";

            var result = await _repositoryService.QueryAsync<ArticlesQuery>(sql);
            return result.ToList() ;
        }
    }

}
