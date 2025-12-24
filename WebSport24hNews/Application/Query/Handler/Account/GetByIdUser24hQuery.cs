using AutoMapper;
using WebSport24hNews.Application.Query.Model.Account;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler.Account
{
    public class GetByIdUser24hQuery : IQueryBase<User24hQuery>
    {
        public decimal Id { get; set; }
    }
    public class GetByIdUser24hQueryHandler : IRequestBaseHandler<GetByIdUser24hQuery, User24hQuery>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetByIdUser24hQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<User24hQuery> Handle(GetByIdUser24hQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var exisUserDb = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<User24h>(fa => fa.Id == request.Id);

            if (exisUserDb == null)
                throw new BaseException("Không tìm thấy người dùng !");

            return _mapper.Map<User24hQuery>(exisUserDb);
        }
    }
}
