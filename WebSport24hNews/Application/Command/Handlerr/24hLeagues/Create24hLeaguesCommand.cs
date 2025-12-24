using AutoMapper;
using System.Net.WebSockets;
using WebSport24hNews.Application.Command.Modell._24hLeagues;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hLeagues
{
    public class Create24hLeaguesCommand : ICommandBase<bool>
    {
        public LeaguesCommand leaguesCommand { get; set; }
    }
    public class Create24hLeaguesCommandHandler : IRequestBaseHandler<Create24hLeaguesCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hLeaguesCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hLeaguesCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;


                var leaguesDb = _mapper.Map<League>(request.leaguesCommand);
                leaguesDb.CreateBy = userId;
                leaguesDb.CreateDate = Extension.Now();

                await _repositoryService.AddAsync(leaguesDb, cancellationToken);

                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi tạo giải đấu !");

                return saveResult;
        }
    }
}
