using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Services.Metags.Queries.GetMetagsInfoByLink;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using System.Collections;
using System.Collections.Generic;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileFavoriteMovies
{
    public class PostUserProfileFavoriteMoviesService : IPostUserProfileFavoriteMoviesService
    {
        private readonly IDataBaseContext _context;
        public PostUserProfileFavoriteMoviesService(
            IDataBaseContext context)
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
                    Dictionary<string, string> resultHiddenId_and_Value = new Dictionary<string, string>();
                    foreach (var anyInfo in req.info)
                    {
                        UsersFavoriteMovies usersFavoriteMovies = new UsersFavoriteMovies();

                        var info = anyInfo.ToString().Split("|");

                        // add a case that was not added to the list before!
                        if (!profile.Where(p => p.Id.ToString() == info[0].ToString()).Any())
                        {
                            if (!String.IsNullOrEmpty(info[1].ToString().Trim()))
                            {
                                usersFavoriteMovies.UsersId = req.UsersId;

                                // check validation of link
                                ResultDto resultDto = CheckLink(info[1].ToString());
                                if (!resultDto.IsSuccess)
                                {
                                    return new ResultDto
                                    {
                                        IsSuccess = false,
                                        Message = resultDto.Message,
                                    };
                                }
                                usersFavoriteMovies.ImdbLink = info[1].ToString();

                                _context.UsersFavoriteMovies.Add(usersFavoriteMovies);
                                _context.SaveChanges();

                                resultHiddenId_and_Value.Add(info[2].ToString(), usersFavoriteMovies.Id.ToString());
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
                        else
                        {
                            ResultDto resultDto = CheckLink(info[1].ToString());
                            if (!resultDto.IsSuccess)
                            {
                                return new ResultDto
                                {
                                    IsSuccess = false,
                                    Message = resultDto.Message,
                                };
                            }
                            profile.Where(p => p.Id.ToString() == info[0].ToString()).FirstOrDefault().ImdbLink = info[1].ToString();
                            _context.SaveChanges();
                        }
                    }
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = string.Join(Environment.NewLine, resultHiddenId_and_Value),
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "Only 10 favorite movie are allowed."
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
        private ResultDto CheckLink(string link)
        {
            // check validation of link
            GetMetagsInfoByLinkService _getMetagsInfoByLinkService = new GetMetagsInfoByLinkService();
            return _getMetagsInfoByLinkService.Execute(link, "https://www.imdb.com/");
        }
    }
}
