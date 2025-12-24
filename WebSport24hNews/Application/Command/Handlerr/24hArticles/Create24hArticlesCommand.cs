using AutoMapper;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hArticles
{
    public class Create24hArticlesCommand : ICommandBase<bool>
    {
        public ArticlesCommand articlesCommand { get; set; }
    }
    public class Create24hArticlesCommandHandler : IRequestBaseHandler<Create24hArticlesCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hArticlesCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hArticlesCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;

            // Không cần dùng TransactionSmartAwaitAsync nữa
            // Chỉ cần gọi trực tiếp các phương thức của repository

            var articlesDb = _mapper.Map<Article>(request.articlesCommand);
            articlesDb.CreateBy = userId;
            articlesDb.CreateDate = Extension.Now();


            Console.WriteLine("Title length: " + articlesDb.Title?.Length);
            Console.WriteLine("Summary length: " + articlesDb.Summary?.Length);
            Console.WriteLine("Content length: " + articlesDb.Content?.Length);
            // Đảm bảo AddAsync hoàn tất
            await _repositoryService.AddAsync(articlesDb, cancellationToken);

            // Đảm bảo SaveChanges hoàn tất
            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;

            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi tạo bài viết !");

            return saveResult;
        }
    }
}
