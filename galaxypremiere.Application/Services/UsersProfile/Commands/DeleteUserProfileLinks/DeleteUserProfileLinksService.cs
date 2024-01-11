using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileLinks
{
    public class DeleteUserProfileLinksService : IDeleteUserProfileLinksService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserProfileLinksService(IDataBaseContext context)
        {
            _context= context;
        }
        public ResultDto Execute(RequestDeleteUserProfileLinksServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var link = _context.UsersLinks
                    .Where(ufm => ufm.Id == req.Id && ufm.UsersId == req.UsersId).FirstOrDefault();
                if (link != null)
                {
                    _context.UsersLinks.Remove(link); // attention: the deletion not be happened because of changeover of DataBaseContext.cs
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
                        Message = "The link does not exist"
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
