using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Users.FacadePattern;
using galaxypremiere.Application.Services.Users.Queries.AuthUsers;
using galaxypremiere.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [ModelStateAttribute]
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IUserFacade _userFacade;
        public AuthController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }
        [HttpGet]
        public IActionResult Login()
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
                    HttpContext.SignInAsync(principal, propertise);
                }
            }
            return Json(login);
        }
    }
}
