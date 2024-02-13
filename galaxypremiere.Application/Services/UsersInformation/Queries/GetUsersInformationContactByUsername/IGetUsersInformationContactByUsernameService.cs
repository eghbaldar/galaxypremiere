using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername
{
    public class RequestGetUsersInformationContactByUsernameServiceDto
    {

    }
    public class GetUsersInformationContactByUsernameServiceDto
    {
        public int CountryId { get; set; } = 0; // derived from [Countries] entity
        public string CountryName { get; set; }
    }
    public interface IGetUsersInformationContactByUsernameService
    {
    }
    public class GetUsersInformationContactByUsernameService: IGetUsersInformationContactByUsernameService
    {

    }
}
