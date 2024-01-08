using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileFavoriteMovies;
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
    }
}
