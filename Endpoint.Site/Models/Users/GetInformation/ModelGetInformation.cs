using galaxypremiere.Application.Services.Countries.Queries.GetCountries;
using galaxypremiere.Application.Services.Languages.Queries.GetLanguages;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContact;

namespace Endpoint.Site.Models.Users.GetInformation
{
    public class ModelGetInformation
    {
        public GetUsersInformationServiceDto getUsersInformationServiceDto { get; set; }
        public GetUsersInformationContactServiceDto getUsersInformationContactServiceDto { get; set; }
        public ResultGetCountriesServiceDto resultGetCountriesServiceDto { get; set; }
        public ResultGetLanguagesServiceDto resultGetLanguagesServiceDto { get; set; }
    }
}
