using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hTeam;
using WebSport24hNews.Application.Query.Model._24hVideos;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hVideos
{
    public class GetById24hVideosQuery : IQueryBase<VideosQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetById24hVideosQueryHandler : IRequestBaseHandler<GetById24hVideosQuery, VideosQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetById24hVideosQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<VideosQuery> Handle(GetById24hVideosQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisVideosDb = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Video>(l => l.Id == request.Id);

            if (exisVideosDb == null)
                throw new BaseException("Không tìm thấy Video !");

            return _mapper.Map<VideosQuery>(exisVideosDb);
        }
    }
}
