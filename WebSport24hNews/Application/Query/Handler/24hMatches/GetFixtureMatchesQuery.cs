using AutoMapper;
using Dapper.Oracle;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using WebSport24hNews.Application.Query.Model._24hMatches;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;

namespace WebSport24hNews.Application.Query.Handler._24hMatches
{
    public class GetFixtureMatchesQuery : IQueryBase<IEnumerable<LeagueFixturesQuery>>
    {
    }
    public class GetFixtureMatchesQueryHandler : IRequestBaseHandler<GetFixtureMatchesQuery, IEnumerable<LeagueFixturesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetFixtureMatchesQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }


        //Sử dụng dapper để gọi procedure c# đã xử lý nghiệp vụ |
        //lấy danh sách các trận đấu sắp diễn ra, cùng với thông tin chi tiết về giải đấu và các đội bóng tỪ SYS_REFCURSOR
        public async Task<IEnumerable<LeagueFixturesQuery>> Handle(GetFixtureMatchesQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            // Kiểm tra loại cơ sở dữ liệu để tạo tham số phù hợp
            object parameters;
            //gọi một Stored Procedure (SP) Oracle có tên GET_ALL_FIXTURES_PROC. SP này được thiết kế để lấy thông tin chi tiết về các trận đấu.
            if (_repositoryService.GetDbConnection() is OracleConnection) // Kiểm tra nếu là Oracle
            {
                var oracleParams = new OracleDynamicParameters();
                oracleParams.Add(
                    "p_fixtures_cursor",       // Tên tham số REF CURSOR trong SP
                    dbType: Dapper.Oracle.OracleMappingType.RefCursor,
                    direction: ParameterDirection.Output
                );
                parameters = oracleParams;
            }
            else
            {
                // Nếu không phải Oracle, bạn có thể cần xử lý khác hoặc báo lỗi
                // Hoặc nếu SP của bạn được thiết kế cho các DB khác
                // Ví dụ: cho SQL Server, bạn có thể không cần tham số OUT REF CURSOR mà chỉ cần EXEC stored_procedure
                // Hoặc trả về IEnumerable<dynamic>
                throw new NotSupportedException("This operation is only supported for Oracle database with REF CURSOR.");
                // Hoặc: parameters = new Dapper.DynamicParameters(); // Nếu SP không dùng OUT REF CURSOR
            }


            var rawFixtures = await _repositoryService.QueryAsync<FixtureMatchQueryRaw>( // Sử dụng _sqlConnection trực tiếp để gọi QueryAsync
                "GET_ALL_FIXTURES_PROC", // Tên của Stored Procedure độc lập
                parms: parameters,       // Tham số đã tạo (OracleDynamicParameters)
                commandType: CommandType.StoredProcedure,
                commandTimeout: 30 // thiếu lập thời gian chờ dùng thì tạo và triển khai trong inteface
            );

            // sử dụng LINQ để nhóm các trận đấu theo LeagueName (tên giải đấu).
            var groupedFixtures = rawFixtures
                .GroupBy(f => f.LeagueName)
                .Select(g => new LeagueFixturesQuery // Sử dụng LeagueFixturesQuery
                {
                    LeagueName = g.Key,
                    Matches = g.Select(f => new FixtureMatchQuery
                    {
                        Id = f.MatchId,
                        HomeTeamName = f.HomeTeamName,
                        AwayTeamName = f.AwayTeamName,
                        MatchDateTime = f.MatchDateTime, // SP đã format thành string
                        Status = f.Status
                    })
                    .OrderBy(m => m.MatchDateTime) // Sắp xếp lại theo thời gian trận đấu
                    .ToList()
                })
                .ToList();

            return groupedFixtures;
        }


        // ... (Các phương thức Dispose, GetDbConnection, CommitTransaction, RollbackTransaction, BeginTransactionAsync, v.v. giữ nguyên) ...
    }
}

