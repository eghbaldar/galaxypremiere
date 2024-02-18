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
        public ResultDto Execute(RequestPostUsersPhotoCommentServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = ""
                };
            }
            var photo = _context.UsersPhotos.Where(p => p.Id == req.UsersPhotosId);
            if (photo.Any())
            {
                UsersPhotoComments usersPhotoComments = new UsersPhotoComments();
                usersPhotoComments = _mapper.Map<UsersPhotoComments>(req);
                usersPhotoComments.UsersId = req.UsersId;
                _context.UsersPhotoComments.Add(usersPhotoComments);
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "Successful"
                };
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The photo does not exist"
                };
            }
        }
    }
}
