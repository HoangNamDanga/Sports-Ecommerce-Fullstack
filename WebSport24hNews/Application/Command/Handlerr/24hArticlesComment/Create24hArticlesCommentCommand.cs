using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hArticlesComment;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hArticlesComment
{
    public class Create24hArticlesCommentCommand : ICommandBase<bool>
    {
        public ArticlesCommentCommand articlesCommentCommand { get; set; }
    }
    public class Create24hArticlesCommentCommandHandler : IRequestBaseHandler<Create24hArticlesCommentCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hArticlesCommentCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hArticlesCommentCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu khong hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;


                var exisArticles = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Article>(a => a.Id == request.articlesCommentCommand.Id).ConfigureAwait(true);

                if (exisArticles == null)
                    throw new BaseException("Không tìm thấy bài viết");

                var commentCommands = request.articlesCommentCommand.commentCommand;

                var commentDb = commentCommands.Select(cm =>
                {
                    var command = _mapper.Map<Comment>(cm);
                    command.CreateBy = userId;
                    command.CreateDate = DateTime.Now;

                    command.ArticleId = exisArticles.Id;
                    return command;
                }).ToList();

                await _repositoryService.AddAsync(commentDb, cancellationToken);

                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi tạo bình luận !");

                return saveResult;
        }
    }
}
