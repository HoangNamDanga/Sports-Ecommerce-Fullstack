using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hArticlesComment;
using WebSport24hNews.Application.Query.Model._24hComment;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;
using Microsoft.EntityFrameworkCore;
namespace WebSport24hNews.Application.Query.Handler._24hArticlesComment
{
    public class GetBySlugArticlesCommentQuery  : IQueryBase<ArticlesCommentQuery>
    {
        public string Slug { get; set; }
    }
    public class GetBySlugArticlesCommentQueryHandler : IRequestBaseHandler<GetBySlugArticlesCommentQuery, ArticlesCommentQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetBySlugArticlesCommentQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<ArticlesCommentQuery> Handle(GetBySlugArticlesCommentQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisArticles = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Article>(a => a.Slug == request.Slug);

            if (exisArticles == null)
                throw new BaseException("Không tìm thấy bài viết !");

            var exisComments = await _repositoryService.Where<Comment>(a => a.ArticleId == exisArticles.Id).ToListAsync(cancellationToken);

            Console.WriteLine("Số comment lấy được: " + exisComments.Count);

            var mappedComments = _mapper.Map<List<CommentQuery>>(exisComments);


            //xây dựng cây quan hệ cha-con
            var commentLookup = mappedComments.ToLookup(c => c.ParentCommentId);

            foreach (var comment in mappedComments)
            {
                comment.Children = commentLookup[comment.Id].ToList();
            }

            //Chỉ lấy các bình luận gốc (ParentCommentId == null) làm đầu gốc của cây
            var rootComments = mappedComments.Where(c => c.ParentCommentId == null).ToList();

            var result = _mapper.Map<ArticlesCommentQuery>(exisArticles);
            result.commentQuery = rootComments;

            return result;
        }
    }
}
