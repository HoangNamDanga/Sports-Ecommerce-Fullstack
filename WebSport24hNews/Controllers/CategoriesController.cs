using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebSport24hNews.Application.Command.Handlerr._24hCategories;
using WebSport24hNews.Application.Command.Handlerr._24hTeam;
using WebSport24hNews.Application.Command.Modell._24hCategories;
using WebSport24hNews.Application.Command.Modell._24hTeam;
using WebSport24hNews.Application.Query.Handler._24hCategories;
using WebSport24hNews.Application.Query.Handler._24hProduct;
using WebSport24hNews.Application.Query.Handler._24hTeam;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.Controllers
{
    //[Authorize(Policy = "AdminOnly")]
    [ApiController]
    [AllowAnonymous] // đc ưu tiên cao hơn, nếu xác thực ko dùng AllowAnonymous

    public class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        #region R
        [Route("create")]
        [HttpGet]
        [SwaggerOperation("Lấy model tạo thể loại danh mục")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create()
        {
            return Ok(new MessageResponse()
            {
                success = true,
                data = new CategoriesCommand()
            });
        }

        [Route("update")]
        [HttpGet]
        [SwaggerOperation("Lấy model cập nhật thể loại danh mục")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetById24hCategoriesQuery()
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
        [SwaggerOperation("Lấy chi tiết thể loại danh mục")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDetails([FromQuery] decimal id)
        {
            var data = await Mediator.Send(new GetDetail24hCategoriesQuery()
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
        [SwaggerOperation("Lấy danh sách thể loại danh mục")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] GetList24hCategoriesQuery request)
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


        [Route("get-all-category")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách danh mục")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetAll()
        {
            var data = await Mediator.Send(new GetAll24hCategoryQuery());
            var result = new MessageResponse()
            {
                data = data,
                success = data != null,
            };

            return Ok(result);
        }

        [Route("get-fixtures-and-result")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách thể loại danh mục or kết quả")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromQuery] decimal leagueId) // Nhận leagueId từ query string
        {
            // Tạo một instance của query với leagueId được truyền vào
            var query = new GetFixtures24hQueryCategory
            {
                leagueId = leagueId
            };

            // Gửi query đến Mediator
            var fixtures = await Mediator.Send(query);

            return Ok(fixtures);
        }


        [Route("get-lastest-by-category")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách thể loại danh mục mới nhất")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetLastestByCategory([FromQuery] decimal categoryId) // Nhận leagueId từ query string
        {
            // Tạo một instance của query với leagueId được truyền vào
            var query = new GetLastestArticlesByCategoryQuery
            {
                categoryId = categoryId
            };

            // Gửi query đến Mediator
            var fixtures = await Mediator.Send(query);

            return Ok(fixtures);
        }






        [AllowAnonymous]
        [Route("get-list-articles-by-category")]
        [HttpGet]
        [SwaggerOperation("Lấy danh sách loại bài viết")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetList([FromQuery] decimal categoryId)
        {
            var data = await Mediator.Send(new GetList24hByCategoryIdArticlesQuery()
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


        [AllowAnonymous]
        [Route("get-four-lastest-articles-by-category")]
        [HttpGet]
        [SwaggerOperation("Lấy 4 loại bài viết ")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetListFourArticles([FromQuery] decimal categoryId)
        {
            var data = await Mediator.Send(new GetFour24hArticlesCategoryQuery()
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
        #endregion

        #region CUD
        [Route("create")]
        [HttpPost]
        [SwaggerOperation("Create thể loại danh mục")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Create([FromBody] CategoriesCommand command)
        {
            var data = await Mediator.Send(new Create24hCategoriesCommand()
            {
                categoriesCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Thêm mới thành công !" : "Thêm mới thất bại !",
                success = data,
            });
        }

        [Route("update")]
        [HttpPost]
        [SwaggerOperation("Update thể loại danh mục")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Update([FromBody] CategoriesCommand command)
        {
            var data = await Mediator.Send(new Update24hCategoriesCommand()
            {
                categoriesCommand = command
            });
            return Ok(new MessageResponse()
            {
                data = data ? "Chỉnh sửa thành công !" : "Chỉnh sửa thất bại !",
                success = data,
            });
        }

        [Route("delete")]
        [HttpPost]
        [SwaggerOperation("Delete thể loại danh mục")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> Delete([FromBody] IEnumerable<decimal?> Ids)
        {
            var data = await Mediator.Send(new Delete24hCategoriesCommand()
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
