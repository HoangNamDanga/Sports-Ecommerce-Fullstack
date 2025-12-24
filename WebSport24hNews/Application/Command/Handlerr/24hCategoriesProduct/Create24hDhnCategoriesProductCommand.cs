using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hCategoriesProduct;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hCategoriesProduct
{
    public class Create24hDhnCategoriesProductCommand : ICommandBase<bool>
    {
        public DhnCategoriesCommand dhnCategoriesCommand { get; set; }
    }
    public class Create24hDhnCategoriesProductCommandHandler : IRequestBaseHandler<Create24hDhnCategoriesProductCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hDhnCategoriesProductCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hDhnCategoriesProductCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var categoriesDb = _mapper.Map<DhnCategory>(request.dhnCategoriesCommand);
            categoriesDb.CreateBy = _authorizeExtension.GetUser().Id;
            categoriesDb.CreateDate = Extension.Now();

            await _repositoryService.AddAsync(categoriesDb,cancellationToken);
            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;

            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi tạo thể loại danh mục sản phẩm !");

            return saveResult;
        }
    }
}
