using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Query.Handler._24hRelatedArticles;
using WebSport24hNews.Application.Query.Handler.PremierLeagueStanding;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    //[Authorize(Policy = "AdminOnly")]
    [AllowAnonymous]
    public class PremierLeagueStandingController : ApiController
    {
        public PremierLeagueStandingController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }


        #region R
        [Route("get-list")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách bảng xếp hạng ngoại hạng Anh")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetListNHA([FromQuery] decimal leagueId)
        {
            var data = await Mediator.Send(new GetPremierLeagueStandingQuery()
            {
                LeagueId = leagueId   // 👈 Gán từ query vào request
            });

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
