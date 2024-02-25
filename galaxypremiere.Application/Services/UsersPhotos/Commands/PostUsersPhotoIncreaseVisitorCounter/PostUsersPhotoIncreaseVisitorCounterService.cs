using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoIncreaseVisitorCounter
{
    public class PostUsersPhotoIncreaseVisitorCounterService : IPostUsersPhotoIncreaseVisitorCounterService
    {
        private readonly IDataBaseContext _context;
        public PostUsersPhotoIncreaseVisitorCounterService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<PostUsersPhotoIncreaseVisitorCounterServiceDto> Execute(RequestPostUsersPhotoIncreaseVisitorCounterServiceDto req)
        {
            if (req == null) return new ResultDto<PostUsersPhotoIncreaseVisitorCounterServiceDto> { Data=null, IsSuccess = false };
            var photo = _context.UsersPhotos.Where(p => p.Id == req.PhotoId).FirstOrDefault();
            photo.VisitorCounter += 1;
            _context.SaveChanges();
            return new ResultDto<PostUsersPhotoIncreaseVisitorCounterServiceDto>
            {
                Data = new PostUsersPhotoIncreaseVisitorCounterServiceDto
                {
                    VisitorCounter=photo.VisitorCounter,
                },
                IsSuccess = true,
            };
        }
    }
}
