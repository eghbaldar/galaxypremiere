using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Site.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index(string username)
        {
            return View();
        }   
    }
}
