using AutoMapper;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hMatches
{
    public class Delete24hMatchesCommand : ICommandBase<bool>
    {
        public IEnumerable<decimal?> Ids { get; set; }
    }
    public class Delete24hMatchesCommandHandler : IRequestBaseHandler<Delete24hMatchesCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Delete24hMatchesCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Delete24hMatchesCommand request, CancellationToken cancellationToken)
        {
            if (!request.Ids.Any())
                throw new BaseException("Yêu cầu không hợp lệ !");


                var exisMatchesDb = _repositoryService.Where<Match>(l => request.Ids.Contains(l.Id)).ToList();

                if (!exisMatchesDb.Any())
                    throw new BaseException("Không tìm thấy trận đấu !");

                _repositoryService.Delete(exisMatchesDb);

                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi xóa trận đấu !");

                return saveResult;
        }
    }
}
