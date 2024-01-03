using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileFavoriteMovies
{
    public interface IDeleteUserProfileFavoriteMoviesService
    {
        ResultDto Execute(RequestDeleteUserProfileFavoriteMoviesServiceDto req);
    }
}
