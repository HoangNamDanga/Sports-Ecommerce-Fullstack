using AutoMapper;
using WebSport24hNews.Application.Query.Model._24hLeagues;
using WebSport24hNews.Application.Query.Model.Account;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler.Account
{
    public class GetListUser24hQuery : New24hSearchModel, IQueryBase<IPagedList<User24hQuery>>
    {
    }
    public class GetListUser24hQueryHandler : IRequestBaseHandler<GetListUser24hQuery, IPagedList<User24hQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetListUser24hQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IPagedList<User24hQuery>> Handle(GetListUser24hQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query = _repositoryService.Table<User24h>();

            if (!string.IsNullOrEmpty(request.KeySearch))
            {
                var keyWork = request.KeySearch.ToLower();
                query = query.Where(fa => fa.Username.ToLower().Contains(keyWork) ||
                                          fa.Password.ToLower().Contains(keyWork) ||
                                          fa.Role.ToLower().Contains(keyWork) ||
                                          fa.Phone.ToLower().Contains(keyWork) ||
                                          fa.Fullname.ToLower().Contains(keyWork) ||
                                          fa.Createby.ToLower().Contains(keyWork) ||
                                          fa.Tokenactive.ToLower().Contains(keyWork) ||
                                          fa.Codeactive.ToLower().Contains(keyWork) ||
                                          fa.Center.ToLower().Contains(keyWork));
            }

            if (!string.IsNullOrEmpty(request.Sort))
            {
                var fieldType = request.Sort.GetPropertyGetter<User24h>();
                query = request.IsOrder == true ? query.OrderBy(fieldType) : query.OrderByDescending(fieldType);
            }

            if (request.StartDate.HasValue)
            {
                query = query.Where(fa => fa.Createdate >= request.StartDate.Value);
            }

            if (request.EndDate.HasValue)
            {
                query = query.Where(fa => fa.Createdate <= request.EndDate.Value);
            }

            var page = await query.PagedList(request.Take, request.Skip);

            PagedList<User24hQuery> res = new PagedList<User24hQuery>();
            res.Lists = _mapper.Map<IList<User24hQuery>>(page.Lists);
            res.Count = page.Count;

            return res;
        }
    }
}
