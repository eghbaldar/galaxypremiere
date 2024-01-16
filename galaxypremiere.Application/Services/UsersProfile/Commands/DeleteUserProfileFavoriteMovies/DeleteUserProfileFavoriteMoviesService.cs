using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileFavoriteMovies
{
    public class DeleteUserProfileFavoriteMoviesService: IDeleteUserProfileFavoriteMoviesService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserProfileFavoriteMoviesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUserProfileFavoriteMoviesServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Something went wrong"
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var profile = _context.UsersFavoriteMovies
                    .Where(ufm => ufm.Id == req.Id && ufm.UsersId == req.UsersId).FirstOrDefault();
                if (profile != null)
                {
                    _context.UsersFavoriteMovies.Remove(profile); // attention: the deletion not be happened because of changeover of DataBaseContext.cs
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "The information have been updated"
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "The favorite movie does not exist"
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist"
                };
            }
        }
    }
}
