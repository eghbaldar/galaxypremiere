using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.Comments.Commands.DeleteComment
{
    public class DeleteCommentService : IDeleteCommentService
    {
        private readonly IDataBaseContext _context;
        public DeleteCommentService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteCommentServiceDto req)
        {
            if (req == null) return new ResultDto { IsSuccess = false };
            var comment = _context.Comments.Where(c => c.Id == req.Id && c.Section == req.Section).FirstOrDefault();
            if(comment!=null)
            {
                comment.DeleteTime= DateTime.Now;
                _context.SaveChanges();
                return new ResultDto { IsSuccess = true };
            }
            else return new ResultDto { IsSuccess = false};
        }
    }
}
