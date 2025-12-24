using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Query.Handler._24hProductVariant;
using WebSport24hNews.Application.Query.Handler._24hStores;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    //[Authorize(Policy = "AdminOnly")]
    [AllowAnonymous]
    public class StoresController : ApiController
    {
        public StoresController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R

        [Route("get-location-stores")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách các cửa hàng theo khu vực / thành phố")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetStores()
        {
            var data = await Mediator.Send(new GetAllStoresHomeQuery());
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
