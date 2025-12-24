using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hPlayers;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;

namespace WebSport24hNews.Application.Query.Handler._24hPlayers
{
    public class GetTopPlayerGoald24hNewsQuery : IQueryBase<IEnumerable<TopGoalPlayerQuery>>
    {
        public decimal? leagueId { get; set; }
    }
    public class GetTopPlayerGoald24hNewsQueryHandler : IRequestBaseHandler<GetTopPlayerGoald24hNewsQuery, IEnumerable<TopGoalPlayerQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetTopPlayerGoald24hNewsQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<TopGoalPlayerQuery>> Handle(GetTopPlayerGoald24hNewsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            string sql = @"
                    SELECT
                        p.id AS PlayerId,
                        p.first_name || ' ' || p.last_name || ' (' || t.team_code || ')' AS PlayerName,
                        SUM(pms.goals) AS Goals,
                        SUM(pms.assists) AS Assists
                    FROM
                        player_match_stats pms
                    JOIN
                        players p ON p.id = pms.player_id
                    JOIN
                        matches m ON m.id = pms.match_id
                    JOIN
                        teams t ON t.id = p.team_id
                    WHERE
                        m.league_id = :LeagueId
                    GROUP BY
                        p.id, p.first_name, p.last_name, t.team_code
                    HAVING
                        SUM(pms.goals) > 0 OR SUM(pms.assists) > 0
                    ORDER BY
                        SUM(pms.goals) DESC,
                        SUM(pms.assists) DESC";

            var parameters = new { LeagueId = request.leagueId };

            var result = await _repositoryService.QueryAsync<TopGoalPlayerQuery>(sql, parameters);

            return result;
        }
    }
}
