using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
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
    }
}
