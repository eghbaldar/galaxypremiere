using Endpoint.Site.Models.Porfile.GetInformationByUsername;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername;
using Microsoft.AspNetCore.Mvc;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPositions;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoComment;
using Endpoint.Site.Utilities;
using System.Security.Claims;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUserPhotoComments;
using galaxypremiere.Common.Constants;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Endpoint.Site.Views.Shared.Components;
using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoComment;

namespace Endpoint.Site.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserInformationFacade _userInformationFacade;
        private readonly IUserPhotoFacade _userPhoto;
        public ProfileController(IUserInformationFacade userInformationFacade, IUserPhotoFacade userPhotoFacade)
        {
            _userInformationFacade = userInformationFacade;
            _userPhoto = userPhotoFacade;
        }
        [HttpGet]
        public IActionResult Index(string username)
        {
            ModelGetInformationByUsername modelGetInformationByUsername = new ModelGetInformationByUsername
            {
                ResultGetUsersInformationByUsernameServiceDto = _userInformationFacade.GetUsersInformationByUsernameService.Execute(new RequestUsersInformationByUsernameServiceDto
                {
                    Username = username
                }),
                ResultGetUsersInformationPhotosByUsernameServiceDto = _userInformationFacade.GetUsersInformationPhotosByUsernameService.Execute(new RequestGetUsersInformationPhotosByUsernameServiceDto
                {
                    Username = username,
                    TotalPhotos = 6
                }),
            };
            return View(modelGetInformationByUsername);
        }
        [HttpGet]
        public IActionResult GetInfoAbout(string username)
        {
            return Json(_userInformationFacade.GetUsersInformationAboutByUsernameService.Execute(new RequestGetUsersInformationAboutByUsernameServiceDto
            {
                Username = username
            }));
        }
        [HttpGet]
        public IActionResult GetInfoPositions(string positions)
        {
            return Json(_userInformationFacade.GetUsersInformationPositionsService.Execute(new RequestGetUsersInformationPositionsServiceDto
            {
                Positions = positions,
            }));
        }
        [HttpGet]
        public IActionResult GetInfoContact(string username)
        {
            return Json(_userInformationFacade.GetUsersInformationContactByUsernameService.Execute(new RequestGetUsersInformationContactByUsernameServiceDto
            {
                Username = username
            }));
        }
        [HttpPost]
        public IActionResult PostPhotoComment(RequestPostUsersPhotoCommentServiceDto req)
        {
            var userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            req.UsersId = userId;
            req.Email = ClaimUtility.GetUserEmail(User as ClaimsPrincipal);
            return Json(_userPhoto.PostUsersPhotoCommentService.Execute(req));
        }
        [HttpGet]
        public IActionResult GetPhotoCommentById(Guid Id)
        {
            long userId = 0;
            if (User.Identity.IsAuthenticated) userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);

            return Json(_userPhoto.GetUserPhotoCommentsService.Execute(new RequestGetUserPhotoCommentsServiceDto
            {
                Id = Id,
                UserId = userId,
            }));
        }
        [HttpPost]
        public IActionResult DeletePhotoComment(RequestDeleteUsersPhotoCommentServiceDto req)
        {
            long userId = 0;
            if (User.Identity.IsAuthenticated) userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            req.UserId = userId;
            return Json(_userPhoto.DeleteUsersPhotoCommentService.Execute(req));
        }
    }
}
