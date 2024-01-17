using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileNews
{
    public class PostUserProfileNewsService : IPostUserProfileNewsService
    {
        private readonly IDataBaseContext _context;
        public PostUserProfileNewsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostUserProfileNewsServiceDto req)
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
                var profile = _context.UsersNews.Where(e => e.UsersId == req.UsersId).ToList();

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
                        UsersNews usersnews = new UsersNews();
                        var info = anyInfo.ToString().Split("|");
                        // check the acceptable input as a guid
                        // the following code will be checking the GUID ID according to the original its format:00000000-0000-0000-0000-000000000000
                        // why must we check the format of the GUID ID?
                        // if the structure of the ID matches with GUID format, it means the record is added newly by a new form unless the record has already been added and needs to be updated
                        Guid guidOutput;
                        bool isValid = Guid.TryParse(info[0].ToString(), out guidOutput);
                        // end checking ...

                        // add cases that were not added to the list before!
                        if (!isValid)
                        {
                            if (!String.IsNullOrEmpty(info[1].ToString().Trim())
                                &&
                                !String.IsNullOrEmpty(info[2].ToString().Trim())
                                &&
                                !String.IsNullOrEmpty(info[3].ToString().Trim())
                                &&
                                !String.IsNullOrEmpty(info[4].ToString().Trim()))
                            {
                                usersnews.UsersId = req.UsersId;
                                usersnews.Title = info[1].ToString();
                                usersnews.Reference = info[2].ToString();
                                usersnews.Link = info[3].ToString();
                                usersnews.PublishedDate = Convert.ToDateTime(info[4]);

                                _context.UsersNews.Add(usersnews);
                                resultHiddenId_and_Value.Add(info[5].ToString(), usersnews.Id.ToString()); // key=> Hidden-Control-Name    value=> Stored-ID
                                _context.SaveChanges();
                            }
                        }
                        else //update
                        {
                            var news = profile.Where(p => p.Id == Guid.Parse(info[0].ToString())).ToList();
                            news.First().Title = info[1].ToString();
                            news.First().Reference = info[2].ToString();
                            news.First().Link = info[3].ToString();
                            news.First().PublishedDate = Convert.ToDateTime(info[4]);
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
                        Message = "Only 10 news are allowed."
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
