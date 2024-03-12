using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoComment
{
    public class PostUsersPhotoCommentService : IPostUsersPhotoCommentService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostUsersPhotoCommentService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<PostUsersPhotoCommentServiceDto> Execute(RequestPostUsersPhotoCommentServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto<PostUsersPhotoCommentServiceDto>
                {
                    IsSuccess = false,
                    Message = ""
                };
            }
            var photo = _context.UsersPhotos.Where(p => p.Id == req.UsersPhotosId);
            if (photo.Any())
            {

                // add a new comment ...
                UsersPhotoComments usersPhotoComments = new UsersPhotoComments();
                usersPhotoComments = _mapper.Map<UsersPhotoComments>(req);
                usersPhotoComments.UsersId = req.UsersId;
                _context.UsersPhotoComments.Add(usersPhotoComments);
                _context.SaveChanges();
                // retirive avatar and fullname of person who is going to leave a comment
                var info = _context.UsersInformation.Where(u => u.UsersId == req.UsersId).FirstOrDefault();
                string avatar = "", fullname = "";
                if (info != null)
                {
                    avatar = info.Photo;
                    fullname = (info.Firstname ?? null) + (info.MiddleName ?? null) + (info.Surname ?? null);
                }

                return new ResultDto<PostUsersPhotoCommentServiceDto>
                {
                    Data = new PostUsersPhotoCommentServiceDto
                    {
                        Id = usersPhotoComments.Id,
                        Avatar = avatar,
                        Fullname = fullname,
                        Email=req.Email,
                    },
                    IsSuccess = true,
                    Message = "Successful"
                };
            }
            else
            {
                return new ResultDto<PostUsersPhotoCommentServiceDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The photo does not exist"
                };
            }
        }
    }
}
