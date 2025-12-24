using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hArticlesComment;
using WebSport24hNews.Application.Query.Model._24hComment;
using WebSport24hNews.Application.Query.Model._24hLeagues;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebSport24hNews.Application.Query.Handler._24hArticlesComment
{
    public class GetListNoPagiArticlesCommentQuery : New24hSearchModel,IQueryBase<IEnumerable<ArticlesCommentQuery>>
    {
    }
    public class GetListNoPagiArticlesCommentQueryHandler : IRequestBaseHandler<GetListNoPagiArticlesCommentQuery, IEnumerable<ArticlesCommentQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetListNoPagiArticlesCommentQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<ArticlesCommentQuery>> Handle(GetListNoPagiArticlesCommentQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query = await _repositoryService.Table<Article>().OrderByDescending(a => a.CreateDate).ToListAsync();

            var articlesQuery = _mapper.Map<List<ArticlesCommentQuery>>(query);
            var comment = _repositoryService.Table<Comment>().ToList();
            var commentQuery = _mapper.Map<List<CommentQuery>>(comment);
            foreach (var item in articlesQuery)
            {

                item.commentQuery = commentQuery.Where(a => a.ArticleId == item.Id);
            }

            return articlesQuery;

        }
    }
}
