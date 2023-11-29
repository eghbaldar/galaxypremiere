using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.FacadePattern
{
    public class UserInformationFacade:IUserInformationFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UserInformationFacade(IDataBaseContext context,IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
        }
        // Get User Information => Account
        private GetUsersInformationService _getUsersInformationServiceService;
        public GetUsersInformationService GetUsersInformationServiceService
        {
            get { return _getUsersInformationServiceService = _getUsersInformationServiceService ?? new GetUsersInformationService(_context,_mapper); }
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
    }
}
