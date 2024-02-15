using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername;

namespace Endpoint.Site.Models.Porfile.GetInformationByUsername
{
    public class ModelGetInformationByUsername
    {
        public ResultGetUsersInformationByUsernameServiceDto ResultGetUsersInformationByUsernameServiceDto { get; set; }
        public ResultGetUsersInformationPhotosByUsernameServiceDto ResultGetUsersInformationPhotosByUsernameServiceDto { get; set; }
    }
}
