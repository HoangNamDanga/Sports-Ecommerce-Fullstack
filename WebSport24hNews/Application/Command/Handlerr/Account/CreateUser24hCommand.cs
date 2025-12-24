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
    public class CreateUser24hCommand : ICommandBase<bool>
    {
        public User24hCommand user24HCommand { get; set; }
    }
    public class CreateUser24hCommandHandler : IRequestBaseHandler<CreateUser24hCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;
        private readonly IAuditLogger _auditLogger;
        public CreateUser24hCommandHandler(IRepositoryService repositoryService,
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

        public async Task<bool> Handle(CreateUser24hCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException("Yêu cầu không hợp lệ !");

            var userName = _authorizeExtension.UserName;

            var resCreate = await _repositoryService.TransactionSmartAwaitAsync(async () =>
            {
                var exisUser24hDb = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<User24h>(fa => fa.Username == request.user24HCommand.Username);
                if (exisUser24hDb != null)
                    throw new BaseException("UserName đã tồn tại vui lòng thử UserName khác !");

                var exisUser24hPhoneDb = await _repositoryService.FirstOrDefaultAsNoTrackingAsync<User24h>(fa => fa.Phone.Equals(request.user24HCommand.Phone));
                if (exisUser24hPhoneDb != null)
                {
                    throw new BaseException("Số điện thoại đã tồn tại vui lòng thử số điện thoại khác !");
                }

                var user24hDb = _mapper.Map<User24h>(request.user24HCommand);
                user24hDb.Createby = "Quản trị viên !";
                user24hDb.Createdate = Extension.Now();

                await _repositoryService.AddAsync(user24hDb,cancellationToken);

                await _auditLogger.LogAsync(user24hDb.Username, "TẠO TÀI KHOẢN MỚI !", "Tạo người dùng từ CreateUser24hCoommand", user24hDb.Phone, user24hDb.Fullname);


                var saveResult = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;
                if (!saveResult)
                    throw new BaseException("Xảy ra lỗi khi tạo người dùng !");

                return saveResult;
            }, cancellationToken);
            return resCreate;
        }
    }
}
