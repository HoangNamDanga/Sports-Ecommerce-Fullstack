using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hCategories;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hCategories
{
    public class Update24hCategoriesCommand : ICommandBase<bool>
    {
        public CategoriesCommand categoriesCommand { get; set; }
    }
    public class Update24hCategoriesCommandHandler : IRequestBaseHandler<Update24hCategoriesCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Update24hCategoriesCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Update24hCategoriesCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userId = _authorizeExtension.GetUser().Id;

                var exisCategories = await _repositoryService.FirstOrDefaultAsync<Category>(a => a.Id == request.categoriesCommand.Id);
                if (exisCategories == null)
                    throw new BaseException("Không tìm thấy thể loại danh mục !");

                _mapper.Map(request.categoriesCommand, exisCategories);
                exisCategories.LastUpdateBy = userId;
                exisCategories.LastUpdateDate = Extension.Now();

                //


                var result = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!result)
                    throw new BaseException("Xảy ra lỗi khi cập nhật thể loại danh mục !");

                return result;
        }
    }
}
