using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.Application.Query.Model._24hCategories;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hCategories
{
    public class GetFour24hArticlesCategoryQuery : IQueryBase<IEnumerable<ArticlesQuery>>
    {
        public decimal categoryId { get; set; }
    }
    public class GetFour24hArticlesCategoryQueryHandler : IRequestBaseHandler<GetFour24hArticlesCategoryQuery, IEnumerable<ArticlesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetFour24hArticlesCategoryQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<ArticlesQuery>> Handle(GetFour24hArticlesCategoryQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisAricleCategories = await _repositoryService.WhereTracking<Article>(a => a.CategoryId == request.categoryId)
                .OrderByDescending(a => a.PublishedAt)
                .Take(4)
                .ToListAsync();


            if (!exisAricleCategories.Any())
                throw new BaseException("Không tim thấy thể loại bài viết !");

            return  _mapper.Map<List<ArticlesQuery>>(exisAricleCategories);

        }
    }
}
