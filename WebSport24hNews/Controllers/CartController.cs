using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hCart;
using WebSport24hNews.Application.Command.Handlerr._24hCategories;
using WebSport24hNews.Application.Command.Modell._24hCart;
using WebSport24hNews.Application.Command.Modell._24hCategories;
using WebSport24hNews.Application.Query.Handler._24hCart;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class CartController : ApiController
    {
        public CartController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R

        [Route("create")]
        [HttpPost]
        [SwaggerOperation("Create giỏ hàng")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] AddToCartDto command)
        {
            var cartId = await Mediator.Send(new Create24hAddtoCartCommand()
            {
                addToCard = command
            });

            return Ok(new MessageResponse()
            {
                data = cartId,
                success = cartId > 0,
                message = cartId > 0 ? "Thêm vào giỏ hàng thành công!" : "Thêm vào giỏ hàng thất bại!"
            });
        }


        [Route("get-all-cart")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách giỏ hàng")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCart([FromQuery] decimal? userId, [FromQuery] string? sessionId)
        {
            if (userId == null && string.IsNullOrEmpty(sessionId))
                return BadRequest("Phải cung cấp userId hoặc sessionId.");

            var cart = await Mediator.Send(new GetCartQuery()
            {
                SessionId = sessionId,
                UserId = userId,
            });

            if (cart == null)
                return NotFound("Không tìm thấy giỏ hàng.");

            return Ok(cart);
        }
        #endregion
    }
}
