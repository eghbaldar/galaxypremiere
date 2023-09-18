using galaxypremiere.Application.Interfaces.FacadePattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IRolesFacade _rolesFacade;
        public UserController(IRolesFacade rolesFacade)
        {
            _rolesFacade = rolesFacade;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roles = new SelectList(_rolesFacade.GetRolesService.Execute(),"Id", "Name");
            ViewBag.Roles = roles;
            return View();
        }
    }
}
