using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hComment;
using WebSport24hNews.Application.Command.Handlerr._24hFeedBackSubmission;
using WebSport24hNews.Application.Command.Modell._24hComment;
using WebSport24hNews.Application.Command.Modell._24hFeedBackSubmission;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    //[Authorize(Policy = "AdminOnly")]
    [AllowAnonymous]
    public class FeedBackSubmissionController : ApiController
    {
        public FeedBackSubmissionController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region CUD
        [Route("create")]
        [HttpPost]
        [SwaggerOperation("Create FeedBackSubmission")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] FeedBackSubmissionCommand command)
        {
            var data = await Mediator.Send(new Create24hFeedBackSubmissionCommand()
            {
                feedBackSubmissionCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }

        #endregion
    }
}
