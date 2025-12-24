using AutoMapper;
using System.Net.WebSockets;
using WebSport24hNews.Application.Query.Model._24hMatches;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hMatches
{
    public class GetMatchDetailByLeagueIdQuery : IQueryBase<MatchDetailQuery>
    {
        public decimal? LeagueId { get; set; }
    }

    public class GetMatchDetailByLeagueIdQueryHandler : IRequestBaseHandler<GetMatchDetailByLeagueIdQuery, MatchDetailQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetMatchDetailByLeagueIdQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<MatchDetailQuery> Handle(GetMatchDetailByLeagueIdQuery request, CancellationToken cancellationToken)
        {
            if (request.LeagueId == null)
                throw new BaseException("LeagueId không được để trống");


            //1. Lấy trận hoàn tất gần nhất của giải
            var match  = _repositoryService.Table<Match>()
                                            .Where(m => m.LeagueId == request.LeagueId && m.Status == "FT")
                                            .OrderByDescending(m => m.MatchDate)
                                            .ThenByDescending(m => m.Id)
                                            .FirstOrDefault();

            if (match == null)
                throw new BaseException("Không tìm thấy trận đấu hoàn tất nào !");

            // 2. Lấy thoogn tin đội chủ và đội khách
            var home = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Team>(x => x.Id == match.HomeTeamId);
            var away = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Team>(x => x.Id == match.AwayTeamId);

            //3. lấy bàn thắng theo đội
            var goals = _repositoryService.Table<MatchEvent>()
                                          .Where(e => e.MatchId == match.Id && e.EventType == "GOAL")
                                          .ToList();

            var playerLookup = _repositoryService.Table<Player>().ToDictionary(p => p.Id, p => $"{p.FirstName} {p.LastName}");


            var teamLookup = _repositoryService.Table<Team>().ToDictionary(t => t.Id, t => t.TeamName);
             
            var homeScorers = goals.Where(e => e.TeamId == match.HomeTeamId && e.PlayerId != null)
                                    .Select(e => new ScorerDetailQuery
                                    {
                                        PlayerName = playerLookup[e.PlayerId.Value], //e.PlayerId.Value chuyển từ decimal? → decimal
                                        TimeScored = FormatMinute(e.Minute),
                                        Note = e.AdditionalInfo
                                    }).ToList();


            var awayScorers = goals.Where(e => e.TeamId == match.AwayTeamId && e.PlayerId != null)
                                    .Select(e => new ScorerDetailQuery
                                    {
                                        PlayerName = playerLookup[e.PlayerId.Value],
                                        TimeScored = FormatMinute(e.Minute),
                                        Note = e.AdditionalInfo
                                    });


            //4. Lấy đội hình thi đấu
            var lineups = _repositoryService.Table<MatchLineup>().Where(l => l.MatchId == match.Id).ToList(); // lineups là danh sách toàn bộ cầu thủ thi đấu.

            var homeRel = lineups.Where(l => l.TeamId == match.HomeTeamId);
            var awayRel = lineups.Where(l => l.TeamId == match.AwayTeamId);

            var homeLineupDto = new LineupDetailQuery
            {
                Starters = homeRel.Where(l => l.IsStarter == "Y")
                      .Select(l => new PlayerDetailQuery { PlayerName = playerLookup[l.PlayerId] })
                      .ToList(),

                Substitutions = homeRel  // ✅ dùng đúng homeRel
                        .Where(l => l.SubstitutionInMinute.HasValue)
                        .Select(l =>
                        {
                            var outLineup = homeRel  // ✅ chỉ lọc trong đội nhà
                                .Where(x => x.SubstitutionOutMinute.HasValue)
                                .OrderByDescending(x => x.SubstitutionOutMinute)
                                .FirstOrDefault(x => x.SubstitutionOutMinute <= l.SubstitutionInMinute);

                            return new SubstitutionDetailQuery
                            {
                                InPlayer = playerLookup.TryGetValue(l.PlayerId, out var inName) ? inName : "Unknown",
                                OutPlayer = (outLineup != null && playerLookup.TryGetValue(outLineup.PlayerId, out var outName)) ? outName : "Unknown",
                                Minute = l.SubstitutionInMinute.Value
                            };
                        }).ToList()
            };

            var awaiLineupDto = new LineupDetailQuery
            {
                Starters = awayRel.Where(l => l.IsStarter == "Y")
                                  .Select(l => new PlayerDetailQuery { PlayerName = playerLookup[l.PlayerId] })
                                  .ToList(),


                Substitutions = awayRel
                    .Where(l => l.SubstitutionInMinute.HasValue)
                    .Select(l =>
                    {
                        var outLineup = awayRel // ✅ chỉ lọc trong đội khách
                            .Where(x => x.SubstitutionOutMinute.HasValue)
                            .OrderByDescending(x => x.SubstitutionOutMinute)
                            .FirstOrDefault(x => x.SubstitutionOutMinute <= l.SubstitutionInMinute);

                        return new SubstitutionDetailQuery
                        {
                            InPlayer = playerLookup.TryGetValue(l.PlayerId, out var inName) ? inName : "Unknown",
                            OutPlayer = (outLineup != null && playerLookup.TryGetValue(outLineup.PlayerId, out var outName)) ? outName : "Unknown",
                            Minute = l.SubstitutionInMinute.Value
                        };
                    }).ToList()
            };


            var league = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<League>(l => l.Id == match.LeagueId);
            //5 Xây matchDetailQuery

            var result = new MatchDetailQuery
            {
                Id = match.Id,
                LeagueName = league?.LeagueName,
                HomeTeam = home.TeamName,
                MatchDate = match.MatchDate,
                AwayTeam = away.TeamName,
                HomeScore = match.FullTimeScoreHome,
                AwayScore = match.FullTimeScoreAway,
                HomeScorers = homeScorers,
                AwayScorers = awayScorers.ToList(),
                AwayLineup = awaiLineupDto,
                HomeLineup = homeLineupDto
            };

            return result;
        }

        private string FormatMinute(decimal? minute)
        {
            if (minute == null) return string.Empty;

            // Nếu phút là số nguyên: 90
            // Nếu có phút bù giờ: 90.2 => hiển thị thành "90+2'"
            var min = Math.Floor(minute.Value);
            var extra = (minute.Value - min) * 10;

            return extra > 0 ? $"{min}+{(int)extra}'" : $"{(int)min}'";
        }
    }
}
