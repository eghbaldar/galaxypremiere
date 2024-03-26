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
            var result = (
                from user in _context.Users
                join info in _context.UsersInformation on user.Id equals info.UsersId into GroupInfo
                from info in GroupInfo.DefaultIfEmpty()
                where user.Id == req.UsersId
                select new
                {
                    User = user,
                    Info = info,
                }
                );
            string avatar = "", fullname = "";
            if (result != null)
            {
                avatar = result.First().Info.Photo;
                fullname = result.First().User.Nickname;
            }
            else return new ResultDto<PostCommentServiceDto> { IsSuccess = false, };

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
