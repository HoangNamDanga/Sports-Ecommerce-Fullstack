using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hNewsArticlesSport;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hNewsArticlesSport
{
    public class Update24hNewsArticlesSportCommand : ICommandBase<bool>
    {
        public DhnArticlesSportCommand dhnArticlesSportCommand { get; set; }
    }
    public class Update24hNewsArticlesSportCommandHandler : IRequestBaseHandler<Update24hNewsArticlesSportCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Update24hNewsArticlesSportCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Update24hNewsArticlesSportCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var updateArtcilesSport = await _repositoryService.FirstOrDefaultAsync<DhnNewsArticle>(a => a.Id == request.dhnArticlesSportCommand.Id) ?? throw new BaseException("Không tìm thấy bài viết !");
            _mapper.Map(request.dhnArticlesSportCommand, updateArtcilesSport);
            updateArtcilesSport.LastUpdateBy = _authorizeExtension.GetUser().Id;
            updateArtcilesSport.LastUpdateDate = Extension.Now();

            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi cập nhật bài viết !");

            return saveResult;
        }
    }
}
