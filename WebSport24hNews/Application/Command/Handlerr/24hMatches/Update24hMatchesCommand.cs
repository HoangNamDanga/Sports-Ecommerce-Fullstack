using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hMatches;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hMatches
{
    public class Update24hMatchesCommand : ICommandBase<bool>
    {
        public MatchesCommand matchesCommand { get; set; }
    }
    public class Update24hMatchesCommandHandler : IRequestBaseHandler<Update24hMatchesCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Update24hMatchesCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Update24hMatchesCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;


                var exisMatchesDb = await _repositoryService.FirstOrDefaultAsync<Match>(l => l.Id == request.matchesCommand.Id);

                if (exisMatchesDb == null)
                    throw new BaseException("Không tìm thấy trận đấu !");

                var matchesDb = _mapper.Map(request.matchesCommand, exisMatchesDb);
                matchesDb.LastUpdateDate = Extension.Now();
                matchesDb.LastUpdateBy = userId;


                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi cập nhật trận đấu !");

                return saveResult;
        }
    }
}
