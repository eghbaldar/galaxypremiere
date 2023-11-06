using galaxypremiere.Application.Services.UserLoginLog.Commands.PostUserLoginLog;
using galaxypremiere.Application.Services.UserLoginLog.Queries.GetUsersLoginLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IUserLoginLogFacade
    {
        PostUserLoginLogService PostUserLoginLogService { get; }
        GetUsersLoginLogsService GetUsersLoginLogsService { get; }
    }
}
