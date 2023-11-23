using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IUserInformation
    {
        public UpdateUsersInformationAccountService UsersInformationAccountService { get; }
    }
}
