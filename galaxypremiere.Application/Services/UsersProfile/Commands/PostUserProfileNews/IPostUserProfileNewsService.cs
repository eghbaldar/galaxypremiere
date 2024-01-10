using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileNews
{
    public interface IPostUserProfileNewsService
    {
        ResultDto Execute(RequestPostUserProfileNewsServiceDto req);
    }
}
