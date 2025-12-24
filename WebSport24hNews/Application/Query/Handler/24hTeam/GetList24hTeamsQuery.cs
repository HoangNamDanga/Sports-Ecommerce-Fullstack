using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hLeagues;
using WebSport24hNews.Application.Query.Model._24hTeam;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hTeam
{
    public class GetList24hTeamsQuery : New24hSearchModel, IQueryBase<IPagedList<TeamsQuery>>
    {
    }
    public class GetList24hTeamsCommandHandler : IRequestBaseHandler<GetList24hTeamsQuery, IPagedList<TeamsQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetList24hTeamsCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IPagedList<TeamsQuery>> Handle(GetList24hTeamsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query = _repositoryService.Table<Team>();

            if (!string.IsNullOrEmpty(request.KeySearch))
            {
                var keyWork = request.KeySearch.ToLower();
                query = query.Where(fa => fa.TeamName.ToLower().Contains(keyWork) ||
                                          fa.TeamCode.ToLower().Contains(keyWork) ||
                                          fa.Country.ToLower().Contains(keyWork) ||
                                          fa.LogoUrl.ToLower().Contains(keyWork) ||
                                          fa.Stadium.ToLower().Contains(keyWork));
            }

            if (!string.IsNullOrEmpty(request.Sort))
            {
                var fieldType = request.Sort.GetPropertyGetter<Team>();
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

            PagedList<TeamsQuery> res = new PagedList<TeamsQuery>
            {
                Lists = _mapper.Map<IList<TeamsQuery>>(page.Lists),
                Count = page.Count,
            };

            return res;
        }
    }
}
