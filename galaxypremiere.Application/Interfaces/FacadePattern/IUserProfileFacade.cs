using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileAttachments;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileLinks;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileNews;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileAttachments;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileLinks;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileNews;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileAttachments;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileLinks;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IUserProfileFacade
    {
        PostUserProfileEducationService PostUserProfileEducationService { get; }
        GetUserProfileEducationsService GetUserProfileEducationsService { get; }
        DeleteUserProfileEducationService DeleteUserProfileEducationService { get; }
        PostUserProfileFavoriteMoviesService PostUserProfileFavoriteMoviesService { get; }
        GetUserProfileFavoriteMoviesService GetUserProfileFavoriteMoviesService { get; }
        DeleteUserProfileFavoriteMoviesService DeleteUserProfileFavoriteMoviesService { get; }
        PostUserProfileCompaniesService PostUserProfileCompaniesService { get; }
        GetUserProfileCompaniesService GetUserProfileCompaniesService { get; }
        DeleteUserProfileCompanies DeleteUserProfileCompanies { get; }
        GetUserProfileNewsService GetUserProfileNewsService { get; }
        PostUserProfileNewsService PostUserProfileNewsService { get; }
        DeleteUserProfileNewsService DeleteUserProfileNewsService { get; }
        GetUserProfileLinksService GetUserProfileLinksService { get; }
        PostUserProfileLinksService PostUserProfileLinksService { get; }
        DeleteUserProfileLinksService DeleteUserProfileLinksService { get; }
        PostUserProfileAttachmentsService PostUserProfileAttachmentsService { get; }
        GetUserProfileAttachmentsService GetUserProfileAttachmentsService { get; }
        DeleteUserProfileAttachmentsService DeleteUserProfileAttachmentsService { get; }
    }
}
