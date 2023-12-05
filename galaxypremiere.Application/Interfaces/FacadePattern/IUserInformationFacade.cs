using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationAccountType;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPassword;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPrivacy;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetCheckDuplicatedUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContact;
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
        public GetUsersInformationContactService GetUsersInformationContactService { get; }
        public UpdateUsersInformationContactService UpdateUsersInformationContactService {  get; }
        public UpdateUsersInformationPrivacyService UpdateUsersInformationPrivacyService { get; }
        public UpdateUsersInformationUsernameService UpdateUsersInformationUsernameService { get; }
        public GetCheckDuplicatedUsernameService GetCheckDuplicatedUsernameService {  get; }
        public UpdateUsersInformationPasswordService UpdateUsersInformationPasswordService { get; }
        public UpdateUsersInformationAccountTypeService UpdateUsersInformationAccountTypeService { get; }
        public UpdateUsersInformationBioService UpdateUsersInformationBioService { get; }
    }
}
