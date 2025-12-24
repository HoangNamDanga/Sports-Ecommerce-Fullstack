using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebSport24hNews.Application.Command.Modell.Account;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr.Account
{
    public class UpdateUser24hCommand : ICommandBase<bool>
    {
        public User24hCommand user24HCommand { get; set; }
    }
    public class UpdateUser24hCommandHandler : IRequestBaseHandler<UpdateUser24hCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;
        private readonly IAuditLogger _auditLogger;
        public UpdateUser24hCommandHandler(IRepositoryService repositoryService,IMapper mapper,
            IAuthorizeExtensionService authorizeExtension, IAuditLogger auditLogger)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
            _auditLogger = auditLogger;
        }

        public async Task<bool> Handle(UpdateUser24hCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userName = _authorizeExtension.UserName;

            var resUpdate = await _repositoryService.TransactionSmartAwaitAsync(async () =>
            {
                var exisUser24h = await _repositoryService.FirstOrDefaultAsync<User24h>(fa => fa.Id == request.user24HCommand.Id);

                if (exisUser24h == null)
                    throw new BaseException("Không tìm thấy người dùng !");

                _mapper.Map(request.user24HCommand, exisUser24h);
                exisUser24h.Modifyby = "Quản trị viên !"; // or userName
                exisUser24h.Modifydate = Extension.Now();

                await _auditLogger.LogAsync(exisUser24h.Username, "CẬP NHẬT TÀI KHOẢN MỚI !", "Cập nhật tài khoản người dùng từ UpdateUser24hCoommand", exisUser24h.Phone, exisUser24h.Fullname);
                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi cập nhật người dùng !");
                return saveResult;
            }, cancellationToken);
            return resUpdate;
        }
    }
}
