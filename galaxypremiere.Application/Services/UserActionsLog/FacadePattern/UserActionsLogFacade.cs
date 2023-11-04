using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UserActionsLog.Commands.PostUserActionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UserActionsLog.FacadePattern
{
    public class UserActionsLogFacade: IUserActionLogFacade
    {
        private readonly IDataBaseContext _context;
        public UserActionsLogFacade(IDataBaseContext context)
        {
            _context = context;
        }
        ///////////////////////////////////// PostUserActionLogService
        private PostUserActionLogService _postUserActionLogService;
        public PostUserActionLogService PostUserActionLogService
        {
            get { return _postUserActionLogService = _postUserActionLogService ?? new PostUserActionLogService(_context); }
        }
    }
}
