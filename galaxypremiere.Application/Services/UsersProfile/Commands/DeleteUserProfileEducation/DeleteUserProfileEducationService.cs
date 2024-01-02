using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileEducation
{
    public class DeleteUserProfileEducationService : IDeleteUserProfileEducationService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserProfileEducationService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUserProfileEducationServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var profile = _context.UsersEducation.Where(ue => ue.Id == req.Id).FirstOrDefault();
                if (profile != null)
                {                    
                    _context.UsersEducation.Remove(profile); // attention: the deletion not be happened because of changeover of DataBaseContext.cs
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
                        Message = "The educational case does not exist"
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
