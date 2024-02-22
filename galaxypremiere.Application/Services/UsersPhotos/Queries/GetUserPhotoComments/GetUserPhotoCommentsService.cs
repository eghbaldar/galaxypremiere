using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPhotos.Queries.GetUserPhotoComments
{
    public class GetUserPhotoCommentsService : IGetUserPhotoCommentsService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUserPhotoCommentsService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<ResultGetUserPhotoCommentsServiceDto> Execute(RequestGetUserPhotoCommentsServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultGetUserPhotoCommentsServiceDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "successfull"
                };
            }
            var photo = _context.UsersPhotos.Where(p => p.Id == req.Id);
            if (photo.Any())
            {
                var comments = (
                    from c in _context.UsersPhotoComments
                    join info in _context.UsersInformation on c.UsersId equals info.UsersId into infoGroup
                    from info in infoGroup.DefaultIfEmpty()
                    join user in _context.Users on c.UsersId equals user.Id into userGroup
                    from user in userGroup.DefaultIfEmpty()
                    where (c.UsersPhotosId == req.Id)
                    select new
                    {
                        Comments = c,
                        information = info,
                        Email = user.Email,
                        AllowToRemove = (c.UsersId.Equals(req.UserId)) ? true : false,
                    }
                    )
                    .Select(x => new GetUserPhotoCommentsServiceDto
                    {
                        Id = x.Comments.Id,
                        Username = x.information.Username,
                        Avatar = (x.information.Photo ?? null),
                        Comment = x.Comments.Comment,
                        InsertDate = x.Comments.InsertDate,
                        Email = x.Email,
                        Fullname = (x.information.Firstname ?? null) + (x.information.MiddleName ?? null) + (x.information.Surname ?? null),
                        AllowToRemove = x.AllowToRemove,
                    })
                    .OrderBy(x => x.InsertDate)
                    .ToList();
                return new ResultDto<ResultGetUserPhotoCommentsServiceDto>
                {
                    Data = new ResultGetUserPhotoCommentsServiceDto
                    {
                        resultGetUserPhotoCommentsServiceDto = comments,
                    },
                    IsSuccess = true,
                    Message = "successfull"
                };
            }
            else
            {
                return new ResultDto<ResultGetUserPhotoCommentsServiceDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "successfull"
                };
            }
        }
    }
}
