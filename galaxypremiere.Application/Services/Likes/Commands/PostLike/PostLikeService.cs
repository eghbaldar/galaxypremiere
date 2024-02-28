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
        public ResultDto Execute(RequestPostLikeServiceDto req)
        {
            if (req == null) return new ResultDto { IsSuccess = false };
            galaxypremiere.Domain.Common.Likes likes = new galaxypremiere.Domain.Common.Likes();
            likes = _mapper.Map<galaxypremiere.Domain.Common.Likes>(req);
            _context.Likes.Add(likes);
            _context.SaveChanges();
            return new ResultDto { IsSuccess = true };
        }
    }
}
