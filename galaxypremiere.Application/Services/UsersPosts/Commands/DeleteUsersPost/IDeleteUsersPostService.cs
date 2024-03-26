using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPosts.Commands.DeleteUsersPost
{
    public class RequestDeleteUsersPostServiceDto
    {
        public Guid Id { get; set; } // Id Post
    }
    public interface IDeleteUsersPostService
    {
        ResultDto Execute(RequestDeleteUsersPostServiceDto req);
    }
    public class DeleteUsersPostService : IDeleteUsersPostService
    {
        private readonly IDataBaseContext _context;
        public DeleteUsersPostService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUsersPostServiceDto req)
        {
            if (req == null) return new ResultDto { IsSuccess = false };
            var post = _context.UsersPosts.Where(p => p.Id == req.Id).First();
            if (post != null)
            {
                post.DeleteDate = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto { IsSuccess = true };
            }
            else return new ResultDto { IsSuccess = false };
        }
    }
}
