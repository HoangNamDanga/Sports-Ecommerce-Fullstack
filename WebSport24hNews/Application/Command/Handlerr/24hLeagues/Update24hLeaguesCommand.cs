using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hLeagues;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hLeagues
{
    public class Update24hLeaguesCommand : ICommandBase<bool>
    {
        public LeaguesCommand leaguesCommand { get; set; }
    }
    public class Update24hLeaguesCommandHandler : IRequestBaseHandler<Update24hLeaguesCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Update24hLeaguesCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Update24hLeaguesCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;

                var exisLeaguesDb = await _repositoryService.FirstOrDefaultAsync<League>(l => l.Id == request.leaguesCommand.Id);

                if (exisLeaguesDb == null)
                    throw new BaseException("Không tìm thấy giải đấu !");

                var leaguesDb = _mapper.Map(request.leaguesCommand, exisLeaguesDb);
                leaguesDb.LastUpdateDate = Extension.Now();
                leaguesDb.LastUpdateBy = userId;


                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi cập nhật giải đấu !");

                return saveResult;
        }
    }
}
