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
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileNews;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileNews;
using galaxypremiere.Application.Services.UsersProfile.FacadePattern;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileLinks;
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
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileLinks;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileLinks;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileAttachments;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileAttachments;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileAttachments;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosAlbum;
using Endpoint.Site.Models.Users.GetPhoto;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum;
using Microsoft.Extensions.Configuration.UserSecrets;
using galaxypremiere.Domain.Entities.Users;
using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotosAlbum;

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
        private readonly IMetagsFacade _metagsFacade;
        private readonly IUserPhotoFacade _userPhotoFacade;
        private readonly IMapper _mapper;
        public UserController(
            IUserInformationFacade userInformationFacade,
            ICountiresFacade countiresFacade,
            ILanguagesFacade languagesFacade,
            IUserPositionFacade positionFacade,
            IUserProfileFacade userProfileFacade,
            IMetagsFacade metagsFacade,
            IUserPhotoFacade userPhotoFacade,
        IMapper mapper)
        {
            _userInformationFacade = userInformationFacade;
            _countiresFacade = countiresFacade;
            _languagesFacade = languagesFacade;
            _PositionFacade = positionFacade;
            _userProfileFacade = userProfileFacade;
            _metagsFacade = metagsFacade;
            _mapper = mapper;
            _userPhotoFacade = userPhotoFacade;
        }
        /// <summary>
        /// //////////////////////////////////////////// Me
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// //////////////////////////////////////////// Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Profile()
        {
            var userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);

            ModelGetProfile modelGetProfile = new ModelGetProfile
            {
                ResultGetUserProfileEducationsServiceDto = _userProfileFacade.GetUserProfileEducationsService
                .Execute(new RequestGetUserProfileEducationsServiceDto
                {
                    UsersId = userId
                }).Data,
                ResultGetUserProfileFavoriteMoviesServiceDto = _userProfileFacade.GetUserProfileFavoriteMoviesService
                .Execute(new RequestGetUserProfileFavoriteMoviesServiceDto
                {
                    UsersId = userId
                }).Data,
                ResultGetUserProfileCompaniesServiceDto = _userProfileFacade.GetUserProfileCompaniesService
                .Execute(new RequestGetUserProfileCompaniesDto
                {
                    UsersId = userId
                }).Data,
                ResultGetUserProfileNewsServiceDto = _userProfileFacade.GetUserProfileNewsService
                .Execute(new RequestGetUserProfileNewsDto
                {
                    UsersId = userId
                }).Data,
                ResultGetUserProfileLinksServiceDto = _userProfileFacade.GetUserProfileLinksService
                .Execute(new RequestGetUserProfileLinksDto
                {
                    UsersId = userId
                }).Data,
                ResultGetUserProfileAttachmentsServiceDto=_userProfileFacade.GetUserProfileAttachmentsService
                .Execute(new RequestGetUserProfileAttachmentsServiceDto
                {
                    UsersId = userId
                }).Data,
                resultGetCountriesServiceDto = _countiresFacade.GetCountriesService.Execute(),
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
            return Json(_metagsFacade.GetMetagsInfoByLinkService.Execute(link, "https://www.imdb.com/"));
        }
        [HttpPost]
        public IActionResult ProfileCompanyPost(RequestPostUserProfileCompaniesServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.PostUserProfileCompaniesService.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileCompanyDelete(RequestDeleteUserProfileCompaniesServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.DeleteUserProfileCompanies.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileNewsPost(RequestPostUserProfileNewsServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.PostUserProfileNewsService.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileNewsDelete(RequestDeleteUserProfileNewsServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.DeleteUserProfileNewsService.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileLinksDelete(RequestDeleteUserProfileLinksServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.DeleteUserProfileLinksService.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileLinksPost(RequestPostUserProfileLinkServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.PostUserProfileLinksService.Execute(req));
        }
        [HttpPost]
        public IActionResult PostProfileAttachments(string Title)
        {
            RequestPostUserProfileAttachmentServiceDto req = new RequestPostUserProfileAttachmentServiceDto()
            {
                File = Request.Form.Files[0],
                Title = Title,
                UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal),
            };
            return Json(_userProfileFacade.PostUserProfileAttachmentsService.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileAttachmentsDelete(RequestDeleteUserProfileAttachmentsServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userProfileFacade.DeleteUserProfileAttachmentsService.Execute(req));
        }
        /// <summary>
        /// //////////////////////////////////////////// Photos
        /// </summary>
        /// <returns></returns>
        ///         [HttpGet]
        [HttpGet]
        public IActionResult Photos()
        {
            var usersId = (int)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            ModelGetPhoto modelGetPhoto = new ModelGetPhoto
            {
                ResultGetUsersPhotoAlbumServiceDto = _userPhotoFacade.GetUsersPhotoAlbumService
                .Execute(new RequestGetUsersPhotoAlbumServiceDto
                {
                    UsersId = usersId,
                }).Data
            };
            return View(modelGetPhoto);
        }
        [HttpPost]
        public IActionResult ProfileAlbumPost(RequestPostUsersPhotosAlbumServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userPhotoFacade.PostUsersPhotosAlbumService.Execute(req));
        }
        [HttpPost]
        public IActionResult ProfileAlbumDelete(RequestDeleteUsersPhotosAlbumServiceDto req)
        {
            req.UsersId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_userPhotoFacade.DeleteUsersPhotosAlbumService.Execute(req));
        }
    }
}