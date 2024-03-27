using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername;
using galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts;

namespace Endpoint.Site.Models.Porfile.GetInformationByUsername
{
    public class ModelGetInformationByUsername
    {
        public ResultGetUsersInformationByUsernameServiceDto ResultGetUsersInformationByUsernameServiceDto { get; set; }
        public ResultGetUsersInformationPhotosByUsernameServiceDto ResultGetUsersInformationPhotosByUsernameServiceDto { get; set; }
        public bool IsVisitorOwner; // If the visitor is the same as the owner of the page, this variable will be filled with 'true'; otherwise, it will be filled with 'false'.
        public ResultGetUsersPostsServiceDto ResultGetUsersPostsServiceDto { get; set; }
        public string UsernameOfThePage; // keep the username of the page after its loading
    }
}
