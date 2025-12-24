using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hArticles;
using WebSport24hNews.Application.Command.Handlerr._24hTeam;
using WebSport24hNews.Application.Command.Modell._24hTeam;
using WebSport24hNews.Application.Query.Handler._24hArticles;
using WebSport24hNews.Application.Query.Handler._24hLeagues;
using WebSport24hNews.Application.Query.Handler._24hTeam;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    //[Authorize(Policy = "AdminOnly")]
    [ApiController]
    [AllowAnonymous]
    public class ArticlesController : ApiController
    {
        public ArticlesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R
        [Route("create")]
        [HttpGet]
        [SwaggerOperation("Lấy model tạo bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create()
        {
            return Ok(new MessageResponse()
            {
                success = true,
                data = new ArticlesCommand()
            });
        }

        [Route("update")]
        [HttpGet]
        [SwaggerOperation("Lấy model cập nhật bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetById24hArticlesQuery()
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
        [SwaggerOperation("Lấy chi tiết bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetails([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetDetail24hArticlesQuery()
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
        [SwaggerOperation("Lấy danh sách bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] GetList24hArticlesQuery request)
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


        [Route("get-all-random")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách bài viết ngẫu nhiên ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetAllRandom()
        {
            var data = await Mediator.Send(new GetAllRandomArticles());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null
            };

            return Ok(result);
        }


        [Route("get-all-articles")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách all bài viết ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetAll()
        {
            var data = await Mediator.Send(new GetAll24hArticlesQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }


        [HttpGet("latest-football-article")]
        [SwaggerOperation("Lấy bài viết mới nhất")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetTop1Dapper()
        {
            var data = await Mediator.Send(new GetList24hSelectTopHomeQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }

        [HttpGet("three-categories-football-article")]
        [SwaggerOperation("Lấy bài viết mới nhất")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]


        //Lấy ra 3 bài viết thuộc 3 nhóm categories đc định sẵn , Bóng đá việt nam, chuyển nhượng , bóng đá quốc tế
        public async Task<IActionResult> GetTop3ArticlesByCategory()
        {
            var data = await Mediator.Send(new GetList24hThreeTypeCategoriesNameQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }


        [HttpGet("latest-eight-football-article")]
        [SwaggerOperation("Lấy 8 bài viết mới nhất")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetTop8Dapper()
        {
            var data = await Mediator.Send(new GetList24hEightArticlesQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }


        [HttpGet("random-articles")]
        [SwaggerOperation("Lấy random 3 bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetTop3DapperRandom()
        {
            var data = await Mediator.Send(new Get24hRandomArticlesQuery());
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
        [SwaggerOperation("Create bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] ArticlesCommand command)
        {
            var data = await Mediator.Send(new Create24hArticlesCommand()
            {
                articlesCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }


        [Route("update")]
        [HttpPost]
        [SwaggerOperation("Update bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Update([FromBody] ArticlesCommand command)
        {
            var data = await Mediator.Send(new Update24hArticlesCommand()
            {
                articlesCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Chỉnh sửa thành công !" : "Chỉnh sửa thất bại !",
                success = data,
            });
        }

        [Route("delete")]
        [HttpPost]
        [SwaggerOperation("Delete bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Delete([FromBody] IEnumerable<decimal?> Ids)
        {
            var data = await Mediator.Send(new Delete24hArticlesCommand()
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
