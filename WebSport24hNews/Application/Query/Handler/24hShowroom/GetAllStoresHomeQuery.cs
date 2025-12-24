using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hStore;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hStores
{
    public class GetAllStoresHomeQuery : IQueryBase<Dictionary<string, List<DhnStoresQuery>>>
    {
    }
    public class GetAllStoresHomeQueryHandler : IRequestBaseHandler<GetAllStoresHomeQuery, Dictionary<string, List<DhnStoresQuery>>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetAllStoresHomeQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;

        }

        public async Task<Dictionary<string, List<DhnStoresQuery>>> Handle(GetAllStoresHomeQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var showrooms = await _repositoryService.Table<DhnStore>().Select(s => new DhnStoresQuery
            {
                Id = s.Id,
                StoreName = s.StoreName,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                Attribute1 = s.Attribute1,
            }).ToListAsync(cancellationToken);

            // nhóm theo location , attribute ở đây là location
            // showrooms.GroupBy(s => s.Attribute1 ?? "Unknown Location") => nhóm và chọn bộ khóa. attribute là key
            var groupedShowrooms = showrooms.GroupBy(s => s.Attribute1 ?? "Unknown Location").ToDictionary(g => g.Key, g => g.ToList());

            return groupedShowrooms;
        }
    }
}
