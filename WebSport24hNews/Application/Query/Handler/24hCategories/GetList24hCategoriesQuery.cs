using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.Application.Query.Model._24hCategories;
using WebSport24hNews.Application.Query.Model._24hLeagues;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hCategories
{
    public class GetList24hCategoriesQuery : New24hSearchModel, IQueryBase<IPagedList<CategoriesQuery>>
    {
    }
    public class GetList24hCategoriesQueryHandler : IRequestBaseHandler<GetList24hCategoriesQuery, IPagedList<CategoriesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hCategoriesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IPagedList<CategoriesQuery>> Handle(GetList24hCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query = _repositoryService.Table<Category>();

            if (!string.IsNullOrEmpty(request.KeySearch))
            {
                var keyWork = request.KeySearch.ToLower();
                query = query.Where(a => a.CategoryName.ToLower().Contains(keyWork) ||
                                           a.Slug.ToLower().Contains(keyWork));
            }

            if (!string.IsNullOrEmpty(request.Sort))
            {
                var fieldType = request.Sort.GetPropertyGetter<Category>();
                query = request.IsOrder == true ? query.OrderBy(fieldType) : query.OrderByDescending(fieldType);
            }

            if (request.StartDate.HasValue)
            {
                query = query.Where(a => a.CreateDate >= request.StartDate.Value);
            }

            if (request.EndDate.HasValue)
            {
                query = query.Where(a => a.CreateDate <= request.EndDate.Value);
            }

            var page = await query.PagedList(request.Take, request.Skip);

            PagedList<CategoriesQuery> res = new PagedList<CategoriesQuery>();
            res.Lists = _mapper.Map<IList<CategoriesQuery>>(page.Lists);
            res.Count = page.Count;

            return res;
        }
    }
}
