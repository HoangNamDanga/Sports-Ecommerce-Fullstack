using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hPlayers;
using WebSport24hNews.Application.Command.Handlerr._24hProduct;
using WebSport24hNews.Application.Command.Modell._24hPlayers;
using WebSport24hNews.Application.Command.Modell._24hProduct;
using WebSport24hNews.Application.Query.Handler._24hMatches;
using WebSport24hNews.Application.Query.Handler._24hPlayers;
using WebSport24hNews.Application.Query.Handler._24hProduct;
using WebSport24hNews.Application.Query.Handler.DhnProducts;
using WebSport24hNews.Application.Query.Model._24hProductVariant;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    //[Authorize(Policy = "AdminOnly")]
    [AllowAnonymous]
    public class ProductController : ApiController
    {
        public ProductController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R

        [Route("get-list-seller")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách sản phẩm bán chạy")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList()
        {
            var data = await Mediator.Send(new GetListBestSellerProductQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }

        [Route("get-all-product")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách tất cả sản phẩm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetAll()
        {
            var data = await Mediator.Send(new GetAll24hProductQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }



        [Route("create")]
        [HttpGet]
        [SwaggerOperation("Lấy model sản phẩm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create()
        {
            return Ok(new MessageResponse()
            {
                success = true,
                data = new DhnProductCommand()
            });
        }

        [Route("update")]
        [HttpGet]
        [SwaggerOperation("Lấy model cập nhật sản phẩm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetById24hProductQuery()
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
        [SwaggerOperation("Lấy chi tiết sản phẩm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetails([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetDetail24hProductQuery()
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


        [Route("detail-by-productId")]
        [HttpGet]
        [SwaggerOperation("Lấy chi tiết sản phẩm & biến thể")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<DhnProductDto>> GetProductDetails(decimal productId)
        {
            if (productId <= 0)
            {
                return BadRequest("Product ID không hợp lệ."); // Trả về 400 Bad Request
            }
            var query = await Mediator.Send(new GetDetailProductByIdQuery { ProductId = productId });

            var result = new MessageResponse()
            {
                data = query,
                success = true,
            };
            return Ok(result);
        }


        [Route("get-list")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách sản phẩm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] GetList24hProductQuery request)
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

        #endregion

        #region CUD

        [Route("create")]
        [HttpPost]
        [SwaggerOperation("Create sản phẩm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] DhnProductCommand command)
        {
            var data = await Mediator.Send(new Create24hProductCommand()
            {
                dhnProductCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }


        [Route("update")]
        [HttpPost]
        [SwaggerOperation("Update sản phẩm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Update([FromBody] DhnProductCommand command)
        {
            var data = await Mediator.Send(new Update24hProductCommand()
            {
                dhnProductCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Chỉnh sửa thành công !" : "Chỉnh sửa thất bại !",
                success = data,
            });
        }

        [Route("delete")]
        [HttpPost]
        [SwaggerOperation("Delete sản phẩm")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Delete([FromBody] IEnumerable<decimal?> Ids)
        {
            var data = await Mediator.Send(new Delete24hProductCommand()
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
