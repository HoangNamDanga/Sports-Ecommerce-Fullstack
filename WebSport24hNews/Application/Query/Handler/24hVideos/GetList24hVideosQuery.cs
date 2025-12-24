using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hLeagues;
using WebSport24hNews.Application.Query.Model._24hTeam;
using WebSport24hNews.Application.Query.Model._24hVideos;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hVideos
{
    public class GetList24hVideosQuery : New24hSearchModel, IQueryBase<IPagedList<VideosQuery>>
    {
    }
    public class GetList24hVideosQueryHandler : IRequestBaseHandler<GetList24hVideosQuery, IPagedList<VideosQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hVideosQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IPagedList<VideosQuery>> Handle(GetList24hVideosQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query = _repositoryService.Table<Video>();

            if (!string.IsNullOrEmpty(request.KeySearch))
            {
                var keyWork = request.KeySearch.ToLower();
                query = query.Where(fa => fa.Title.ToLower().Contains(keyWork) ||
                                          fa.Description.ToLower().Contains(keyWork) ||
                                          fa.EmbedUrl.ToLower().Contains(keyWork) ||
                                          fa.ThumbnailUrl.ToLower().Contains(keyWork) ||
                                          fa.Duration.ToLower().Contains(keyWork) ||
                                          fa.Slug.ToLower().Contains(keyWork));
            }

            if (!string.IsNullOrEmpty(request.Sort))
            {
                var fieldType = request.Sort.GetPropertyGetter<Video>();
                query = request.IsOrder == true ? query.OrderBy(fieldType) : query.OrderByDescending(fieldType);
            }

            if (request.StartDate.HasValue)
            {
                query = query.Where(fa => fa.CreateDate >= request.StartDate.Value);
            }
            if (request.EndDate.HasValue)
            {
                query = query.Where(fa => fa.CreateDate <= request.EndDate.Value);
            }

            var page = await query.PagedList(request.Take, request.Skip);

            PagedList<VideosQuery> res = new PagedList<VideosQuery>
            {
                Lists = _mapper.Map<IList<VideosQuery>>(page.Lists),
                Count = page.Count,
            };

            return res;
        }
    }
}
