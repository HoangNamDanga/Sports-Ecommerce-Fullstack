using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hMatches;
using WebSport24hNews.Application.Command.Handlerr._24hTeam;
using WebSport24hNews.Application.Command.Modell._24hMatches;
using WebSport24hNews.Application.Command.Modell._24hTeam;
using WebSport24hNews.Application.Query.Handler._24hMatches;
using WebSport24hNews.Application.Query.Handler._24hTeam;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    [AllowAnonymous]
    //[Authorize(Policy = "AdminOnly")]
    public class MatchesController : ApiController
    {
        public MatchesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
            //khi tạo đc 1 phát thì F5 lại nó lại thế này
        }

        #region R
        [Route("create")]
        [HttpGet]
        [SwaggerOperation("Lấy model tạo trận đấu ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create()
        {
            return Ok(new MessageResponse()
            {
                success = true,
                data = new MatchesCommand()
            });
        }

        [Route("update")]
        [HttpGet]
        [SwaggerOperation("Lấy model cập nhật trận đấu")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetById24hMatchesQuery()
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
        [SwaggerOperation("Lấy chi tiết trận đấu")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetails([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetDetail24hMatchesQuery()
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
        [SwaggerOperation("Lấy danh sách trận đấu")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] GetList24hMatchesQuery request)
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




        [Route("get-list-result-football")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách kết quả bóng đá")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetListResultFootball()
        {
            var data = await Mediator.Send(new GetResultFootball24hMatchesQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }



        [Route("get-match-detail")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách kết quả bóng đá")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetListMatchDetailsl(decimal leagueId)
        {
            var data = await Mediator.Send(new GetMatchDetailByLeagueIdQuery()
            {
                LeagueId = leagueId
            });
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }




        [Route("get-list-fixture-football")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách lịch thi đấu bóng đá")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetListFixtureFootball()
        {
            var data = await Mediator.Send(new GetFixtureMatchesQuery());
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
        [SwaggerOperation("Create trận đấu")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] MatchesCommand command)
        {
            var data = await Mediator.Send(new Create24hMatchesCommand()
            {
                matchesCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }

        [Route("update")]
        [HttpPost]
        [SwaggerOperation("Update trận đấu")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Update([FromBody] MatchesCommand command)
        {
            var data = await Mediator.Send(new Update24hMatchesCommand()
            {
                matchesCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Chỉnh sửa thành công !" : "Chỉnh sửa thất bại !",
                success = data,
            });
        }

        [Route("delete")]
        [HttpPost]
        [SwaggerOperation("Delete trận đấu")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Delete([FromBody] IEnumerable<decimal?> Ids)
        {
            var data = await Mediator.Send(new Delete24hMatchesCommand()
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
