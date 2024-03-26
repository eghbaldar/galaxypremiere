using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPostArchive
{
    public class UpdateUsersPostArchiveService : IUpdateUsersPostArchiveService
    {
        private readonly IDataBaseContext _context;
        public UpdateUsersPostArchiveService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUsersPostArchiveServiceDto req)
        {
            if (req == null) return new ResultDto { IsSuccess = false };
            var post = _context.UsersPosts.Where(p => p.Id==req.Id).First();
            if (post != null)
            {
                post.Archive = true;
                _context.SaveChanges();
                return new ResultDto { IsSuccess = true };
            }
            else return new ResultDto { IsSuccess = false };
        }
    }
}