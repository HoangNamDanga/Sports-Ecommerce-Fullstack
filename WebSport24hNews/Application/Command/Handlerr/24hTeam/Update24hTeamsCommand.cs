using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hTeam;
using WebSport24hNews.Application.Query.Model._24hTeam;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hTeam
{
    public class Update24hTeamsCommand : ICommandBase<bool>
    {
        public TeamsCommand teamsCommand { get; set; }
    }
    public class Update24hTeamsCommandHandler : IRequestBaseHandler<Update24hTeamsCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Update24hTeamsCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Update24hTeamsCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

           var userId = _authorizeExtension.GetUser().Id;


            var exisTeamsDb = await _repositoryService.FirstOrDefaultAsync<Team>(l => l.Id == request.teamsCommand.Id);

            if (exisTeamsDb == null)
                throw new BaseException("Không tìm thấy đội bóng !");

            var teamsDb = _mapper.Map(request.teamsCommand, exisTeamsDb);
            teamsDb.LastUpdateDate = Extension.Now();
            teamsDb.LastUpdateBy = userId;


            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi cập nhật đội bóng !");

            return saveResult;
        }
    }
}
