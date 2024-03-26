using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPostArchive
{
    public interface IUpdateUsersPostArchiveService
    {
        ResultDto Execute(RequestUpdateUsersPostArchiveServiceDto req);
    }
}