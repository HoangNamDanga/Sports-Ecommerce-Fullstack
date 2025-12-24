using AutoMapper;
using Dapper;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;

namespace WebSport24hNews.Application.Query.Handler._24hArticles
{
    public class GetList24hThreeTypeCategoriesNameQuery : IQueryBase<IEnumerable<ArticlesThreeCategoriesMasterQuery>>
    {
    }
    public class GetList24hThreeTypeCategoriesNameQueryHandler : IRequestBaseHandler<GetList24hThreeTypeCategoriesNameQuery, IEnumerable<ArticlesThreeCategoriesMasterQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hThreeTypeCategoriesNameQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }


        //ROW_NUMBER() được dùng để phân nhóm theo CATEGORY_NAME
        //Từ khóa PARTITION BY trong SQL (cụ thể là khi dùng với hàm cửa sổ như ROW_NUMBER(), RANK(), SUM(), v.v.) dùng để chia nhóm dữ liệu – tức là phân vùng (partition) – theo giá trị của một hoặc nhiều cột, và áp dụng hàm cửa sổ trong từng nhóm riêng biệt. ở đây đc truyền vào là CATEGORY_NAME, mỗi nhóm đc đánh số thứ tự ROW_NUMBER() 
        public async Task<IEnumerable<ArticlesThreeCategoriesMasterQuery>> Handle(GetList24hThreeTypeCategoriesNameQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ!");
            var sql = @"
                SELECT *
                FROM (
                    SELECT
                        a.ID AS Id,
                        a.TITLE AS Title,
                        a.SUMMARY AS Summary,
                        a.FEATURED_IMAGE AS FeaturedImage,
                        c.CATEGORY_NAME AS CategoryName,
                        ROW_NUMBER() OVER ( 
                            PARTITION BY c.CATEGORY_NAME
                            ORDER BY a.PUBLISHED_AT DESC, a.ID DESC
                        ) AS rn
                    FROM ARTICLES a
                    JOIN CATEGORIES c ON a.CATEGORY_ID = c.ID
                    WHERE 
                        a.PUBLISHED_AT <= SYSDATE
                        AND c.CATEGORY_NAME IN ('Bóng đá quốc tế', 'Chuyển nhượng', 'Bóng đá Việt Nam')
                )
                WHERE rn <= 3";

            using var connection = _repositoryService.GetDbConnection();

            var flatResult = await connection.QueryAsync<ArticlesThreeCategoriesQueryRaw>(sql); // sử dụng bảng tạm hứng Db, giống tính n

            if (flatResult is null || !flatResult.Any())
                throw new BaseException("Không tìm thấy bài viết mới nhất!");

            // Group theo CategoryName
            var grouped = flatResult
                .GroupBy(x => x.CategoryName)
                .Select(g => new ArticlesThreeCategoriesMasterQuery
                {
                    CategoryName = g.Key,
                    articles = g.Select(a => new ArticlesThreeCategoriesQuery
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Summary = a.Summary,
                        FeaturedImage = a.FeaturedImage
                    }).ToList()
                });

            return grouped;
        }
    }
}
