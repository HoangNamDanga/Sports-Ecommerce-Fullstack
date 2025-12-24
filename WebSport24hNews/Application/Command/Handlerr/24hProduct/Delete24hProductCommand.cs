using AutoMapper;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hProduct
{
    public class Delete24hProductCommand : ICommandBase<bool>
    {
        public IEnumerable<decimal?> Ids { get; set; }

    }
    public class Delete24hProductCommandHandler : IRequestBaseHandler<Delete24hProductCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Delete24hProductCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Delete24hProductCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var deleteProduct = await _repositoryService.FirstOrDefaultAsync<DhnProduct>(p => request.Ids.Contains(p.Id));

            if (deleteProduct == null)
                throw new BaseException("Không tìm thấy sản phẩm !");

            _repositoryService.Delete(deleteProduct);

            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi xóa sản phẩm !");

            return saveResult;
        }
    }
}
