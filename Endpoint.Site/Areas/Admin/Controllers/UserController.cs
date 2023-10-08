using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Users.Commands.PostUser;
using galaxypremiere.Application.Services.Users.Commands.UpdateUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IRolesFacade _rolesFacade;
        private readonly IUserFacade _userFacade;
        public UserController(IRolesFacade rolesFacade, IUserFacade userFacade)
        {
            _rolesFacade = rolesFacade;
            _userFacade = userFacade;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var roles = new SelectList(_rolesFacade.GetRolesService.Execute(), "Id", "Name");
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public IActionResult Create(RequestPostUserServiceDto req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Json(_userFacade.PostUserService.Execute(new RequestPostUserServiceDto
                {
                    Fullname = req.Fullname,
                    Email = req.Email,
                    Password = req.Password,
                    IdRole = req.IdRole,
                }));
            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            var roles = new SelectList(_rolesFacade.GetRolesService.Execute(), "Id", "Name");
            ViewBag.Roles = roles;
            return View(_userFacade.GetUsersService.Execute());
        }
        [HttpPost]
        public IActionResult Update(RequestUpdateUserServiceDto req)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Json(_userFacade.UpdateUserService.Execute(new RequestUpdateUserServiceDto
            {
                IdUser=req.IdUser,
                Fullname = req.Fullname,
                Email = req.Email,
                Password = req.Password,
                IdRole = req.IdRole,
            }));
        }       
    }
}
