using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileNews
{
    public class DeleteUserProfileNewsService: IDeleteUserProfileNewsService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserProfileNewsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUserProfileNewsServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var news = _context.UsersNews
                    .Where(ufm => ufm.Id == req.Id && ufm.UsersId == req.UsersId).FirstOrDefault();
                if (news != null)
                {
                    _context.UsersNews.Remove(news); // attention: the deletion not be happened because of changeover of DataBaseContext.cs
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
                        Message = "The favorite movie does not exist"
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
