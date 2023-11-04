using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.Users.Commands.DeleteUser
{
    public class DeleteUserService: IDeleteUserService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUserServiceDto req)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == req.IdUser);
            if (!(user == null))
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "The User Was Deleted Successfully",
                };
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "This User Does Not Exists",
                };
            }
        }
    }
}
