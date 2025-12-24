using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hProductImage;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hProductImage
{
    public class GetList24hProductImageQuery : DhnProductImageSearchModelQuery, IQueryBase<IPagedList<DhnProductImageQuery>>
    {
    }
    public class GetList24hProductImageQueryHandler : IRequestBaseHandler<GetList24hProductImageQuery, IPagedList<DhnProductImageQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hProductImageQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IPagedList<DhnProductImageQuery>> Handle(GetList24hProductImageQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query = _repositoryService.Table<DhnProductImage>();

            if (!string.IsNullOrEmpty(request.KeySearch))
            {
                var keyWork = request.KeySearch.ToLower();
                query = query.Where(p => p.ImageUrl.ToLower().Contains(keyWork) ||
                                    p.IsThumbnail.ToLower().Contains(keyWork) ||
                                    p.AltText.ToLower().Contains(keyWork) ||
                                    p.Attribute1.ToLower().Contains(keyWork) ||
                                    p.Attribute2.ToLower().Contains(keyWork));
            }

            if (request.StartDate.HasValue)
            {
                query = query.Where(p => p.CreateDate >= request.StartDate.Value);
            }

            if(request.EndDate.HasValue)
            {
                query = query.Where(p => p.CreateDate <= request.EndDate.Value);
            }

            if (!string.IsNullOrEmpty(request.Sort))
            {
                var typeField = request.Sort.GetPropertyGetter<DhnProductImage>();
                query = request.IsOrder == true ? query.OrderBy(typeField) : query.OrderByDescending(typeField);
            }

            var page = await query.PagedList(request.Take, request.Skip);

            PagedList<DhnProductImageQuery> res = new PagedList<DhnProductImageQuery>();
            res.Lists = _mapper.Map<IList<DhnProductImageQuery>>(page.Lists);
            res.Count = page.Count;

            return res;
        }
    }
}
