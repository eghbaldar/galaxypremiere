using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileFavoriteMovies
{
    public class PostUserProfileFavoriteMoviesService: IPostUserProfileFavoriteMoviesService
    {
        private readonly IDataBaseContext _context;
        public PostUserProfileFavoriteMoviesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostUserProfileFavoriteMoviesServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var profile = _context.UsersFavoriteMovies
                .Where(e => e.UsersId == req.UsersId)
                .ToList();

                if (req.info == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "Something went wrong."
                    };
                }

                if ((req.info.Length + profile.Count) < 11 || !profile.Any())
                {
                    foreach (var anyInfo in req.info)
                    {
                        UsersFavoriteMovies usersFavoriteMovies = new UsersFavoriteMovies();

                        var info = anyInfo.ToString().Split("|");

                        // add cases that were not added to the list before!
                        if (!profile.Where(p => p.Id.ToString() == info[0].ToString()).Any())
                        {
                            if (!String.IsNullOrEmpty(info[1].ToString().Trim()))
                            {
                                usersFavoriteMovies.UsersId = req.UsersId;
                                usersFavoriteMovies.ImdbLink = info[1].ToString();

                                _context.UsersFavoriteMovies.Add(usersFavoriteMovies);
                                _context.SaveChanges();
                            }
                            else
                            {
                                return new ResultDto
                                {
                                    IsSuccess = false,
                                    Message = "All fields must be filled."
                                };
                            }
                        }
                    }

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "The new user's educational cases has just been updated."
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "Only 10 educational cases are allowed."
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
        }
    }
}
