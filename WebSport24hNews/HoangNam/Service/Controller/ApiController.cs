using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebSport24hNews.HoangNam.Core.Extensions;

namespace WebSport24hNews.HoangNam.Service.Controller
{
        [AuthorizeRoleV2("")]
        [Route("api/v{v:apiVersion}/[controller]")]
        [ApiController]
        public abstract class ApiController : ControllerBase
        {
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            // Sử dụng properties public để truy cập (convention C#)
            protected IMediator Mediator => _mediator;
            protected IMapper Mapper => _mapper;

            protected ApiController(IMediator mediator, IMapper mapper)
            {
                _mediator = mediator;
                _mapper = mapper;
            }

            [NonAction]
            protected void Information(string message)
            {
                LogExtension.Information(message);
            }

            [NonAction]
            protected void Warning(string message)
            {
                LogExtension.Warning(message);
            }

            [NonAction]
            protected void Error(string message)
            {
                LogExtension.Error(message);
            }

            [NonAction]
            protected void Verbose(string message)
            {
                LogExtension.Verbose(message);
            }
        }
    
}
