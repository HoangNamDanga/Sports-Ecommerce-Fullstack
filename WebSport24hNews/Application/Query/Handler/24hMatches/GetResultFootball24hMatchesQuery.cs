using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.Application.Query.Model._24hMatches;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hMatches
{
    public class GetResultFootball24hMatchesQuery : IQueryBase<IEnumerable<MatchesResultQuery>>
    {
    }
    public class GetResultFootball24hMatchesQueryHandler : IRequestBaseHandler<GetResultFootball24hMatchesQuery, IEnumerable<MatchesResultQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetResultFootball24hMatchesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }


        //API trả ra kết quả trận đấu Page Home sắp xếp theo Desc join qua từng bảng sử dụng LINQ Query Syntax
        public async Task<IEnumerable<MatchesResultQuery>> Handle(GetResultFootball24hMatchesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");
            var matchesDb = _repositoryService.Table<WebSport24hNews.Models.Match>();
            var teamDb = _repositoryService.Table<WebSport24hNews.Models.Team>();
            var leagueDb = _repositoryService.Table<WebSport24hNews.Models.League>();

            var query = from m in matchesDb
                        join l in leagueDb on m.LeagueId equals l.Id // JOIN với Leagues
                        join ht in teamDb on m.HomeTeamId equals ht.Id // JOIN với Home Team
                        join at in teamDb on m.AwayTeamId equals at.Id // JOIN với Away Team
                        where m.Status == "FT" // Lọc các trận đấu đã kết thúc
                        orderby m.MatchDate descending, m.Id descending // Sắp xếp
                        select new MatchesResultQuery // Chọn các cột và ánh xạ sang DTO
                        {
                            Id = m.Id,
                            LeagueName = l.LeagueName, // Lấy từ bảng Leagues đã JOIN
                            HomeTeam = ht.TeamName,    // Lấy từ bảng Home Team đã JOIN
                            AwayTeam = at.TeamName,    // Lấy từ bảng Away Team đã JOIN
                            MatchDate = m.MatchDate,
                            HomeScore = m.FullTimeScoreHome,
                            AwayScore = m.FullTimeScoreAway,
                            Status = m.Status
                        };

            return query;
        }
    }
}
