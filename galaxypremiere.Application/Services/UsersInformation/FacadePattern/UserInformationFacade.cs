using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationAccountType;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeader;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeadshot;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationOther;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPassword;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPrivacy;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetCheckDuplicatedUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContact;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.FacadePattern
{
    public class UserInformationFacade : IUserInformationFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UserInformationFacade(
            IDataBaseContext context,
            IMapper mapper)
        {   
            _context = context;
            _mapper = mapper;
        }
        // Get User Information => Account
        private GetUsersInformationService _getUsersInformationServiceService;
        public GetUsersInformationService GetUsersInformationServiceService
        {
            get { return _getUsersInformationServiceService = _getUsersInformationServiceService ?? new GetUsersInformationService(_context, _mapper); }
        }
        // Update User Information => Account
        private UpdateUsersInformationAccountService _usersInformationAccountService;
        public UpdateUsersInformationAccountService UsersInformationAccountService
        {
            get { return _usersInformationAccountService = _usersInformationAccountService ?? new UpdateUsersInformationAccountService(_context, _mapper); }
        }
        // Get User Information => Contact
        private GetUsersInformationContactService _getUsersInformationContactService;
        public GetUsersInformationContactService GetUsersInformationContactService
        {
            get { return _getUsersInformationContactService = _getUsersInformationContactService ?? new GetUsersInformationContactService(_context, _mapper); }
        }
        // Update User Information => Contact
        private UpdateUsersInformationContactService _updateUsersInformationContactService;
        public UpdateUsersInformationContactService UpdateUsersInformationContactService
        {
            get { return _updateUsersInformationContactService = _updateUsersInformationContactService ?? new UpdateUsersInformationContactService(_context, _mapper); }
        }
        // Update User Information => Privacy
        private UpdateUsersInformationPrivacyService _updateUsersInformationPrivacyService;
        public UpdateUsersInformationPrivacyService UpdateUsersInformationPrivacyService
        {
            get { return _updateUsersInformationPrivacyService = _updateUsersInformationPrivacyService ?? new UpdateUsersInformationPrivacyService(_context); }
        }
        // Update User Information => Username
        private UpdateUsersInformationUsernameService _updateUsersInformationUsernameService;
        public UpdateUsersInformationUsernameService UpdateUsersInformationUsernameService
        {
            get { return _updateUsersInformationUsernameService = _updateUsersInformationUsernameService ?? new UpdateUsersInformationUsernameService(_context); }
        }
        // Check Duplicated Username
        private GetCheckDuplicatedUsernameService _getCheckDuplicatedUsernameService;
        public GetCheckDuplicatedUsernameService GetCheckDuplicatedUsernameService
        {
            get { return _getCheckDuplicatedUsernameService = _getCheckDuplicatedUsernameService ?? new GetCheckDuplicatedUsernameService(_context); }
        }
        // Update User Information => Password
        private UpdateUsersInformationPasswordService _updateUsersInformationPasswordService;
        public UpdateUsersInformationPasswordService UpdateUsersInformationPasswordService
        {
            get { return _updateUsersInformationPasswordService = _updateUsersInformationPasswordService ?? new UpdateUsersInformationPasswordService(_context,_mapper); }
        }
        // Update User Information => Account Type
        public UpdateUsersInformationAccountTypeService _updateUsersInformationAccountTypeService;
        public UpdateUsersInformationAccountTypeService UpdateUsersInformationAccountTypeService
        {
            get { return _updateUsersInformationAccountTypeService = _updateUsersInformationAccountTypeService ?? new UpdateUsersInformationAccountTypeService(_context, _mapper); }
        }
        // Update User Information => BIO
        private UpdateUsersInformationBioService _updateUsersInformationBioService;
        public UpdateUsersInformationBioService UpdateUsersInformationBioService
        {
            get { return _updateUsersInformationBioService = _updateUsersInformationBioService ?? new UpdateUsersInformationBioService(_context, _mapper); }
        }
        // Update User Information => Headshot
        private UpdateUsersInformationHeadshotService _updateUsersInformationHeadshotService;
        public UpdateUsersInformationHeadshotService UpdateUsersInformationHeadshotService
        {
            get { return _updateUsersInformationHeadshotService = _updateUsersInformationHeadshotService ?? new UpdateUsersInformationHeadshotService(_context, _mapper); }
        }        
        // Update User Information => Header
        private UpdateUsersInformationHeaderService _updateUsersInformationHeaderService;
        public UpdateUsersInformationHeaderService UpdateUsersInformationHeaderService
        {
            get { return _updateUsersInformationHeaderService = _updateUsersInformationHeaderService ?? new UpdateUsersInformationHeaderService(_context, _mapper); }
        }
        // Update User Information => Other
        private UpdateUsersInformationOtherService _updateUsersInformationOtherService;
        public UpdateUsersInformationOtherService UpdateUsersInformationOtherService
        {
            get { return _updateUsersInformationOtherService = _updateUsersInformationOtherService ?? new UpdateUsersInformationOtherService(_context, _mapper); }
        }        
        // Get User Information By Username => Main Information
        private GetUsersInformationByUsernameService _getUsersInformationByUsernameService;
        public GetUsersInformationByUsernameService GetUsersInformationByUsernameService
        {
            get { return _getUsersInformationByUsernameService = _getUsersInformationByUsernameService ?? new GetUsersInformationByUsernameService(_context,_mapper); }
        }
        // Get User Information By Username => About Me
        private GetUsersInformationAboutByUsernameService _getUsersInformationAboutByUsernameService;
        public GetUsersInformationAboutByUsernameService GetUsersInformationAboutByUsernameService
        {
            get { return _getUsersInformationAboutByUsernameService = _getUsersInformationAboutByUsernameService ?? new GetUsersInformationAboutByUsernameService(_context, _mapper); }
        }     
        // Get User Positions => About Me
        private GetUsersInformationPositionsService _getUsersInformationPositionsService;
        public GetUsersInformationPositionsService GetUsersInformationPositionsService
        {
            get { return _getUsersInformationPositionsService = _getUsersInformationPositionsService ?? new GetUsersInformationPositionsService(_context); }
        }       
        // Get User Address => Contact
        private GetUsersInformationContactByUsernameService _getUsersInformationContactByUsernameService;
        public GetUsersInformationContactByUsernameService GetUsersInformationContactByUsernameService
        {
            get { return _getUsersInformationContactByUsernameService = _getUsersInformationContactByUsernameService ?? new GetUsersInformationContactByUsernameService(_context,_mapper); }
        }
    }
}