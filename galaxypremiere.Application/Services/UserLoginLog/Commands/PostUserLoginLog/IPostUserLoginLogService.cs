using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UserLoginLog.Commands.PostUserLoginLog
{
    public interface IPostUserLoginLogService
    {
        bool Execute(RequestPostUserLoginLogServiceDto req);
    }
}
