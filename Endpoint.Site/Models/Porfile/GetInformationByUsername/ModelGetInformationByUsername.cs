using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUserPhotoComments;

namespace Endpoint.Site.Models.Porfile.GetInformationByUsername
{
    public class ModelGetInformationByUsername
    {
        public ResultGetUsersInformationByUsernameServiceDto ResultGetUsersInformationByUsernameServiceDto { get; set; }
        public ResultGetUsersInformationPhotosByUsernameServiceDto ResultGetUsersInformationPhotosByUsernameServiceDto { get; set; }
    }
}
