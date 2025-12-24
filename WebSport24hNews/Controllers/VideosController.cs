using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hArticlesComment;
using WebSport24hNews.Application.Command.Handlerr._24hTeam;
using WebSport24hNews.Application.Command.Handlerr._24hVideos;
using WebSport24hNews.Application.Command.Modell._24hArticlesComment;
using WebSport24hNews.Application.Command.Modell._24hTeam;
using WebSport24hNews.Application.Command.Modell._24hVideos;
using WebSport24hNews.Application.Query.Handler._24hArticlesComment;
using WebSport24hNews.Application.Query.Handler._24hTeam;
using WebSport24hNews.Application.Query.Handler._24hVideoComment;
using WebSport24hNews.Application.Query.Handler._24hVideos;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    [AllowAnonymous]
    //[Authorize(Policy = "AdminOnly")]
    public class VideosController : ApiController
    {
        public VideosController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R
        [Route("create")]
        [HttpGet]
        [SwaggerOperation("Lấy model tạo Video")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create()
        {
            return Ok(new MessageResponse()
            {
                success = true,
                data = new VideosCommand()
            });
        }

        [Route("update")]
        [HttpGet]
        [SwaggerOperation("Lấy model cập nhật Videos")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetById24hVideosQuery()
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
        [SwaggerOperation("Lấy chi tiết Video")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetails([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetDetail24hVideosQuery()
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
        [SwaggerOperation("Lấy chi tiết video")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Gétlug([FromQuery] string slug)
        {
            var data = await Mediator.Send(new GetBySlugVideoCommentQuery()
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


        [Route("detail-video-comment")]
        [HttpGet]
        [SwaggerOperation("Lấy chi tiết video commentt")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetailsVideoComment([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetByIdVideoCommentQuery()
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
        [SwaggerOperation("Lấy danh sách Video")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] GetList24hVideosQuery request)
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


        [Route("get-four-video")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách 4 Video mới nhất")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetListFourVideo()
        {
            var data = await Mediator.Send(new GetFour24hVideosQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null
            };

            return Ok(result);
        }

        [Route("get-lastets-video")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách Videos mới nhất")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetListLastetsVideo()
        {
            var data = await Mediator.Send(new GetList24hLastestVideoQuery());
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
        [SwaggerOperation("Create Video")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] VideosCommand command)
        {
            var data = await Mediator.Send(new Create24hVideosCommand()
            {
                videosCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }


        [Route("create-video-youtube")]
        [HttpPost]
        [SwaggerOperation("Create Video")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> CreateVideoYoutube([FromBody] CreateVideoCommand command)
        {
            var data = await Mediator.Send(new Create24hVideoCommandAdmin()
            {
                videoCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data > 0 ? "Thêm mới thành công!" : "Thêm mới thất bại!",
                success = data > 0,
            });
        }



        [Route("update")]
        [HttpPost]
        [SwaggerOperation("Update Video")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Update([FromBody] UpdateVideoRequest command)
        {
            var result = await Mediator.Send(new Update24hVideosCommand
            {
                videosCommand = command
            });

            if (result)
                return Ok(new MessageResponse { data = "Chỉnh sửa thành công !", success = true });
            else
                return BadRequest(new MessageResponse { data = "Chỉnh sửa thất bại !", success = false });
        }

        [Route("delete")]
        [HttpPost]
        [SwaggerOperation("Delete Video")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Delete([FromBody] IEnumerable<decimal?> Ids)
        {
            var data = await Mediator.Send(new Delete24hVideosCommand()
            {
                Ids = Ids
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Xóa thành công !" : "Xóa thất bại !",
                success = data,
            });
        }



        [Route("create-comment")]
        [HttpPost]
        [SwaggerOperation("Create comment (Bình luận)")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateComment([FromBody] CommentCommandVideoModel model, CancellationToken cancellationToken)
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

            var command = new Create24hVideoCommentCommand
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
