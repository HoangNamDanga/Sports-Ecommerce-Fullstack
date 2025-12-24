using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebSport24hNews.Application.Query.Model.DhnProducts;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Query.Handler.DhnProducts
{
    public class GetListBestSellerProductQuery : IQueryBase<IEnumerable<DhnBestSellerProductQuery>>
    {
    }
    public class GetListBestSellerProductQueryHandler : IRequestBaseHandler<GetListBestSellerProductQuery, IEnumerable<DhnBestSellerProductQuery>>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public GetListBestSellerProductQueryHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<IEnumerable<DhnBestSellerProductQuery>> Handle(GetListBestSellerProductQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var query =  from product in _repositoryService.Table<DhnProduct>()
                              where product.IsBestSeller == "Y"
                              join image in _repositoryService.Table<DhnProductImage>()
                              on product.Id equals image.ProductId into productGroup
                              from thump in productGroup.Where(p => p.IsThumbnail == "Y").Take(1).DefaultIfEmpty()
                              select new DhnBestSellerProductQuery
                              {
                                  Id = product.Id,
                                  ProductName = product.ProductName,
                                  CurrentPrice = product.CurrentPrice,
                                  Description = product.Description,
                                  Brand = product.Brand,
                                  ThumbnailUrl = thump != null ? thump.ImageUrl : null
                              };

            return await query.ToListAsync();
        }
    }
}
