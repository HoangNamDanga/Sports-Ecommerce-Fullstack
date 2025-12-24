using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hVideos;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hVideos
{
    public class Update24hVideosCommand : ICommandBase<bool>
    {
        public UpdateVideoRequest videosCommand { get; set; }
    }
    public class Update24hVideosCommandHandler : IRequestBaseHandler<Update24hVideosCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Update24hVideosCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Update24hVideosCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;


                if (request.videosCommand == null)
                    throw new BaseException("Dữ liệu videosCommand không hợp lệ!");
                var exisVideosDb = await _repositoryService.FirstOrDefaultAsync<Video>(l => l.Id == request.videosCommand.Id);

                if (exisVideosDb == null)
                    throw new BaseException("Không tìm thấy Videos !");

                var videosDb = _mapper.Map(request.videosCommand, exisVideosDb);
                videosDb.LastUpdateDate = Extension.Now();
                videosDb.LastUpdateBy = userId;


                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi cập nhật Videos !");

                return saveResult;

        }
    }
}
