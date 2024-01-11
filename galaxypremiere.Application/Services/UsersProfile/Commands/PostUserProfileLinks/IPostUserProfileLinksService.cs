using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileLinks
{
    public interface IPostUserProfileLinksService
    {
        ResultDto Execute(RequestPostUserProfileLinkServiceDto req);
    }
}
