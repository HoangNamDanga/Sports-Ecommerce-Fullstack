using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hPlayers;
using WebSport24hNews.Application.Command.Handlerr._24hTeam;
using WebSport24hNews.Application.Command.Modell._24hPlayers;
using WebSport24hNews.Application.Command.Modell._24hTeam;
using WebSport24hNews.Application.Query.Handler._24hPlayers;
using WebSport24hNews.Application.Query.Handler._24hTeam;
using WebSport24hNews.Application.Query.Model._24hPlayers;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    //[Authorize(Policy = "AdminOnly")]
    [AllowAnonymous]
    public class PlayersController : ApiController
    {
        public PlayersController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R
        [Route("create")]
        [HttpGet]
        [SwaggerOperation("Lấy model tạo cầu thủ ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create()
        {
            return Ok(new MessageResponse()
            {
                success = true,
                data = new PlayersCommand()
            });
        }

        [Route("update")]
        [HttpGet]
        [SwaggerOperation("Lấy model cập nhật cầu thủ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetById24hPlayersQuery()
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
        [SwaggerOperation("Lấy chi tiết cầu thủ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetails([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetDetail24hPlayersQuery()
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
        [SwaggerOperation("Lấy danh sách cầu thủ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] GetList24hPlayersQuery request)
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

        [Route("get-top-goals-player")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách cầu thủ top ghi bàn !!!!")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetListPlayerGoalsToppp([FromQuery] decimal leagueId)
        {
            var data = await Mediator.Send(new GetTopPlayerGoald24hNewsQuery()
            {
                leagueId = leagueId
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
        #endregion

        #region CUD
        [Route("create")]
        [HttpPost]
        [SwaggerOperation("Create cầu thủ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] PlayersCommand command)
        {
            var data = await Mediator.Send(new Create24hPlayersCommand()
            {
                playersCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }

        [Route("update")]
        [HttpPost]
        [SwaggerOperation("Update cầu thủ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Update([FromBody] PlayersCommand command)
        {
            var data = await Mediator.Send(new Update24hPlayersCommand()
            {
                playersCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Chỉnh sửa thành công !" : "Chỉnh sửa thất bại !",
                success = data,
            });
        }

        [Route("delete")]
        [HttpPost]
        [SwaggerOperation("Delete cầu thủ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Delete([FromBody] IEnumerable<decimal?> Ids)
        {
            var data = await Mediator.Send(new Delete24hPlayersCommand()
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
