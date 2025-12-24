using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hProduct;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hProduct
{
    public class GetList24hProductQuery : DhnProductSearchModelQuery, IQueryBase<IPagedList<DhnProductQuery>>
    {
    }
    public class GetList24hProductQueryHandler : IRequestBaseHandler<GetList24hProductQuery, IPagedList<DhnProductQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hProductQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;

        }

        public async Task<IPagedList<DhnProductQuery>> Handle(GetList24hProductQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query = _repositoryService.Table<DhnProduct>();

            if (!string.IsNullOrEmpty(request.KeySearch))
            {
                var keyWork = request.KeySearch.ToLower();
                query = query.Where(p => p.ProductName.ToLower().Contains(keyWork) ||
                                         p.IsBestSeller.ToLower().Contains(keyWork) ||
                                         p.Description.ToLower().Contains(keyWork) ||
                                         p.Brand.ToLower().Contains(keyWork));
            }

            if (request.StartDate.HasValue)
            {
                query = query.Where(p => p.CreateDate >= request.StartDate.Value);
            }
            if (request.EndDate.HasValue)
            {
                query = query.Where(p => p.CreateDate <= request.EndDate.Value);
            }

            if (!string.IsNullOrEmpty(request.Sort))
            {
                var typeField = request.Sort.GetPropertyGetter<DhnProduct>();
                query = request.IsOrder == true ? query.OrderBy(typeField) : query.OrderByDescending(typeField);
            }

            var page = await query.PagedList(request.Take, request.Skip);

            PagedList<DhnProductQuery> res = new PagedList<DhnProductQuery>();
            res.Lists = _mapper.Map<IList<DhnProductQuery>>(page.Lists);
            res.Count = page.Count;

            return res;
        }
    }
}