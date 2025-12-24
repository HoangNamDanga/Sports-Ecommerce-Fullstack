using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hNewsArticlesSport;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hNewsArticlesSport
{
    public class GetById24hNewsArticlesSportQuery : IQueryBase<DhnArticlesSportQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetById24hNewsArticlesSportQueryHandler : IRequestBaseHandler<GetById24hNewsArticlesSportQuery, DhnArticlesSportQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetById24hNewsArticlesSportQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<DhnArticlesSportQuery> Handle(GetById24hNewsArticlesSportQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisArrticles = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<DhnNewsArticle>(a => a.Id == request.Id) ?? throw new BaseException("Không tìm thấy bài viết !");

            return _mapper.Map<DhnArticlesSportQuery>(exisArrticles);
        }
    }
}
