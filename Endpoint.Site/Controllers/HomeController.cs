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
using galaxypremiere.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Endpoint.Site.Views.Shared.Components;
using galaxypremiere.Domain.Entities.Users;
using Endpoint.Site.Utilities;

namespace Endpoint.Site.Controllers
{
    //[ModelStateAttribute]
    public class HomeController : Controller
    {
        private readonly IUserFacade _userFacade;
        private readonly IUserLoginLogFacade _userLoginLogFacade;
        private readonly IUserInformationFacade _userInformationFacade;

        public HomeController(
            IUserFacade userFacade,
            IUserLoginLogFacade userLoginLogFacade,
            IUserInformationFacade userInformationFacade)
        {
            _userFacade = userFacade;
            _userLoginLogFacade = userLoginLogFacade;
            _userInformationFacade = userInformationFacade;
        }
        [HttpGet]
        public IActionResult Index(string ReturnUrl)
        {
            if (!String.IsNullOrWhiteSpace(ReturnUrl)) return Redirect(Url.Content("~/?login=true"));
            return View();
        }
        public IActionResult Films()
        {
            return View();
        }
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
                        new Claim(ClaimTypes.Name,login.Data.Nickname),
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
                    // Set Static Values
                    GeneralConstants.UserId = login.Data.IdUser;
                    GeneralConstants.Fullname = login.Data.Nickname;
                    var retrieve = _userInformationFacade.GetUsersInformationServiceService.Execute
                       (new galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation.RequestGetUsersInformationServiceDto
                       {
                           UsersId = login.Data.IdUser,
                       });
                    if (retrieve != null)
                    {
                        GeneralConstants.Username = retrieve.Username;
                        if (string.IsNullOrEmpty(retrieve.Photo))
                            GeneralConstants.PrivateHeadshot = GeneralConstants.PublicHeadshot;
                        else
                            GeneralConstants.PrivateHeadshot = $"/SiteTemplate/innerpages/images/user-headshot/{retrieve.Photo}-thumb.jpg";
                    }
                    HttpContext.SignInAsync(principal, propertise);
                }
            }
            return Json(login);
        }
        public IActionResult Logout()

        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            GeneralConstants.PrivateHeadshot = GeneralConstants.PublicHeadshot;
            GeneralConstants.Username = null;
            GeneralConstants.Fullname = null;
            GeneralConstants.UserId = 0;
            string currentUrl = Request.Headers["Referer"].ToString(); // Get the current URL
            return Redirect(currentUrl);
        }

    }
}