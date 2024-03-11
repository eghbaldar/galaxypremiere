using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.Comments.Commands.PostComment
{
    public class PostCommentService : IPostCommentService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostCommentService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<PostCommentServiceDto> Execute(RequestPostCommentServiceDto req)
        {
            if (req == null) return new ResultDto<PostCommentServiceDto> { IsSuccess = false };
            Domain.Common.Comments _comments = new Domain.Common.Comments();
            _comments = _mapper.Map<Domain.Common.Comments>(req);
            _context.Comments.Add(_comments);
            _context.SaveChanges();
            // retirive avatar and fullname of person who is going to leave a comment
            var info = _context.UsersInformation.Where(u => u.UsersId == req.UsersId).FirstOrDefault();
            string avatar = "", fullname = "";
            if (info != null)
            {
                avatar = info.Photo;
                fullname = (info.Firstname ?? null) + (info.MiddleName ?? null) + (info.Surname ?? null);
            }
            return new ResultDto<PostCommentServiceDto>
            {
                Data = new PostCommentServiceDto
                {
                    Id = _comments.Id,
                    Avatar = avatar,
                    Fullname = fullname,
                    Email = req.Email,
                    Comment = req.Comment,

                },
                IsSuccess = true
            };
        }
    }
}
