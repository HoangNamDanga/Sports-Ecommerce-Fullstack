using AutoMapper;
using Dapper;
using StackExchange.Redis;
using WebSport24hNews.Application.Query.Model._24hMatches;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;

namespace WebSport24hNews.Application.Query.Handler._24hCategories
{
    public class GetFixtures24hQueryCategory : IQueryBase<IEnumerable<FixturesDTOCategory>>
    {
        public decimal? leagueId { get; set; }
    }
    public class GetFixtures24hQueryCategoryHandler : IRequestBaseHandler<GetFixtures24hQueryCategory, IEnumerable<FixturesDTOCategory>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetFixtures24hQueryCategoryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<FixturesDTOCategory>> Handle(GetFixtures24hQueryCategory request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var sql = @"
                SELECT
                    M.ID AS Id,
                    L.LEAGUE_NAME AS LeagueName,
                    HU.TEAM_NAME AS HomeTeamName,
                    AT.TEAM_NAME AS AwayTeamName,
                    M.MATCH_DATE AS MatchDateTime,
                    M.STATUS AS Status,
                    M.FULL_TIME_SCORE_HOME AS HomeScore,
                    M.FULL_TIME_SCORE_AWAY AS AwayScore
                FROM MATCHES M
                JOIN LEAGUES L ON M.LEAGUE_ID = L.ID
                JOIN TEAMS HU ON M.HOME_TEAM_ID = HU.ID
                JOIN TEAMS AT ON M.AWAY_TEAM_ID = AT.ID
                WHERE M.STATUS IN ('FT', 'SCHEDULED')"; // Luôn lọc trạng thái


            var parameters = new DynamicParameters();

            if (request.leagueId.HasValue)
            {
                sql += " AND L.ID = :CategoryId";
                parameters.Add("CategoryId", request.leagueId.Value);
            }

            sql += " ORDER BY L.LEAGUE_NAME, M.MATCH_DATE";

                
            using var connection = _repositoryService.GetDbConnection();
            var fixtures = await connection.QueryAsync<FixturesDTOCategory>(sql, parameters);
            return fixtures;
        }
    }
}
