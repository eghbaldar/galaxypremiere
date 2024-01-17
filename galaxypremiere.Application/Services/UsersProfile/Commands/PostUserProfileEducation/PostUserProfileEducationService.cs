using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation
{
    public class PostUserProfileEducationService : IPostUserProfileEducationService
    {
        private readonly IDataBaseContext _context;
        public PostUserProfileEducationService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostUserProfileEducationServiceDto req)
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
                var profile = _context.UsersEducation.Where(e => e.UsersId == req.UsersId).ToList();

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
                        UsersEducation usersEducation = new UsersEducation();
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
                                usersEducation.UsersId = req.UsersId;
                                usersEducation.Name = info[1].ToString();
                                usersEducation.Field = info[2].ToString();
                                usersEducation.From = Convert.ToDateTime(info[3]);
                                usersEducation.To = Convert.ToDateTime(info[4]);

                                _context.UsersEducation.Add(usersEducation);
                                resultHiddenId_and_Value.Add(info[5].ToString(), usersEducation.Id.ToString()); // key=> Hidden-Control-Name    value=> Stored-ID
                                _context.SaveChanges();
                            }
                        }
                        else //update
                        {
                            var educationalCase = profile.Where(p => p.Id == Guid.Parse(info[0].ToString())).ToList();
                            educationalCase.First().Name = info[1].ToString();
                            educationalCase.First().Field = info[2].ToString();
                            educationalCase.First().From = Convert.ToDateTime(info[3]);
                            educationalCase.First().To = Convert.ToDateTime(info[4]);
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
