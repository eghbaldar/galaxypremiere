using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileNews;
using galaxypremiere.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileLinks
{
    public interface IDeleteUserProfileLinksService
    {
        ResultDto Execute(RequestDeleteUserProfileLinksServiceDto req);
    }
}
