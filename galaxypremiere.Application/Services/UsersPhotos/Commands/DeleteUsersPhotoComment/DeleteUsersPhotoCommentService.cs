using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoComment
{
    public class DeleteUsersPhotoCommentService : IDeleteUsersPhotoCommentService
    {
        private readonly IDataBaseContext _context;
        public DeleteUsersPhotoCommentService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUsersPhotoCommentServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Failed!"
                };
            }
            var comment = _context.UsersPhotoComments.Where(p => p.Id == req.Id && p.UsersId==req.UserId).FirstOrDefault();
            if (comment != null)
            {
                comment.DeleteDate = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "Succeed!"
                };
            }
            else
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Failed!"
                };
        }
    }
}
