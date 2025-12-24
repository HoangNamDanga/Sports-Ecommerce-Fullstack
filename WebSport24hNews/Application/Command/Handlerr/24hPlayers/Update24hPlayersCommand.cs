using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hPlayers;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hPlayers
{
    public class Update24hPlayersCommand : ICommandBase<bool>
    {
        public PlayersCommand playersCommand { get; set;}
    }
    public class Update24hPlayersCommandHandler : IRequestBaseHandler<Update24hPlayersCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Update24hPlayersCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Update24hPlayersCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;

                var exisPlayersDb = await _repositoryService.FirstOrDefaultAsync<Player>(l => l.Id == request.playersCommand.Id);

                if (exisPlayersDb == null)
                    throw new BaseException("Không tìm thấy cầu thủ !");

                var playersDb = _mapper.Map(request.playersCommand, exisPlayersDb);
                playersDb.LastUpdateDate = Extension.Now();
                playersDb.LastUpdateBy = userId;


                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi cập nhật cầu thủ !");

                return saveResult;

        }
    }
}
