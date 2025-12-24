using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hRelatedArticles;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hRelatedArticles
{
    public class GetList24hRelatedArticlesQuery : IQueryBase<IEnumerable<RelatedArticlesQuery>>
    {
        public decimal Id { get; set; }
    }
    public class GetList24hRelatedArticlesQueryHandler : IRequestBaseHandler<GetList24hRelatedArticlesQuery, IEnumerable<RelatedArticlesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hRelatedArticlesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<RelatedArticlesQuery>> Handle(GetList24hRelatedArticlesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var relatedArticles = await _repositoryService.Where<RelatedArticle>(ra => ra.PrimaryArticleId == request.Id).Include(ra => ra.RelatedArticleNavigation).ToListAsync();

            var result = relatedArticles
                .Where(ra => ra.RelatedArticleNavigation != null)
                .Select(ra => new RelatedArticlesQuery
                {
                    Id = ra.RelatedArticleNavigation.Id,
                    Title = ra.RelatedArticleNavigation.Title,
                    Summary = ra.RelatedArticleNavigation.Summary,
                    PublishedAt = ra.RelatedArticleNavigation.PublishedAt,
                    Slug = ra.RelatedArticleNavigation.Slug,
                    FeaturedImage = ra.RelatedArticleNavigation.FeaturedImage,
                    CategoryId = ra.RelatedArticleNavigation.CategoryId,
                });

                        return result;
            // Nếu RelatedArticle không có hoặc không được load, dữ liệu sẽ null return _mapper.Map<IEnumerable<RelatedArticlesQuery>>(relatedArticles);

        }


    }
}
