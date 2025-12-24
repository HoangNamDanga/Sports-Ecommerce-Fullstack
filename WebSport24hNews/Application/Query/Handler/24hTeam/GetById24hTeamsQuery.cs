using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hTeam;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hTeam
{
    public class GetById24hTeamsQuery : IQueryBase<TeamsQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetById24hTeamsCommandHandler : IRequestBaseHandler<GetById24hTeamsQuery, TeamsQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetById24hTeamsCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<TeamsQuery> Handle(GetById24hTeamsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisTeamsDb = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Team>(l => l.Id == request.Id);

            if (exisTeamsDb == null)
                throw new BaseException("Không tìm thấy đội bóng !");

            return _mapper.Map<TeamsQuery>(exisTeamsDb);
        }
    }
}
