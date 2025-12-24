using AutoMapper;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using WebSport24hNews.Application.Query.Model.PremierLeagueStanding;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler.PremierLeagueStanding
{
    public class GetPremierLeagueStandingQuery : IQueryBase<IEnumerable<PremierLeaguesModel>>
    {
        public decimal LeagueId { get; set; } //fix cung' giai Leagua_Id = 23 lay ra ngoai hang anh
    }
    public class GetPremierLeagueStandingQueryHandler : IRequestBaseHandler<GetPremierLeagueStandingQuery, IEnumerable<PremierLeaguesModel>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetPremierLeagueStandingQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<PremierLeaguesModel>> Handle(GetPremierLeagueStandingQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new BaseException("Yêu cầu không hợp lệ !");

            string sql = @"SELECT 
                        TEAM_ID AS TeamId,
                        TEAM_NAME AS TeamName,
                        RANK_POSITION AS RankPosition,
                        MATCHES_PLAYED AS MatchesPlayed,
                        WINS AS Wins,
                        DRAWS AS Draws,
                        LOSSES AS Losses,
                        GOALS_FOR AS GoalsFor,
                        GOALS_AGAINST AS GoalsAgainst,
                        GOAL_DIFFERENCE AS GoalDifference,
                        POINTS AS Points
                        FROM 
                            PREMIER_LEAGUE_STANDINGS 
                        WHERE 
                            LEAGUE_ID = :LeagueId
                            ORDER BY RANK_POSITION"
                                ;

            var standings = await _repositoryService.QueryAsync<PremierLeaguesModel>(sql, new { request.LeagueId});


            if (standings == null || !standings.Any())
                throw new BaseException("Không tìm thấy dữ liệu bảng xếp hạng!");

            return standings.ToList();
        }
    }
}
