using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UserLoginLog.Queries.GetUsersLoginLogs
{
    public interface IGetUsersLoginLogsService
    {
        ResultGetUsersLoginLogsServiceDto Execute(RequestGetUsersLoginLogsServiceDto req);
    }
}
