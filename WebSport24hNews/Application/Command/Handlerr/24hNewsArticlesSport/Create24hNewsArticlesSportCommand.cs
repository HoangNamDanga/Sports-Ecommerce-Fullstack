using AutoMapper;
using System.Windows.Input;
using WebSport24hNews.Application.Command.Modell._24hNewsArticlesSport;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hNewsArticlesSport
{
    public class Create24hNewsArticlesSportCommand : ICommandBase<bool>
    {
        public DhnArticlesSportCommand dhnArticlesSportCommand { get; set; }
    }
    public class Create24hNewsArticlesSportCommandHandler : IRequestBaseHandler<Create24hNewsArticlesSportCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hNewsArticlesSportCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hNewsArticlesSportCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var articlesDb = _mapper.Map<DhnNewsArticle>(request.dhnArticlesSportCommand);
            articlesDb.CreateBy = _authorizeExtension.GetUser().Id;
            articlesDb.CreateDate = Extension.Now();

            await _repositoryService.AddAsync(articlesDb,cancellationToken);

            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;

            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi tạo bài viết !");

            return saveResult;
        }
    }
}
