using AutoMapper;
using Endpoint.Site.Utilities;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Common.Constants;
using galaxypremiere.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Endpoint.Site.Controllers
{
    [ModelStateAttribute]
    [Authorize(
        AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme + "," + "user",
        Roles =
        nameof(RoleConstants.King)
        + "," +
        nameof(RoleConstants.SuperAdmin)
          + "," +
        nameof(RoleConstants.Admin)
          + "," +
        nameof(RoleConstants.Client)
             + "," +
        nameof(RoleConstants.User)
        )]
    public class UserController : Controller
    {
        private readonly IUserInformation _userInformation;
        private readonly IMapper _mapper;
        public UserController(IUserInformation userInformation,IMapper mapper)
        {
            _userInformation = userInformation;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Me()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Me(RequestUpdateUsersInformationAccountDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userInformation
                .UsersInformationAccountService
                .Execute(_mapper.Map<RequestUpdateUsersInformationAccountDto>(req)));
        }
    }
}
