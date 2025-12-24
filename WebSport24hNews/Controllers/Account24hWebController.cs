using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr.Account;
using WebSport24hNews.Application.Command.Modell.Account;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class Account24hWebController : ApiController
    {
        public Account24hWebController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R
        [Route("create")]
        [HttpGet]
        [SwaggerOperation("Lấy model register đăng kí người tài khoản !")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create()
        {
            return Ok(new MessageResponse()
            {
                success = true,
                data = new RegisterUser24hCommand()
            });
        }


        #endregion

        #region CUD
        [Route("create")]
        [HttpPost]
        [SwaggerOperation("Tạo tài khoản !")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUser24hCommand command)
        {
            var data = await Mediator.Send(new RegisterUser24hCommandHandler()
            {
                registerUser24h = command
            });

            return Ok(new MessageResponse()
            {
                data = data != null ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = true
            });
        }



        [Route("logout")]
        [HttpPost]
        [SwaggerOperation("Đăng xuất !")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Logout([FromBody] LogoutUser24hCommand command)
        {
            var data = await Mediator.Send(command);

            return Ok(new MessageResponse()
            {
                data = data.Message,
                success = data.IsLoggedOut
            });
        }



        [Route("login")]
        [HttpPost]
        [SwaggerOperation("Đăng nhập Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Login([FromBody] LoginUser24h loginUser24h)
        {
            var data = await Mediator.Send(new LoginUser24hCommand
            {
                loginUser24h = loginUser24h
            });

            if (data is null)
            {
                return NotFound(new MessageResponse()
                {
                    message = "Đăng nhập thất bại !",
                    data = null,
                    success = false
                });
            }

            var result = new MessageResponse()
            {
                data = data,
                success = true
            };
            return Ok(result);
        }


        /// <summary>
        /// Làm mới Access Token từ Refresh Token
        /// </summary>
        [Route("refresh-token")]
        [HttpPost]
        [SwaggerOperation("Refresh-Token")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                return BadRequest(new MessageResponse
                {
                    success = false,
                    data = "Refresh token không hợp lệ !"
                });
            }

            var result = await Mediator.Send(new RefreshTokenCommand
            {
                refreshTokenRequest = request
            });

            return Ok(new MessageResponse
            {
                success = true,
                data = result
            });
        }
        #endregion
    }
}
