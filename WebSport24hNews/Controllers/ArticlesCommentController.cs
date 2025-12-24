using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hArticles;
using WebSport24hNews.Application.Command.Handlerr._24hArticlesComment;
using WebSport24hNews.Application.Command.Modell._24hArticlesComment;
using WebSport24hNews.Application.Query.Handler._24hArticles;
using WebSport24hNews.Application.Query.Handler._24hArticlesComment;
using WebSport24hNews.Application.Query.Model.ArticlesCommentQuery;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class ArticlesCommentController : ApiController
    {
        public ArticlesCommentController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R
        [Route("detail")]
        [HttpGet]
        [SwaggerOperation("Lấy chi tiết bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetails([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetByIdArticlesCommentQuery()
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


        [Route("detail-slug")]
        [HttpGet]
        [SwaggerOperation("Lấy chi tiết bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Gétlug([FromQuery] string slug)
        {
            var data = await Mediator.Send(new GetBySlugArticlesCommentQuery()
            {
                Slug = slug
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
                data = new ArticlesCommentCommand()
            });
        }

        [Route("get-list")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList()
        {
            var data = await Mediator.Send(new GetListNoPagiArticlesCommentQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null
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

        public async Task<IActionResult> Create([FromBody] ArticlesCommentCommand command)
        {
            var data = await Mediator.Send(new Create24hArticlesCommentCommand()
            {
                articlesCommentCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }


        [Route("create-comment")]
        [HttpPost]
        [SwaggerOperation("Create comment (Bình luận)")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateComment([FromBody] CommentCommandModel model, CancellationToken cancellationToken)
        {
            if (model == null)
            {
                return BadRequest(new MessageResponse
                {
                    success = false,
                    httpStatusCode = 400,
                    message = "Dữ liệu bình luận không hợp lệ."
                });
            }

            var command = new Create24hCommentCommand
            {
                commentCommandModel = model
            };

            try
            {
                var result = await Mediator.Send(command, cancellationToken);

                return Ok(new MessageResponse
                {
                    success = true,
                    httpStatusCode = 200,
                    message = "Thêm mới bình luận thành công!",
                    data = result
                });
            }
            catch (BaseException ex)
            {
                return BadRequest(new MessageResponse
                {
                    success = false,
                    httpStatusCode = 400,
                    message = ex.Message
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new MessageResponse
                {
                    success = false,
                    httpStatusCode = 500,
                    message = "Đã xảy ra lỗi hệ thống."
                });
            }
        }

        #endregion
    }
}
