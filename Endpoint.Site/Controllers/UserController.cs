using AutoMapper;
using Endpoint.Site.Models.Users.GetInformation;
using Endpoint.Site.Utilities;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationAccountType;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeadshot;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPassword;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPrivacy;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetCheckDuplicatedUsername;
using galaxypremiere.Common;
using galaxypremiere.Common.Constants;
using galaxypremiere.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Claims;
using System.Xml.Linq;

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
        [HttpPost]
        public IActionResult MePrivacy(RequestUpdateUsersInformationPrivcayServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userInformationFacade
                .UpdateUsersInformationPrivacyService
                .Execute(req));
        }
        [HttpPost]
        public IActionResult MeUsername(RequestUpdateUsersInformationUsernameServiceDto req)
        {
            req.userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userInformationFacade
                .UpdateUsersInformationUsernameService
                .Execute(req));
        }
        [HttpPost]
        public IActionResult MeUsernameRuntime(RequestGetCheckDuplicatedUsernameDto req)
        {
            return Json(_userInformationFacade
                .GetCheckDuplicatedUsernameService
                .Execute(req));
        }
        [HttpPost]
        public IActionResult MePassword(RequestUpdateUsersInformationPasswordDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userInformationFacade
                .UpdateUsersInformationPasswordService
                .Execute(req));
        }
        [HttpPost]
        public IActionResult MeAccountType(RequestUpdateUsersInformationAccountTypeServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userInformationFacade
                .UpdateUsersInformationAccountTypeService
                .Execute(req));
        }
        [HttpPost]
        public IActionResult MeBIO(RequestUpdateUsersInformationBioServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userInformationFacade
                .UpdateUsersInformationBioService
                .Execute(req));
        }
        [HttpPost]
        public IActionResult MeHeadshot(RequestUpdateUsersInformationHeadshotServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            req.Photo = Request.Form.Files[0];
            return Json(_userInformationFacade
                .UpdateUsersInformationHeadshotService
                .Execute(req));
        }
    }
}