using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UserLoginLog.Commands.PostUserLoginLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UserLoginLog.FacadePattern
{
    public class UserLoginLogFacade:IUserLoginLogFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UserLoginLogFacade(IDataBaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //////////////////////////////////////////////////////// PostUserLoginLogService
        private PostUserLoginLogService _postUserLoginLogService;
        public PostUserLoginLogService PostUserLoginLogService
        {
            get { return _postUserLoginLogService = _postUserLoginLogService ?? new PostUserLoginLogService(_context,_mapper); }
        }
    }
}
