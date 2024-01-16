using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.DeleteUserProfileAttachments
{
    public class DeleteUserProfileAttachmentsService : IDeleteUserProfileAttachmentsService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserProfileAttachmentsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUserProfileAttachmentsServiceDto req)
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
                var attachment = _context.UsersAttachments
                    .Where(ue => ue.Id == req.Id && ue.UsersId == req.UsersId).FirstOrDefault();
                if (attachment != null)
                {
                    _context.UsersAttachments.Remove(attachment); // attention: the deletion not be happened because of changeover of DataBaseContext.cs
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
                        Message = "The attachment does not exist"
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
