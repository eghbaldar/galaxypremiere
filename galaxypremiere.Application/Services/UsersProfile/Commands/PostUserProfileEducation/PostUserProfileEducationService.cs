using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation
{
    public class PostUserProfileEducationService : IPostUserProfileEducationService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _imapper;
        public PostUserProfileEducationService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _imapper = mapper;
        }
        public ResultDto Execute(RequestPostUserProfileEducationServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var profile = _context.UsersEducation
                .Where(e => e.UsersId == req.UsersId)
                .ToList();

                if ((req.info.Length + profile.Count) < 11 || !profile.Any())
                {
                    foreach (var anyInfo in req.info)
                    {
                        UsersEducation usersEducation = new UsersEducation();

                        var info = anyInfo.ToString().Split("|");

                        if (!profile.Where(p => p.Id.ToString() == info[0].ToString()).Any())
                        {
                            usersEducation.UsersId = req.UsersId;
                            usersEducation.Name = info[1].ToString();
                            usersEducation.Field = info[2].ToString();
                            usersEducation.From = Convert.ToDateTime(info[3]);
                            usersEducation.To = Convert.ToDateTime(info[4]);

                            _context.UsersEducation.Add(usersEducation);
                            _context.SaveChanges();
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
