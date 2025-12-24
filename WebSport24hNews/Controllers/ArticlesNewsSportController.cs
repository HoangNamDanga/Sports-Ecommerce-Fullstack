using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hCategories;
using WebSport24hNews.Application.Command.Handlerr._24hNewsArticlesSport;
using WebSport24hNews.Application.Command.Modell._24hCategories;
using WebSport24hNews.Application.Command.Modell._24hNewsArticlesSport;
using WebSport24hNews.Application.Query.Handler._24hCategories;
using WebSport24hNews.Application.Query.Handler._24hNewsArticlesSport;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class ArticlesNewsSportController : ApiController
    {
        public ArticlesNewsSportController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R
        [Route("create")]
        [HttpGet]
        [SwaggerOperation("Lấy model tạo bài viết sport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create()
        {
            return Ok(new MessageResponse()
            {
                success = true,
                data = new DhnArticlesSportCommand()
            });
        }


        [Route("update")]
        [HttpGet]
        [SwaggerOperation("Lấy model tạo bài viết sport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetById24hNewsArticlesSportQuery()
            {
                Id = id
            });

            return Ok(new MessageResponse()
            {
                success = true,
                data = data,
            });
        }


        [Route("detail")]
        [HttpGet]
        [SwaggerOperation("Lấy chi tiết bài viết sport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetails([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetDetail24hNewsArticlesSportQuery()
            {
                Id = id
            });

            if (data is null)
            {
                return Ok(new MessageResponse()
                {
                    message = "Không tìm thấy dữ liệu !",
                    data = null,
                    success = false,
                });
            }
            var result = new MessageResponse()
            {
                data = data,
                success = true,
            };
            return Ok(result);
        }

        [Route("get-list")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách bài viết sport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] GetList24hNewsArticlesSportQuery request)
        {
            var data = await Mediator.Send(request);
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
                totalCount = data.Count
            };

            return Ok(result);
        }


        [Route("get-five-article")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách 5 bài viết sport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetListFiveArticle( )
        {
            var data = await Mediator.Send(new GetListArticlesSportHomeQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }


        #endregion

        #region CUD
        [Route("create")]
        [HttpPost]
        [SwaggerOperation("Create bài viết sport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] DhnArticlesSportCommand command)
        {
            var data = await Mediator.Send(new Create24hNewsArticlesSportCommand()
            {
                dhnArticlesSportCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }

        [Route("update")]
        [HttpPost]
        [SwaggerOperation("Update bài viết sport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Update([FromBody] DhnArticlesSportCommand command)
        {
            var data = await Mediator.Send(new Update24hNewsArticlesSportCommand()
            {
                dhnArticlesSportCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Chỉnh sửa thành công !" : "Chỉnh sửa thất bại !",
                success = data,
            });
        }

        [Route("delete")]
        [HttpPost]
        [SwaggerOperation("Delete bài viết sport")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Delete([FromBody] IEnumerable<decimal?> Ids)
        {
            var data = await Mediator.Send(new Delete24hNewsArticlesSportCommand()
            {
                Ids = Ids
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Xóa thành công !" : "Xóa thất bại !",
                success = data,
            });
        }
        #endregion
    }
}
