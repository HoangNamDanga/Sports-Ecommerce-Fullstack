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
    public class Create24hVideosCommand : ICommandBase<bool>
    {
        public VideosCommand videosCommand { get; set; }
    }
    public class Create24hVideosCommandHandler : IRequestBaseHandler<Create24hVideosCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hVideosCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hVideosCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;


                var videoTitle = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Video>(t => t.Title.Equals(request.videosCommand.Title));
                if (videoTitle != null)
                    throw new BaseException("Đã tồn tại tiêu đề video !");

                var videoDb = _mapper.Map<Video>(request.videosCommand);
                videoDb.CreateBy = userId;
                videoDb.CreateDate = Extension.Now();


                await _repositoryService.AddAsync(videoDb);
                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi tạo video !");

                return saveResult;
        }
    }
}
