using AutoMapper;
using WebSport24hNews.Application.Command.Handlerr._24hArticles;
using WebSport24hNews.Application.Command.Handlerr._24hProductImage;
using WebSport24hNews.Application.Command.Modell._24hArticlesComment;
using WebSport24hNews.Application.Command.Modell._24hCategories;
using WebSport24hNews.Application.Command.Modell._24hCategoriesProduct;
using WebSport24hNews.Application.Command.Modell._24hComment;
using WebSport24hNews.Application.Command.Modell._24hFeedBackSubmission;
using WebSport24hNews.Application.Command.Modell._24hLeagues;
using WebSport24hNews.Application.Command.Modell._24hMatches;
using WebSport24hNews.Application.Command.Modell._24hNewsArticlesSport;
using WebSport24hNews.Application.Command.Modell._24hOrder;
using WebSport24hNews.Application.Command.Modell._24hPlayers;
using WebSport24hNews.Application.Command.Modell._24hProduct;
using WebSport24hNews.Application.Command.Modell._24hRelatedArticles;
using WebSport24hNews.Application.Command.Modell._24hTeam;
using WebSport24hNews.Application.Command.Modell._24hVideos;
using WebSport24hNews.Application.Command.Modell.Account;
using WebSport24hNews.Application.Query.Model._24hArticles;
using WebSport24hNews.Application.Query.Model._24hArticlesComment;
using WebSport24hNews.Application.Query.Model._24hCategories;
using WebSport24hNews.Application.Query.Model._24hCategoriesProduct;
using WebSport24hNews.Application.Query.Model._24hComment;
using WebSport24hNews.Application.Query.Model._24hLeagues;
using WebSport24hNews.Application.Query.Model._24hMatches;
using WebSport24hNews.Application.Query.Model._24hNewsArticlesSport;
using WebSport24hNews.Application.Query.Model._24hPlayers;
using WebSport24hNews.Application.Query.Model._24hProduct;
using WebSport24hNews.Application.Query.Model._24hProductImage;
using WebSport24hNews.Application.Query.Model._24hRelatedArticles;
using WebSport24hNews.Application.Query.Model._24hTeam;
using WebSport24hNews.Application.Query.Model._24hVideos;
using WebSport24hNews.Application.Query.Model.Account;
using WebSport24hNews.Application.Query.Model.PremierLeagueStanding;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.AutoMapper
{
    public class HoangNamProfile : Profile
    {
        public HoangNamProfile()
        {
            #region ApprovalLoginUser24h
            CreateMap<ApproveLoginUsers24h, ApproveLoginUser24h>();
            CreateMap<ApproveLoginUser24h, ApproveLoginUsers24h>();
            #endregion

            #region Register
            CreateMap<RegisterUser24hCommand,User24h>();
            #endregion

            #region User24h
            CreateMap<User24hCommand, User24h>();
            CreateMap<User24h, User24hQuery>();
            #endregion

            #region Register
            CreateMap<LeaguesCommand, League>();
            CreateMap<League, LeaguesQuery>();
            #endregion

            #region Teams
            CreateMap<TeamsCommand, Team>();
            CreateMap<Team, TeamsQuery>();
            #endregion

            #region Matches
            CreateMap<MatchesCommand, Match>();
            CreateMap<Match, MatchesQuery>();
            #endregion

            #region Articles
            CreateMap<ArticlesCommand, Article>();
            CreateMap<Article, ArticlesQuery>();
            #endregion

            #region RelatedArticles
            CreateMap<RelatedArticlesCommand, RelatedArticle>();
            CreateMap<RelatedArticle, RelatedArticlesQuery>();
            #endregion

            #region Categories
            CreateMap<CategoriesCommand, Category>();
            CreateMap<Category, CategoriesQuery>();
            #endregion

            #region Players
            CreateMap<PlayersCommand, Player>();
            CreateMap<Player, PlayersQuery>();
            #endregion

            #region Videos
            CreateMap<VideosCommand, Video>();
            CreateMap<CreateVideoCommand, Video>();
            CreateMap<UpdateVideoRequest, Video>();
            CreateMap<Video, VideosQuery>();

            #endregion

            #region Videos 1-n
            //1-n phuc vu getDeTails
            CreateMap<Video, VideoCommentQuery>();
            CreateMap<CommentCommand, Comment>();
            CreateMap<Comment, CommentQuery>();
            #endregion



            #region ArticlesComment
            CreateMap<ArticlesCommentCommand, Article>();
            CreateMap<Article, ArticlesCommentQuery>();
            CreateMap<CommentCommand, Comment>();
            CreateMap<Comment, CommentQuery>();
            #endregion

            #region RelatedArticles
            CreateMap<RelatedArticle, RelatedArticlesQuery>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RelatedArticleNavigation.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.RelatedArticleNavigation.Title))
                .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.RelatedArticleNavigation.Summary))
                .ForMember(dest => dest.PublishedAt, opt => opt.MapFrom(src => src.RelatedArticleNavigation.PublishedAt))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.RelatedArticleNavigation.Slug))
                .ForMember(dest => dest.FeaturedImage, opt => opt.MapFrom(src => src.RelatedArticleNavigation.FeaturedImage));
            #endregion


            #region RelatedArticlesCRUD
            CreateMap<RelatedArticlesCommand, RelatedArticle>();
            CreateMap<RelatedArticle, RelatedArticlesQuery>();
            #endregion

            #region Comments
            CreateMap<CommentsSingleCommand, Comment>();
            CreateMap<Comment, CommentsSingleQuery>();
            #endregion


            #region FeedBackSubmission
            CreateMap<FeedBackSubmissionCommand, FeedbackSubmission>();
            #endregion

            #region Products
            CreateMap<DhnProductCommand, DhnProduct>();
            CreateMap<DhnProduct, DhnProductQuery>();
            #endregion

            #region ProductImage
            CreateMap<DhnProductImageCommand, DhnProductImage>();
            CreateMap<DhnProductImage, DhnProductImageQuery>();
            #endregion

            #region CategoriesProduct
            CreateMap<DhnCategoriesCommand, DhnCategory>();
            CreateMap<DhnCategory, DhnCategoriesQuery>();
            #endregion


            #region ArticlesSport
            CreateMap<DhnArticlesSportCommand, DhnNewsArticle>();
            CreateMap<DhnNewsArticle, DhnArticlesSportQuery>();
            #endregion


            #region Order
            CreateMap<CreateOrderDto, DhnOrder>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => "Pending"))
                .ForMember(dest => dest.CreateBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore());
            #endregion
        }
    }
}
