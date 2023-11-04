using galaxypremiere.Application.Services.UserLoginLog.Commands.PostUserLoginLog;
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
    }
}
