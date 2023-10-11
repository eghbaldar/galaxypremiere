using AutoMapper;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Users.Commands.PostUser;
using galaxypremiere.Application.Services.Users.Commands.UpdateUser;
using galaxypremiere.Domain.Entities.Users;
using galaxypremiere.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [ModelStateAttribute]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IRolesFacade _rolesFacade;
        private readonly IUserFacade _userFacade;
        private readonly IMapper _mapper;
        public UserController(
            IRolesFacade rolesFacade,
            IUserFacade userFacade,
            IMapper mapper
            )
        {
            _rolesFacade = rolesFacade;
            _userFacade = userFacade;
            _mapper = mapper;
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
            return Json(_userFacade.PostUserService.Execute(_mapper.Map<RequestPostUserServiceDto>(req)));
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
            return Json(_userFacade.UpdateUserService.Execute(_mapper.Map<RequestUpdateUserServiceDto>(req)));
        }
    }
}
