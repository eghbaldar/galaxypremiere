using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.Likes.Commands.PostLike
{
    public class PostLikeService : IPostLikeService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostLikeService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<bool> Execute(RequestPostLikeServiceDto req)
        {
            if (req == null) return new ResultDto<bool> { IsSuccess = false };

            var likeThisUser = _context.Likes
                .Where(l => l.Section == req.Section
                && l.UsersId == req.UsersId
                && l.SectionId == req.SectionId
                && l.DeleteTime == null) 
                .ToList();

            if (likeThisUser == null || likeThisUser.Count == 0) // Like
            {
                Insert(req);
                return new ResultDto<bool> { Data = true, IsSuccess = true };
            }
            else  // unLike
            {
                foreach (var row in likeThisUser) row.DeleteTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto<bool> { Data = false, IsSuccess = true };
            }
        }

        private void Insert(RequestPostLikeServiceDto req)
        {
            galaxypremiere.Domain.Common.Likes likes = new galaxypremiere.Domain.Common.Likes();
            likes = _mapper.Map<galaxypremiere.Domain.Common.Likes>(req);
            _context.Likes.Add(likes);
            _context.SaveChanges();
        }
    }
}
