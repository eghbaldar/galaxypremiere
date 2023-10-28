using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.Users.Commands.ActivateUser
{
    public class ActiviateUserService : IActiviateUserService
    {
        private readonly IDataBaseContext _context;
        public ActiviateUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestActiviateUserServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.IdUser).FirstOrDefault();
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The User Doesn't Exist"
                };
            }
            user.IsActive = !user.IsActive;
            user.UpdateDate = DateTime.Now;
            _context.SaveChanges();
            var a = user.IsActive ? "true" : "false";
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"The User's Status Has Just Been Changed to {(user.IsActive ? $"Activated" : $"Deactivated")}"
            };
        }
    }
}
