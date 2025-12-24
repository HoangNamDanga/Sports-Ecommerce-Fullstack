using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hArticlesComment;
using WebSport24hNews.Application.Command.Modell._24hVideos;
using WebSport24hNews.Application.Query.Model.ArticlesCommentQuery;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hArticlesComment
{
    public class Create24hVideoCommentCommand : ICommandBase<CommentModelVideoQuery>
    {
        public CommentCommandVideoModel commentCommandModel { get; set; }
    }
    public class Create24hVideoCommentCommandHandler : IRequestBaseHandler<Create24hVideoCommentCommand, CommentModelVideoQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hVideoCommentCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<CommentModelVideoQuery> Handle(Create24hVideoCommentCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var model = request.commentCommandModel; // lấy comment

            // check video

            var exisArticles = await _repositoryService.FirstOrDefaultAsync<Video>(x => x.Id == model.VideoId);
            if (exisArticles == null)
                throw new BaseException("Không tìm thấy bài viết !");

            var commentEntity = new Comment
            {
                VideoId = model.VideoId,
                Content = model.Content,
                UserId = model.UserId,
                ParentCommentId = model.ParentCommentId,
                IsApproved = true,
                CreateBy = model.UserId ?? 0,
                CreateDate = DateTime.Now,
                LastUpdateBy = model.UserId ?? 0,
                LastUpdateDate = DateTime.Now
            };

            await _repositoryService.AddAsync(commentEntity, cancellationToken);
            var saved = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
            if (!saved)
                throw new BaseException("Xảy ra lỗi khi tạo bình luận!");

            // Lấy user fullname nếu có
            string authorFullName = "Ẩn danh";
            if (commentEntity.UserId.HasValue)
            {
                var user = await _repositoryService.FirstOrDefaultAsync<User24h>(u => u.Id == commentEntity.UserId.Value);
                if (user != null)
                    authorFullName = user.Fullname;
            }

            // Trả về comment vừa tạo
            return new CommentModelVideoQuery
            {
                Id = commentEntity.Id,
                VideoId = commentEntity.VideoId ?? 0,
                Content = commentEntity.Content,
                ParentCommentId = commentEntity.ParentCommentId,
                CreatedDate = commentEntity.CreateDate,
                AuthorFullname = authorFullName
            };
        }
    }
}
