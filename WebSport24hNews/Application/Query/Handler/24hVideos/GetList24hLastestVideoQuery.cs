using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hVideos;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hVideos
{
    public class GetList24hLastestVideoQuery : IQueryBase<IEnumerable<VideosQuery>>
    {
    }
    public class GetList24hLastestVideoQueryHandler : IRequestBaseHandler<GetList24hLastestVideoQuery, IEnumerable<VideosQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hLastestVideoQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<VideosQuery>> Handle(GetList24hLastestVideoQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var videos = await _repositoryService
            .Where<Video>(v => true)
            .OrderByDescending(v => v.CreateDate)
            .Select(v => new VideosQuery
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                ThumbnailUrl = v.ThumbnailUrl,
                EmbedUrl = v.EmbedUrl,
                Slug = v.Slug,
                ViewCount = v.ViewCount,
                PublishedAt = v.PublishedAt,
                Duration = v.Duration
            })
            .ToListAsync(cancellationToken);

            return videos;
        }
    }
}
