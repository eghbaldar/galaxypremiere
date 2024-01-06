using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Services.Metags.Queries.GetMetagsInfoByLink;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Collections.Generic;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileFavoriteMovies
{
    public class PostUserProfileFavoriteMoviesService : IPostUserProfileFavoriteMoviesService
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
                var profile = _context.UsersFavoriteMovies.Where(e => e.UsersId == req.UsersId).ToList();

                if (req.info == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "Something went wrong."
                    };
                }
                if ((req.info.Length) <= 10)
                {
                    Dictionary<string, string> resultHiddenId_and_Value = new Dictionary<string, string>();
                    foreach (var anyInfo in req.info)
                    {
                        UsersFavoriteMovies usersFavoriteMovies = new UsersFavoriteMovies();
                        var info = anyInfo.ToString().Split("|");
                        // check the acceptable input as a guid
                        // the following code will be checking the GUID ID according to the original its format:00000000-0000-0000-0000-000000000000
                        // why must we check the format of the GUID ID?
                        // if the structure of the ID matches with GUID format, it means the record is added newly by a new form unless the record has already been added and needs to be updated
                        Guid guidOutput;
                        bool isValid = Guid.TryParse(info[0].ToString(), out guidOutput);
                        // end checking ...

                        // add a case that was not added to the list before!
                        if (!isValid)
                        {
                            if (!String.IsNullOrEmpty(info[1].ToString().Trim()))
                            {
                                usersFavoriteMovies.UsersId = req.UsersId;
                                // check validation of link
                                ResultDto resultDto = CheckLink(info[1].ToString());
                                if (resultDto.IsSuccess)
                                {
                                    usersFavoriteMovies.ImdbLink = info[1].ToString();
                                    _context.UsersFavoriteMovies.Add(usersFavoriteMovies);
                                    resultHiddenId_and_Value.Add(info[2].ToString(), usersFavoriteMovies.Id.ToString()); // key=> Hidden-Control-Name    value=> Stored-ID
                                    _context.SaveChanges();
                                }
                                else
                                {
                                    resultHiddenId_and_Value.Add(info[0].ToString(), "false"); // key=> Hidden-Control-Name    value=> false
                                }
                            }
                        }
                        else //update
                        {
                            var favoriteMovies = profile.Where(p => p.Id == Guid.Parse(info[0].ToString())).ToList();
                            ResultDto resultDto = CheckLink(info[1].ToString());
                            if (resultDto.IsSuccess)
                            {
                                favoriteMovies.First().ImdbLink = info[1].ToString();
                                _context.SaveChanges();
                            }
                            else
                            {
                                string[] hiddenId = info[2].ToString().Split("_");
                                // if the link has a problem (couldn't have been able to fetch data) we have to return a static value ("false") and then check this value on the client side to show an appropriate message to the client
                                resultHiddenId_and_Value.Add(hiddenId[1], "false");
                            }                            
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
