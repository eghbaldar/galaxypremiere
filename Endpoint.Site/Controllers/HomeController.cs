using Endpoint.Site.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using AspNet.Security.OAuth.Instagram;
using Microsoft.AspNetCore.Http;
using galaxypremiere.Infrastructure.Filters;
using galaxypremiere.Application.Services.Users.Queries.AuthUsers;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UserLoginLog.Commands.PostUserLoginLog;

namespace Endpoint.Site.Controllers
{
    //[ModelStateAttribute]
    public class HomeController : Controller
    {
        private readonly IUserFacade _userFacade;
        private readonly IUserLoginLogFacade _userLoginLogFacade;
        public HomeController(
            IUserFacade userFacade,
            IUserLoginLogFacade userLoginLogFacade)
        {
            _userFacade = userFacade;
            _userLoginLogFacade = userLoginLogFacade;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Films()
        {
            return View();
        }
        //public async Task Login(string returnUrl)
        //{
        //    await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
        //    {
        //        RedirectUri = Url.Action("GoogleResponse")
        //    });
        //}
        //public async Task<IActionResult> GoogleResponse(string returnUrl)
        //{
        //    var loginInfo = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    string email = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value;
        //    string firstname = loginInfo.Principal.FindFirst(ClaimTypes.GivenName)?.Value?? null;
        //    string lastname = loginInfo.Principal.FindFirst(ClaimTypes.Surname)?.Value?? null;

        //    if(Url.IsLocalUrl(returnUrl)) { 
        //        //
        //    }

        //    return View();
        //}
        [HttpPost]
        public IActionResult Login(RequestAuthLoginUsersServiceDto req)
        {
            var login = _userFacade.AuthLoginUsersService.Execute(req);
            if (login != null)
            {
                if (login.IsSuccess)
                {
                    var claims = new List<Claim>() {
                        new Claim(ClaimTypes.NameIdentifier,login.Data.IdUser.ToString()),
                        new Claim(ClaimTypes.Email,req.Email),
                        new Claim(ClaimTypes.Name,login.Data.Fullname),
                        new Claim(ClaimTypes.Role,login.Data.Role),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var propertise = new AuthenticationProperties()
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddYears(1),
                    };
                    _userLoginLogFacade.PostUserLoginLogService.Execute(new RequestPostUserLoginLogServiceDto
                    {
                        UsersId = login.Data.IdUser,
                        IP = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    });
                    HttpContext.SignInAsync(principal, propertise);
                }
            }
            return Json(login);
        }

    }
}