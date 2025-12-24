using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Query.Handler._24hProduct;
using WebSport24hNews.Application.Query.Handler._24hProductVariant;
using WebSport24hNews.Application.Query.Handler.DhnProducts;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    //[Authorize(Policy = "AdminOnly")]
    [AllowAnonymous]
    public class ProductVariantController : ApiController
    {
        public ProductVariantController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R

        [Route("get-prd-clb")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách Áo Câu Lạc Bộ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetProductVariant()
        {
            var data = await Mediator.Send(new GetListProductCLBHomeQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }

        [Route("get-prd-national-team")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách Áo đội tuyển quốc gia")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetProductNationalTeam()
        {
            var data = await Mediator.Send(new GetListProductHomeNationalTeamQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }

        [Route("get-prd-training")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách Áo training")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetProductTraining()
        {
            var data = await Mediator.Send(new GetListProductTrainingHomeQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }


        [Route("get-prd-shoes-soccer")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách Giày bóng đá")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetProductShoes()
        {
            var data = await Mediator.Send(new GetListProductShoesSoccerHomeQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }


        [Route("get-prd-accessory")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách Phụ kiện")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetProductAccessory()
        {
            var data = await Mediator.Send(new GetListProductAccessoryHomeQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }


        [Route("get-list-product-by-category")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách sản phẩm theo danh mục ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetProductByCategory([FromQuery] decimal categoryId)
        {
            var data = await Mediator.Send(new GetListProductByCategoryIdQuery()
            {
                categoryId = categoryId
            });
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }



        [Route("get-prd-volleyball-equipment")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách Phụ kiện")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetProductVolleyballEquiment()
        {
            var data = await Mediator.Send(new GetListVolleyballEquipmentHomeQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }

        #endregion
    }
}
