using AutoMapper;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hProductImage
{
    //Hàm này cũng là tạo nhưng không theo kiểu tạo và upload ảnh vào db, ko sử dụng !!!!
    public class Create24hProductImageCommand : ICommandBase<bool>
    {
        public DhnProductImageCommand dhnProductImageCommand { get; set; }
    }
    public class Create24hProductImageCommandHandler : IRequestBaseHandler<Create24hProductImageCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hProductImageCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hProductImageCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException();

            var useId = _authorizeExtension.GetUser().Id;
            var dhnProductImageDb = _mapper.Map<DhnProductImage>(request.dhnProductImageCommand);
            dhnProductImageDb.CreateBy = useId;
            dhnProductImageDb.CreateDate = DateTime.UtcNow;

            await _repositoryService.AddAsync(dhnProductImageDb, cancellationToken);

            var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
            if (!saveResult)
                throw new BaseException("Xảy ra lỗi khi tạo ảnh sản phẩm !");
            return saveResult;
        }
    }
}
