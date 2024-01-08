using galaxypremiere.Application.Services.Countries.Queries.GetCountries;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileFavoriteMovies;

namespace Endpoint.Site.Models.Users.GetProfile
{
    public class ModelGetProfile
    {
        public ResultGetUserProfileEducationsServiceDto ResultGetUserProfileEducationsServiceDto { get; set; }
        public ResultGetUserProfileFavoriteMoviesServiceDto ResultGetUserProfileFavoriteMoviesServiceDto { get; set; }
        public ResultGetCountriesServiceDto resultGetCountriesServiceDto { get; set; }
        public ResultGetUserProfileCompaniesServiceDto ResultGetUserProfileCompaniesServiceDto { get; set; }
    }
}
