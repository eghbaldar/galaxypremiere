using galaxypremiere.Application.Services.Countries.Queries.GetCountries;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileAttachments;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileLinks;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews;

namespace Endpoint.Site.Models.Users.GetProfile
{
    public class ModelGetProfile
    {
        public ResultGetUserProfileEducationsServiceDto ResultGetUserProfileEducationsServiceDto { get; set; }
        public ResultGetUserProfileFavoriteMoviesServiceDto ResultGetUserProfileFavoriteMoviesServiceDto { get; set; }
        public ResultGetCountriesServiceDto resultGetCountriesServiceDto { get; set; }
        public ResultGetUserProfileCompaniesServiceDto ResultGetUserProfileCompaniesServiceDto { get; set; }
        public ResultGetUserProfileNewsServiceDto ResultGetUserProfileNewsServiceDto{ get; set; }
        public ResultGetUserProfileLinksServiceDto ResultGetUserProfileLinksServiceDto{ get; set; }
        public ResultGetUserProfileAttachmentsServiceDto ResultGetUserProfileAttachmentsServiceDto { get; set; }
    }
}
