using AutoMapper;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hCategoriesProduct
{
    public class Delete24hDhnCategoriesProductCommand : ICommandBase<bool>
    {
        public IEnumerable<decimal?> Ids { get; set; }
    }
    public class Delete24hDhnCategoriesProductCommandHandler : IRequestBaseHandler<Delete24hDhnCategoriesProductCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Delete24hDhnCategoriesProductCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Delete24hDhnCategoriesProductCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var deleteDhnCategory = await _repositoryService.FirstOrDefaultAsync<DhnCategory>(p => request.Ids.Contains(p.Id)) ?? throw new BaseException("Không tìm thấy danh mục sản phẩm để xóa !");

            _repositoryService.Delete(deleteDhnCategory);

            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;

            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi xóa thể loại danh mục sản phẩm !");

            return saveResult;
        }
    }
}
