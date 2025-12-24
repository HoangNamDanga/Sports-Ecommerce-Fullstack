using AutoMapper;
using WebSport24hNews.Application.Command.Modell._24hFeedBackSubmission;
using WebSport24hNews.HoangNam.Core.CQRS;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Repository;
using WebSport24hNews.HoangNam.Service.Sercurity;
using WebSport24hNews.Models;

namespace WebSport24hNews.Application.Command.Handlerr._24hFeedBackSubmission
{
    public class Create24hFeedBackSubmissionCommand : ICommandBase<bool>
    {
        public FeedBackSubmissionCommand feedBackSubmissionCommand { get; set; }
    }
    public class Create24hFeedBackSubmissionCommandHandler : IRequestBaseHandler<Create24hFeedBackSubmissionCommand, bool>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IMapper _mapper;
        //private readonly IHybridCachingManager _cacheExtension;
        private readonly IAuthorizeExtensionService _authorizeExtension;

        public Create24hFeedBackSubmissionCommandHandler(IRepositoryService repositoryService, IMapper mapper, IAuthorizeExtensionService authorizeExtension)
        {
            //_repositoryService = EngineContext.Current.Resolve<IRepositoryService>("RepositoryService")
            //?? throw new ArgumentNullException(nameof(_repositoryService));
            _repositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
            _mapper = mapper;
            _authorizeExtension = authorizeExtension;
        }

        public async Task<bool> Handle(Create24hFeedBackSubmissionCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new BaseException();


            var userId = _authorizeExtension.GetUser().Id;
            var feedBack = _mapper.Map<FeedbackSubmission>(request.feedBackSubmissionCommand);
            feedBack.CreateBy = userId;
            feedBack.CreateDate = Extension.Now();


            await _repositoryService.AddAsync(feedBack, cancellationToken);

            var result = await _repositoryService.SaveChangesConfigureAwaitAsync(cancellationToken) > 0;

            if (!result)
                throw new BaseException("Xảy ra lỗi khi tạo Góp ý ");

            return result;
        }
    }
}
