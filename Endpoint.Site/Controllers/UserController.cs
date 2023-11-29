using AutoMapper;
using Endpoint.Site.Models.Users.GetInformation;
using Endpoint.Site.Utilities;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Common.Constants;
using galaxypremiere.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Endpoint.Site.Controllers
{
    //[ModelStateAttribute]
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
        private readonly IUserInformationFacade _userInformationFacade;
        private readonly ICountiresFacade _countiresFacade;
        private readonly ILanguagesFacade _languagesFacade;
        private readonly IMapper _mapper;
        public UserController(
            IUserInformationFacade userInformationFacade,
            ICountiresFacade countiresFacade,
            ILanguagesFacade languagesFacade,
            IMapper mapper)
        {
            _userInformationFacade = userInformationFacade;
            _countiresFacade = countiresFacade;
            _languagesFacade = languagesFacade;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Me()
        {
            //// Get all user's information ...
            //// Get Countries List ...
            //// Get languages List ...
            long userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return View(new ModelGetInformation
            {
                getUsersInformationServiceDto = _userInformationFacade.GetUsersInformationServiceService.Execute(userId),
                resultGetCountriesServiceDto = _countiresFacade.GetCountriesService.Execute(),
                resultGetLanguagesServiceDto = _languagesFacade.GetLanguagesService.Execute(),
                getUsersInformationContactServiceDto = _userInformationFacade.GetUsersInformationContactService.Execute(userId),
            });
        }
        [HttpPost]
        public IActionResult MeAccount(RequestUpdateUsersInformationAccountDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userInformationFacade
                .UsersInformationAccountService
                .Execute(_mapper.Map<RequestUpdateUsersInformationAccountDto>(req)));
        }
        [HttpPost]
        public IActionResult MeContact(RequestUpdateUsersInformationContactServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userInformationFacade
                .UpdateUsersInformationContactService
                .Execute(_mapper.Map<RequestUpdateUsersInformationContactServiceDto>(req)));
        }
    }
}
