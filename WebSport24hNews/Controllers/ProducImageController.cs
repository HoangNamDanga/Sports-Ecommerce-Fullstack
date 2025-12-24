using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hImage;
using WebSport24hNews.Application.Command.Handlerr._24hPlayers;
using WebSport24hNews.Application.Command.Handlerr._24hProductImage;
using WebSport24hNews.Application.Command.Modell._24hPlayers;
using WebSport24hNews.Application.Command.Modell._24hProduct;
using WebSport24hNews.Application.Query.Handler._24hPlayers;
using WebSport24hNews.Application.Query.Handler._24hProductImage;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [AllowAnonymous]
    public class ProducImageController : ApiController
    {
        public ProducImageController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R
        [Route("create")]
        [HttpGet]
        [SwaggerOperation("Lấy model tạo sản phẩm hình ảnh ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create()
        {
            return Ok(new MessageResponse()
            {
                success = true,
                data = new DhnProductImageCommand()
            });
        }

        [Route("update")]
        [HttpGet]
        [SwaggerOperation("Lấy model cập nhật sản phẩm hình ảnh")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetById24hProductImageQuery()
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
        [SwaggerOperation("Lấy chi tiết sản phẩm hình ảnh")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetails([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetDetail24hProductImageQuery()
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
        [SwaggerOperation("Lấy danh sách sản phẩm hình ảnh")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] GetList24hProductImageQuery request)
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

        [Route("up-img-prd")]
        [HttpPost]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(10 * 1024 * 1024)] // Giới hạn 10MB
        [SwaggerOperation(Summary = "Upload ảnh sản phẩm", Description = "Upload 1 ảnh kèm thông tin sản phẩm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> UpdloadImageProduct([FromForm] UploadProductImageDTO request)
        {
            Console.WriteLine("Gọi chưa !!!!");
            var id = await Mediator.Send(new UploadProductImageCommand()
            {
                dto = request
            });
            return Ok(new { ImageId = id, Message = "Upload thành công" });

        }


        #endregion

        #region CUD

        //hàm này ko sử dụng
        [Route("create")]
        [HttpPost]
        [SwaggerOperation("Create sản phẩm hình ảnh")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] DhnProductImageCommand command)
        {
            var data = await Mediator.Send(new Create24hProductImageCommand()
            {
                dhnProductImageCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }

        [Route("update")]
        [HttpPost]
        [SwaggerOperation("Update sản phẩm hình ảnh")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Update([FromForm] UploadProductImageDTO command)
        {
            var data = await Mediator.Send(new Update24hProductImageCommand()
            {
                dto = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Chỉnh sửa thành công !" : "Chỉnh sửa thất bại !",
                success = data,
            });
        }

        [Route("delete")]
        [HttpPost]
        [SwaggerOperation("Delete sản phẩm hình ảnh")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Delete([FromBody] IEnumerable<decimal?> Ids)
        {
            var data = await Mediator.Send(new Delete24hProductImageCommand()
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
