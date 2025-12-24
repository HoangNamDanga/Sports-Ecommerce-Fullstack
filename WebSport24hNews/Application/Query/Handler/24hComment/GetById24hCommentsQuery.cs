using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hComment;
using WebSport24hNews.Application.Query.Model._24hLeagues;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hComment
{
    public class GetById24hCommentsQuery : IQueryBase<CommentsSingleQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetById24hCommentsQueryHandler : IRequestBaseHandler<GetById24hCommentsQuery, CommentsSingleQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetById24hCommentsQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<CommentsSingleQuery> Handle(GetById24hCommentsQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisCommentsDb = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<Comment>(l => l.Id == request.Id);

            if (exisCommentsDb == null)
                throw new BaseException("Không tìm thấy comment !");

            return _mapper.Map<CommentsSingleQuery>(exisCommentsDb);
        }
    }
}
