using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Me()
        {
            return View();
        }
    }
}
