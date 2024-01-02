using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileEducation
{
    public interface IDeleteUserProfileEducationService
    {
        ResultDto Execute(RequestDeleteUserProfileEducationServiceDto req);
    }
}
