using galaxypremiere.Application.Services.UserActionsLog.Commands.PostUserActionLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IUserActionLogFacade
    {
        public PostUserActionLogService PostUserActionLogService { get;}
    }
}
