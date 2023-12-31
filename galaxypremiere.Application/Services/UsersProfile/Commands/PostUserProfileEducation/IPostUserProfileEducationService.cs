using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation
{
    public interface IPostUserProfileEducationService
    {
        ResultDto Execute(RequestPostUserProfileEducationServiceDto req);
    }
}
