using galaxypremiere.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(RoleConstants.King)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
