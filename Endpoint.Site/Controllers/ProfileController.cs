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
using galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoComment;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoIncreaseVisitorCounter;
using galaxypremiere.Application.Services.Likes.Commands.PostLike;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationUsernameByUserId;
using galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost;
using galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts;
using galaxypremiere.Application.Services.Comments.Commands.PostComment;
using galaxypremiere.Application.Services.Comments.Commands.DeleteComment;
using galaxypremiere.Application.Services.Comments.Queries.GetCommentsBySectionId;

namespace Endpoint.Site.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserInformationFacade _userInformationFacade;
        private readonly IUserPhotoFacade _userPhoto;
        private readonly ILikesFacade _ikesFacade;
        private readonly IUsersPostFacade _usersPost;
        private readonly IUsersPostsPhotosFacade _usersPostsPhotosFacade;
        private readonly ICommentsFacade _commentsFacade;
        public ProfileController(IUserInformationFacade userInformationFacade,
            IUserPhotoFacade userPhotoFacade,
            ILikesFacade ikesFacade,
            IUsersPostFacade usersPost,
            IUsersPostsPhotosFacade usersPostsPhotosFacade,
            ICommentsFacade commentsFacade)
        {
            _userInformationFacade = userInformationFacade;
            _userPhoto = userPhotoFacade;
            _ikesFacade = ikesFacade;
            _usersPost = usersPost;
            _usersPostsPhotosFacade = usersPostsPhotosFacade;
            _commentsFacade = commentsFacade;
        }
        [HttpGet]
        public IActionResult Index(string username)
        {
            long userId = 0;
            if (User.Identity.IsAuthenticated) userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            ModelGetInformationByUsername modelGetInformationByUsername = new ModelGetInformationByUsername
            {
                ResultGetUsersInformationByUsernameServiceDto = _userInformationFacade.GetUsersInformationByUsernameService.Execute(new RequestUsersInformationByUsernameServiceDto
                {
                    Username = username
                }),
                ResultGetUsersInformationPhotosByUsernameServiceDto = _userInformationFacade.GetUsersInformationPhotosByUsernameService.Execute(new RequestGetUsersInformationPhotosByUsernameServiceDto
                {
                    Username = username,
                    TotalPhotos = 6,
                    UserId = userId,
                }),
                IsVisitorOwner = (_userInformationFacade.GetUsersInformationUsernameByUserIdService.Execute(new RequestGetUsersInformationUsernameByUserIdServiceDto
                {
                    UsersId = userId,
                }).Data == username) ? true : false,
                ResultGetUsersPostsServiceDto = _usersPost.GetUsersPostsService.Execute(new RequestGetUsersPostsServiceDto
                {
                    Username = username,
                }).Data,
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
        public IActionResult PostPhotoComment(RequestPostCommentServiceDto req)
        {
            var userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            req.UsersId = userId;
            req.Section = 0;
            req.Email = ClaimUtility.GetUserEmail(User as ClaimsPrincipal);
            return Json(_commentsFacade.PostCommentService.Execute(req));
            //return Json(_userPhoto.PostUsersPhotoCommentService.Execute(req));
        }
        [HttpGet]
        public IActionResult GetPhotoCommentById(Guid Id)
        {
            long userId = 0;
            if (User.Identity.IsAuthenticated) userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            return Json(_commentsFacade.GetCommentsBySectionIdService.Execute(new RequestGetCommentsBySectionIdServiceDto
            {
                Section = 0,
                SectionId = Id,
                UserId = userId,
            }));
            //return Json(_userPhoto.GetUserPhotoCommentsService.Execute(new RequestGetUserPhotoCommentsServiceDto
            //{
            //    Id = Id,
            //    UserId = userId,
            //}));
        }
        [HttpPost]
        public IActionResult DeletePhotoComment(RequestDeleteCommentServiceDto req)
        {
            long userId = 0;
            if (User.Identity.IsAuthenticated) userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            req.UserId = userId;
            req.Section = 0;// Derived from SectionsConstants.cs
            return Json(_commentsFacade.DeleteCommentService.Execute(req));
            //return Json(_userPhoto.DeleteUsersPhotoCommentService.Execute(req));
        }
        [HttpPost]
        public IActionResult PostPhotoIncrementVisitorCounter(RequestPostUsersPhotoIncreaseVisitorCounterServiceDto req)
        {
            return Json(_userPhoto.PostUsersPhotoIncreaseVisitorCounterService.Execute(req));
        }
        [HttpPost]
        public IActionResult PostPhotoLike(RequestPostLikeServiceDto req)
        {
            long userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            req.UsersId = userId;
            req.Section = SectionsConstants.UserPhotos; // drived from "SectionsConstants.cs"
            return Json(_ikesFacade.PostLikeService.Execute(req));
        }
        [HttpPost]
        public IActionResult PostPost(RequestPostUsersPostServiceDto req)
        {
            long userId = (long)ClaimUtility.GetUserId(User as ClaimsPrincipal);
            req.UsersId = userId;
            req.From = userId;
            return Json(_usersPost.PostUsersPostService.Execute(req));
        }
    }
}
