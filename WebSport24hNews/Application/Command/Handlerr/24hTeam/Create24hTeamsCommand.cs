using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hTeam;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hTeam
{
    public class Create24hTeamsCommand : ICommandBase<bool>
    {
        public TeamsCommand teamsCommand { get; set; }
    }
    public class Create24hTeamsCommandHandler : IRequestBaseHandler<Create24hTeamsCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hTeamsCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hTeamsCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;

            var result = await _repositoryService.TransactionSmartAwaitAsync(async () =>
            {
                var existingTeam = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Team>(
                    t => t.TeamName == request.teamsCommand.TeamName, cancellationToken);

                if (existingTeam != null)
                    throw new BaseException("Đã tồn tại tên đội bóng !");

                var teamDb = _mapper.Map<Team>(request.teamsCommand);
                teamDb.CreateBy = userId;
                teamDb.CreateDate = Extension.Now();

                await _repositoryService.AddAsync(teamDb);

                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi tạo đội bóng !");

                return true;
            }, cancellationToken);

            return result;
        }
    }
}
