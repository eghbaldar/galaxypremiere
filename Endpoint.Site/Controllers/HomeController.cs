using Endpoint.Site.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Endpoint.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Films()
        {
            return View();
        }

        public async Task Login()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var loginInfo = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //var claims = result.Principal.Identities
            //    .FirstOrDefault().Claims.Select(claim => new
            //    {
            //        claim.Issuer,
            //        claim.OriginalIssuer,
            //        claim.Type,
            //        claim.Value
            //    });
            //return Json(claims);
            string email = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value;
            string firstname = loginInfo.Principal.FindFirst(ClaimTypes.GivenName)?.Value?? null;
            string lastname = loginInfo.Principal.FindFirst(ClaimTypes.Surname)?.Value?? null;

            return View();
        }
    }
}