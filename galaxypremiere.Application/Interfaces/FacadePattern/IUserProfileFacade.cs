using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface IUserProfileFacade
    {
        PostUserProfileEducationService PostUserProfileEducationService { get; }
        GetUserProfileEducationsService GetUserProfileEducationsService { get; }
        DeleteUserProfileEducationService DeleteUserProfileEducationService { get; }
    }
}
