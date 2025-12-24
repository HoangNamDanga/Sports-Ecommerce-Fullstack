using AutoMapper;
using Dapper;
using System.Data;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hArticles
{
    public class Update24hArticlesCommand : ICommandBase<bool>
    {
        public ArticlesCommand articlesCommand { get; set; }
    }
    public class Update24hArticlesCommandHandler : IRequestBaseHandler<Update24hArticlesCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Update24hArticlesCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Update24hArticlesCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ!");

            var userId = _authorizeExtension.GetUser().Id;

            var sqlSelect = @"SELECT * FROM ARTICLES WHERE ID = :Id";

            using var connection = _repositoryService.GetDbConnection();

            // Mở connection nếu cần
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync(cancellationToken);

            // Lấy bài viết hiện có
            var existingArticle = await connection.QueryFirstOrDefaultAsync<Article>(sqlSelect, new { Id = request.articlesCommand.Id });

            if (existingArticle == null)
                throw new BaseException("Không tìm thấy bài viết!");

            // Cập nhật dữ liệu
            _mapper.Map(request.articlesCommand, existingArticle);
            existingArticle.LastUpdateBy = userId;
            existingArticle.LastUpdateDate = Extension.Now();

            var sqlUpdate = @"
                    UPDATE ARTICLES SET
                        TITLE = :Title,
                        CONTENT = :Content,
                        SUMMARY = :Summary,
                        AUTHOR_ID = :AuthorId,
                        TEAM_ID = :TeamId,
                        SLUG = :Slug,
                        FEATURED_IMAGE = :FeaturedImage,
                        VIEW_COUNT = :ViewCount,
                        IS_FEATURED = :IsFeatured,
                        LAST_UPDATE_BY = :LastUpdateBy,
                        LAST_UPDATE_DATE = :LastUpdateDate,
                        CATEGORY_ID = :CategoryId
                    WHERE ID = :Id";

            var affectedRows = await connection.ExecuteAsync(sqlUpdate, new
            {
                Title = existingArticle.Title,
                Content = existingArticle.Content,
                Summary = existingArticle.Summary,
                AuthorId = existingArticle.AuthorId,
                TeamId = existingArticle.TeamId,
                Slug = existingArticle.Slug,
                FeaturedImage = existingArticle.FeaturedImage,
                ViewCount = existingArticle.ViewCount,
                IsFeatured = (bool)existingArticle.IsFeatured ? 1 : 0, // 👈 CHÚ Ý: bool ➜ 1/0
                LastUpdateBy = existingArticle.LastUpdateBy,
                LastUpdateDate = existingArticle.LastUpdateDate,
                CategoryId = existingArticle.CategoryId,
                Id = existingArticle.Id
            });

            if (affectedRows <= 0)
                    throw new BaseException("Xảy ra lỗi khi cập nhật bài viết!");

                return true;
        }
    }
}
