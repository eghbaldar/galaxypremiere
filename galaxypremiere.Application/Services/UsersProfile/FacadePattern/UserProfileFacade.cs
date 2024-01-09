using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Metags.Queries.GetMetagsInfoByLink;
using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileCompanies;
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

namespace galaxypremiere.Application.Services.UsersProfile.FacadePattern
{
    public class UserProfileFacade : IUserProfileFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UserProfileFacade(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // Post User Profile Education
        private PostUserProfileEducationService _postUserProfileEducationService;
        public PostUserProfileEducationService PostUserProfileEducationService
        {
            get { return _postUserProfileEducationService = _postUserProfileEducationService ?? new PostUserProfileEducationService(_context); }
        }
        // Get User Profile Educations
        private GetUserProfileEducationsService _getUserProfileEducationsService;
        public GetUserProfileEducationsService GetUserProfileEducationsService
        {
            get { return _getUserProfileEducationsService = _getUserProfileEducationsService ?? new GetUserProfileEducationsService(_context, _mapper); }
        }
        // Delete User Profile Educations
        private DeleteUserProfileEducationService _deleteUserProfileEducationService;
        public DeleteUserProfileEducationService DeleteUserProfileEducationService
        {
            get { return _deleteUserProfileEducationService = _deleteUserProfileEducationService ?? new DeleteUserProfileEducationService(_context); }
        }
        // Post User Profile Favorite Movies
        private PostUserProfileFavoriteMoviesService _postUserProfileFavoriteMoviesService;
        public PostUserProfileFavoriteMoviesService PostUserProfileFavoriteMoviesService
        {
            get { return _postUserProfileFavoriteMoviesService = _postUserProfileFavoriteMoviesService ?? new PostUserProfileFavoriteMoviesService(_context); }
        }
        // Get User Profile Favorite Movies
        private GetUserProfileFavoriteMoviesService _getUserProfileFavoriteMoviesService;
        public GetUserProfileFavoriteMoviesService GetUserProfileFavoriteMoviesService
        {
            get { return _getUserProfileFavoriteMoviesService = _getUserProfileFavoriteMoviesService ?? new GetUserProfileFavoriteMoviesService(_context, _mapper); }
        }
        // Delete User Profile Favorite Movies
        private DeleteUserProfileFavoriteMoviesService _deleteUserProfileFavoriteMoviesService;
        public DeleteUserProfileFavoriteMoviesService DeleteUserProfileFavoriteMoviesService
        {
            get { return _deleteUserProfileFavoriteMoviesService = _deleteUserProfileFavoriteMoviesService ?? new DeleteUserProfileFavoriteMoviesService(_context); }
        }
        // Post User Profile Companies
        private PostUserProfileCompaniesService _postUserProfileCompaniesService;
        public PostUserProfileCompaniesService PostUserProfileCompaniesService
        {
            get { return _postUserProfileCompaniesService = _postUserProfileCompaniesService ?? new PostUserProfileCompaniesService(_context); }
        }
        // Get User Profile Companies
        private GetUserProfileCompaniesService _getUserProfileCompaniesService;
        public GetUserProfileCompaniesService GetUserProfileCompaniesService
        {
            get { return _getUserProfileCompaniesService = _getUserProfileCompaniesService ?? new GetUserProfileCompaniesService(_context); }
        }
        // Delete User Profle Companies
        private DeleteUserProfileCompanies _deleteUserProfileCompanies;
        public DeleteUserProfileCompanies DeleteUserProfileCompanies
        {
            get { return _deleteUserProfileCompanies = _deleteUserProfileCompanies ?? new DeleteUserProfileCompanies(_context); }
        }
    }
}
