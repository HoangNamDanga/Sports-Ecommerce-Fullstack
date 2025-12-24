using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebSport24hNews.HoangNam.Core.Extensions;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Sercurity;

namespace WebSport24hNews.HoangNam.Service.Controller
{
    public class AuthorizeRoleV2Attribute : ActionFilterAttribute
    {
        private readonly string _listAccountPassRole;

        public AuthorizeRoleV2Attribute(string listAccountPassRole = "")
        {
            _listAccountPassRole = listAccountPassRole ?? string.Empty;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _ = Extension.Env;
            Endpoint endpoint = context.HttpContext.GetEndpoint();
            bool hasAllowAuth = false;
            if (endpoint != null)
            {
                ControllerActionDescriptor actionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                if (actionDescriptor != null)
                {
                    hasAllowAuth = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(AuthorizeAttribute), inherit: true).Any() || actionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(AuthorizeAttribute), inherit: true).Any();
                }
            }

            if (hasAllowAuth && context.HttpContext.User.Identity != null && !context.HttpContext.User.Identity.IsAuthenticated)
            {
                MessageResponse res3 = new MessageResponse
                {
                    message = "Bạn chưa xác thực người dùng !",
                    httpStatusCode = 401
                };
                context.Result = new UnauthorizedObjectResult(res3);
                context.HttpContext.Response.StatusCode = 401;
            }

            bool hasAllowAnonymous = false;
            if (endpoint != null)
            {
                ControllerActionDescriptor actionDescriptor2 = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
                if (actionDescriptor2 != null)
                {
                    hasAllowAnonymous = actionDescriptor2.MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), inherit: true).Any() || actionDescriptor2.ControllerTypeInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), inherit: true).Any();
                }
            }

            if (!hasAllowAnonymous && !hasAllowAuth)
            {
                IConfiguration _configuration = EngineContext.Current.Resolve<IConfiguration>(null, Array.Empty<Autofac.Core.Parameter>());
                if (_configuration == null)
                {
                    throw new BaseException("Hệ thống không thể xác định App | AppName is null !");
                }

                string _appName = _configuration["AppName"];
                if (_appName.IsNullOrEmpty())
                {
                    throw new BaseException("Hệ thống không thể xác định App | AppName is null !");
                }

                string controllerName = context.ActionDescriptor.RouteValues["controller"];
                string actionName = context.ActionDescriptor.RouteValues["action"];
                if (controllerName.IsNullOrEmpty() | actionName.IsNullOrEmpty())
                {
                    throw new BaseException("Hệ thống không thể xác định được Api !");
                }

                string _keyRole = _appName + ".Api." + controllerName + "." + actionName;
                bool checkRole = false;
                bool check2 = false;
                IUserInfomationService _userService = EngineContext.Current.Resolve<IUserInfomationService>(null, Array.Empty<Autofac.Core.Parameter>());
                if (context.HttpContext.User.Identity != null && !context.HttpContext.User.Identity.IsAuthenticated)
                {
                    check2 = true;
                }
                else
                {
                    IAuthorizeExtensionService iAuthenForMaster = EngineContext.Current.Resolve<IAuthorizeExtensionService>(null, Array.Empty<Autofac.Core.Parameter>());
                    string userId = iAuthenForMaster.ClaimType("id");
                    if (!_listAccountPassRole.IsNullOrEmpty() && _listAccountPassRole.Split(",").AnyList())
                    {
                        string[] listUserPass = _listAccountPassRole.Split(",");
                        string userName = iAuthenForMaster.UserName;
                        string check = listUserPass.FirstOrDefault((string x) => x == userName);
                        if (!check.IsNullOrEmpty())
                        {
                            checkRole = true;
                        }
                    }

                    if (!checkRole && _userService != null && !string.IsNullOrEmpty(userId))
                    {
                        checkRole = await _userService.GetAuthozireByUserId(userId, _keyRole);
                    }
                }

                if ((!checkRole && _userService == null) || (!checkRole && check2))
                {
                    MessageResponse res2 = new MessageResponse
                    {
                        message = "Bạn chưa xác thực người dùng !",
                        httpStatusCode = 401
                    };
                    context.Result = new UnauthorizedObjectResult(res2);
                    context.HttpContext.Response.StatusCode = 401;
                }
                else if (!checkRole)
                {
                    MessageResponse res = new MessageResponse
                    {
                        message = "Bạn chưa có quyền thực hiện thao tác này !",
                        httpStatusCode = 403
                    };
                    context.Result = new ObjectResult(res);
                    context.HttpContext.Response.StatusCode = 403;
                }
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}
