using galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileFavoriteMovies;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileNews
{
    public interface IDeleteUserProfileNewsService
    {
        ResultDto Execute(RequestDeleteUserProfileNewsServiceDto req);
    }
}
