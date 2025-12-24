using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr.Account
{
    public class DeleteUser24hCommand : ICommandBase<bool>
    {
        public IEnumerable<decimal?> Ids { get; set; }
    }
    public class DeleteUser24hCommandHandler : IRequestBaseHandler<DeleteUser24hCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;
        private readonly IAuditLogger _auditLogger;
        public DeleteUser24hCommandHandler(IRepositoryService repositoryService,
            IMapper mapper,
            IAuthorizeExtensionService authorizeExtension, IAuditLogger auditLogger)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
            _auditLogger = auditLogger;
        }

        public async Task<bool> Handle(DeleteUser24hCommand request, CancellationToken cancellationToken)
        {
            if (!request.Ids.Any())
                throw new BaseException("Yêu cầu không hợp lệ !");

            var resDelete = await _repositoryService.TransactionSmartAwaitAsync(async () =>
            {
                var exisUser24hDb = _repositoryService.Where<User24h>(fa => request.Ids.Contains(fa.Id)).ToList();

                if (!exisUser24hDb.Any())
                    throw new BaseException("Không tìm thấy người dùng !");

                foreach (var item in exisUser24hDb)
                {
                    await _auditLogger.LogAsync(item.Username, "XÓA TÀI KHOẢN USER !", "Xóa tài khoản người dùng từ DeleteUser24hCoommand", item.Phone, item.Fullname);
                    _repositoryService.Delete(item);
                }



                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi xóa người dùng !");

                return saveResult;
            }, cancellationToken);

            return resDelete;
        }
    }
}
