using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hArticles;
using WebSport24hNews.Application.Command.Handlerr._24hImage;
using WebSport24hNews.Application.Query.Handler._24hPlayers;
using WebSport24hNews.Application.Query.Handler._24hRelatedArticles;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class RelatedArticlesController : ApiController
    {
        public RelatedArticlesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R
        [Route("get-list")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách bài viết liên quan")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetList24hRelatedArticlesQuery()
            {
                Id = id
            });
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }


        [Route("image")]
        [HttpPost]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(10 * 1024 * 1024)] // Giới hạn 10MB
        [SwaggerOperation("Update Ảnh")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> UpdloadImage([FromForm] UploadImageRequest request)
        {
            if (request.File == null)
                return BadRequest("File is required");

            var url = await Mediator.Send(new UploadImageCommand(request.File));
            return Ok(new { imageUrl = url });

        }

        #endregion
    }
}
