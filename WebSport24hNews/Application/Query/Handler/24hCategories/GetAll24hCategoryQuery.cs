using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model._24hCategories;
using WebSport24hNews.Application.Query.Model._24hCategoriesProduct;
using WebSport24hNews.Application.Query.Model._24hProduct;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler._24hCategories
{
    public class GetAll24hCategoryQuery : IQueryBase<IEnumerable<CategoriesQuery>>
    {
    }
    public class GetAll24hCategoryQueryHandler : IRequestBaseHandler<GetAll24hCategoryQuery, IEnumerable<CategoriesQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetAll24hCategoryQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<CategoriesQuery>> Handle(GetAll24hCategoryQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            //ProjectTo như Map , chỉ lấy ra những field cần thiết, nghĩa là ViewModel hoặc DTO query chứa cái gì thì đó là những field cần thiết.
            //Map mọi property đã được load về, nghĩa là sau khi cơ sở dữ liệu trả ra sau câu lệnh sql
            // ProjectTo chỉ map các property có mặt trong destination.
            return await _repositoryService.Table<Category>().ProjectTo<CategoriesQuery>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
