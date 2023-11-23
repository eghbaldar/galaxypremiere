using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.FacadePattern
{
    public class UserInformationFacade:IUserInformation
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UserInformationFacade(IDataBaseContext context,IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
        }
        // Update User Information => Account
        private UpdateUsersInformationAccountService _usersInformationAccountService;
        public UpdateUsersInformationAccountService UsersInformationAccountService
        {
            get { return _usersInformationAccountService = _usersInformationAccountService ?? new UpdateUsersInformationAccountService(_context, _mapper);  }
        }
    }
}
