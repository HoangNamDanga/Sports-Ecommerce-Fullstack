using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hComment;
using WebSport24hNews.Application.Query.Model._24hVideos;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hVideoComment
{
    public class GetBySlugVideoCommentQuery : IQueryBase<VideoCommentQuery>
    {
        public string Slug { get; set; }
    }
    public class GetBySlugVideoCommentQueryHandler : IRequestBaseHandler<GetBySlugVideoCommentQuery, VideoCommentQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetBySlugVideoCommentQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<VideoCommentQuery> Handle(GetBySlugVideoCommentQuery request, CancellationToken cancellationToken)
        {
            if(request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisVideoSlug = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Video>(v => v.Slug == request.Slug)
                ?? throw new BaseException("Không tìm thấy video !");

            var exisComments = await _repositoryService.Where<Comment>(c => c.VideoId == exisVideoSlug.Id).ToListAsync();

            Console.WriteLine("Số comment lấy được: " + exisComments.Count);

            var mappedComments = _mapper.Map<List<CommentQuery>>(exisComments);

            //xây dựng cây quan hệ cha-con
            var commentLookup = mappedComments.ToLookup(c => c.ParentCommentId);

            foreach (var comment in mappedComments)
            {
                comment.Children = commentLookup[comment.Id].ToList();
            }

            //Chỉ lấy các bình luận gốc (ParentCommentId == null) làm đầu góc của cây

            var rootComments = mappedComments.Where(c => c.ParentCommentId == null).ToList();

            var result = _mapper.Map<VideoCommentQuery>(exisVideoSlug);
            result.commentQuery = rootComments;

            return result;
        }
    }
}
