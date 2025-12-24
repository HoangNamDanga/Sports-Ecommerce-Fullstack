using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hLeagues;
using WebSport24hNews.Application.Query.Model._24hPlayers;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hPlayers
{
    public class GetList24hPlayersQuery : New24hSearchModel, IQueryBase<IPagedList<PlayersQuery>>
    {
    }
    public class GetList24hPlayersQueryHandler : IRequestBaseHandler<GetList24hPlayersQuery, IPagedList<PlayersQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hPlayersQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IPagedList<PlayersQuery>> Handle(GetList24hPlayersQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query = _repositoryService.Table<Player>();

            if (!string.IsNullOrEmpty(request.KeySearch))
            {
                var keyWork = request.KeySearch.ToLower();
                query = query.Where(fa => fa.FirstName.ToLower().Contains(keyWork) ||
                                          fa.LastName.ToLower().Contains(keyWork) ||
                                          fa.Nationality.ToLower().Contains(keyWork) ||
                                          fa.PhotoUrl.ToLower().Contains(keyWork));
            }

            if (!string.IsNullOrEmpty(request.Sort))
            {
                var fieldType = request.Sort.GetPropertyGetter<Player>();
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

            PagedList<PlayersQuery> res = new PagedList<PlayersQuery>
            {
                Lists = _mapper.Map<IList<PlayersQuery>>(page.Lists),
                Count = page.Count,
            };

            return res;
        }
    }
}
