﻿using AutoMapper;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UserLoginLog.Queries.GetUsersLoginLogs;
using galaxypremiere.Application.Services.Users.Commands.ActivateUser;
using galaxypremiere.Application.Services.Users.Commands.DeleteUser;
using galaxypremiere.Application.Services.Users.Commands.PostUser;
using galaxypremiere.Application.Services.Users.Commands.UpdateUser;
using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Entities.Users;
using galaxypremiere.Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [ModelStateAttribute]
    [Area("Admin")]
    [Authorize(RoleConstants.King)]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRolesFacade _rolesFacade;
        private readonly IUserFacade _userFacade;
        private readonly IUserLoginLogFacade _userLoginLogFacade;
        public UserController(
            IRolesFacade rolesFacade,
            IUserFacade userFacade,
            IMapper mapper,
            IUserLoginLogFacade userLoginLogFacade
            )
        {
            _rolesFacade = rolesFacade;
            _userFacade = userFacade;
            _mapper = mapper;
            _userLoginLogFacade = userLoginLogFacade;
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
        public IActionResult Index(int p)
        {
            var roles = new SelectList(_rolesFacade.GetRolesService.Execute(), "Id", "Name");
            ViewBag.Roles = roles;
            return View(_userFacade.GetUsersService.Execute(new galaxypremiere.Application.Services.Users.Queries.GetUsers.RequestGetUserServiceDto
            {
                CurrentPage = p,
            }));
        }
        [HttpPost]
        public IActionResult Update(RequestUpdateUserServiceDto req)
        {
            return Json(_userFacade.UpdateUserService.Execute(_mapper.Map<RequestUpdateUserServiceDto>(req)));
        }
        [HttpPost]
        public IActionResult Delete(RequestDeleteUserServiceDto req)
        {
            return Json(_userFacade.DeleteUserService.Execute(req));
        }
        [HttpPost]
        public IActionResult Activate(RequestActiviateUserServiceDto req)
        {
            return Json(_userFacade.ActiviateUserService.Execute(req));
        }
        [HttpGet]
        public IActionResult LoginLogs(RequestGetUsersLoginLogsServiceDto req, int p)
        {
            string userId = RouteData.Values["id"].ToString();
            return View(_userLoginLogFacade.GetUsersLoginLogsService.Execute(new RequestGetUsersLoginLogsServiceDto
            {
                UsersId = int.Parse(userId),
                Page = p,
            }));
        }
        [HttpGet]
        public IActionResult Information()
        {
            return View();
        }
    }
}
