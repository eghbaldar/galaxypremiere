using AutoMapper;
using Endpoint.Site.Models.Users.GetInformation;
using Endpoint.Site.Models.Users.GetProfile;
using Endpoint.Site.Utilities;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UserPosition.Commands.PostUsersPositionSuggestion;
using galaxypremiere.Application.Services.UserPosition.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationAccountType;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeader;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeadshot;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationOther;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPassword;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPrivacy;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetCheckDuplicatedUsername;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.FacadePattern;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileFavoriteMovies;
using galaxypremiere.Common;
using galaxypremiere.Common.Constants;
using galaxypremiere.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Claims;
using System.Text.RegularExpressions;
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
        private readonly IUserPositionFacade _PositionFacade;
        private readonly IUserProfileFacade _userProfileFacade;
        private readonly IMapper _mapper;
        public UserController(
            IUserInformationFacade userInformationFacade,
            ICountiresFacade countiresFacade,
            ILanguagesFacade languagesFacade,
            IUserPositionFacade positionFacade,
            IUserProfileFacade userProfileFacade,
            IMapper mapper)
        {
            _userInformationFacade = userInformationFacade;
            _countiresFacade = countiresFacade;
            _languagesFacade = languagesFacade;
            _PositionFacade = positionFacade;
            _userProfileFacade= userProfileFacade;
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
        [HttpPost]
        public IActionResult MeHeader(RequestUpdateUsersInformationHeaderServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            req.Header = Request.Form.Files[0];
            return Json(_userInformationFacade
                .UpdateUsersInformationHeaderService
                .Execute(req));
        }
        [HttpGet]
        public IActionResult Positions()
        {
            return Json(_PositionFacade.GetUsersPositionsService.Execute());
        }
        [HttpPost]
        public IActionResult MePositions(RequestPostUsersPositionSuggestionServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_PositionFacade.PostUsersPositionSuggestionService.Execute(req));
        }
        [HttpPost]
        public IActionResult MeOther(RequestUpdateUsersInformationOtherServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userInformationFacade.UpdateUsersInformationOtherService.Execute(req));
        }
        [HttpGet]
        public IActionResult Profile()
        {
            var userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);

            ModelGetProfile modelGetProfile = new ModelGetProfile
            {
                ResultGetUserProfileEducationsServiceDto =_userProfileFacade.GetUserProfileEducationsService
                .Execute(new RequestGetUserProfileEducationsServiceDto
                {
                    UsersId = userId
                }).Data,
                ResultGetUserProfileFavoriteMoviesServiceDto=_userProfileFacade.GetUserProfileFavoriteMoviesService
                .Execute(new RequestGetUserProfileFavoriteMoviesServiceDto
                {
                    UsersId = userId
                }).Data,
            };
            return View(modelGetProfile);
        }      
        [HttpPost]
        public IActionResult ProfileEducationPost(RequestPostUserProfileEducationServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.PostUserProfileEducationService.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileEducationDelete(RequestDeleteUserProfileEducationServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.DeleteUserProfileEducationService.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileFavoriteMovies(RequestPostUserProfileFavoriteMoviesServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.PostUserProfileFavoriteMoviesService.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileFavoriteMovieDelete(RequestDeleteUserProfileFavoriteMoviesServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.DeleteUserProfileFavoriteMoviesService.Execute(req));
        }        
        [HttpGet]
        public IActionResult GetMetaInfo(string link)
        {

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(link);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            return Json(result);
        }
    }
}