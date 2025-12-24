using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hLeagues;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hLeagues
{
    public class GetById24hLeaguesQuery : IQueryBase<LeaguesQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetById24hLeaguesQueryHandler : IRequestBaseHandler<GetById24hLeaguesQuery, LeaguesQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetById24hLeaguesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<LeaguesQuery> Handle(GetById24hLeaguesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisLeaguesDb = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<League>(l => l.Id == request.Id);

            if (exisLeaguesDb == null)
                throw new BaseException("Không tìm thấy giải đấu !");

            return _mapper.Map<LeaguesQuery>(exisLeaguesDb);
        }
    }
}
