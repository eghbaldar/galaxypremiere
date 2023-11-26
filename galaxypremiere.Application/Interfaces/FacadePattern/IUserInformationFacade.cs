using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IUserInformationFacade
    {
        public GetUsersInformationService GetUsersInformationServiceService { get; }
        public UpdateUsersInformationAccountService UsersInformationAccountService { get; }
    }
}
