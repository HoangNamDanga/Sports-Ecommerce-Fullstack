using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hCategoriesProduct;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hCategoriesProduct
{
    public class GetList24hDhnCategoriesProductQuery : DhnCategoriesSearchModel, IQueryBase<IPagedList<DhnCategoriesQuery>>
    {
    }
    public class GetList24hDhnCategoriesProductQueryHandler : IRequestBaseHandler<GetList24hDhnCategoriesProductQuery, IPagedList<DhnCategoriesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hDhnCategoriesProductQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IPagedList<DhnCategoriesQuery>> Handle(GetList24hDhnCategoriesProductQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query = _repositoryService.Table<DhnCategory>();

            if (!string.IsNullOrEmpty(request.KeySearch))
            {
                var keyWork = request.KeySearch.ToLower();
                query = query.Where(c => c.CategoryName.ToLower().Contains(keyWork) ||
                                         c.Description.ToLower().Contains(keyWork));
            }

            if (request.StartDate.HasValue)
            {
                query = query.Where(c => c.CreateDate >= request.StartDate.Value);
            }

            if (request.EndDate.HasValue)
            {
                query = query.Where(c => c.CreateDate <= request.EndDate.Value);
            }

            if (!string.IsNullOrEmpty(request.Sort))
            {
                var typeField = request.Sort.GetPropertyGetter<DhnCategory>();
                query = request.IsOrder == true ? query.OrderBy(typeField) : query.OrderByDescending(typeField);
            }

            var page = await query.PagedList(request.Take, request.Skip);

            PagedList<DhnCategoriesQuery> res = new PagedList<DhnCategoriesQuery>();
            res.Lists = _mapper.Map<IList<DhnCategoriesQuery>>(page.Lists);
            res.Count = page.Count;

            return res;
        }
    }
}
