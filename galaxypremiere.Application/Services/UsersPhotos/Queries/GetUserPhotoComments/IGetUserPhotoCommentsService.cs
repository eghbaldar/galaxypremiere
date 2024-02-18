using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Queries.GetUserPhotoComments
{
    public class RequestGetUserPhotoCommentsServiceDto
    {
        public Guid Id { get; set; } // Photo Id
    }
    public class GetUserPhotoCommentsServiceDto
    {
        public string Comment { get; set; }
        public DateTime InsertDate { get; set; }
        public string? Username{ get; set; } // "The username of the person who made the comment (if applicable)"
        public string? Avatar { get; set; } // "The avatar of the person who made the comment (if applicable)"
    }
    public class ResultGetUserPhotoCommentsServiceDto
    {
        public List<GetUserPhotoCommentsServiceDto> resultGetUserPhotoCommentsServiceDto { get; set; }
    }
    public interface IGetUserPhotoCommentsService
    {
        ResultGetUserPhotoCommentsServiceDto Execute(RequestGetUserPhotoCommentsServiceDto req);
    }
    public class GetUserPhotoCommentsService: IGetUserPhotoCommentsService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUserPhotoCommentsService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultGetUserPhotoCommentsServiceDto Execute(RequestGetUserPhotoCommentsServiceDto req)
        {
            if (req == null)
            {
                return new ResultGetUserPhotoCommentsServiceDto
                {
                    resultGetUserPhotoCommentsServiceDto = null,
                };
            }
            var photo = _context.UsersPhotos.Where(p => p.Id == req.Id);
            if (photo.Any())
            {
                var comments = (
                    from c in _context.UsersPhotoComments
                    join info in _context.UsersInformation on c.UsersId equals info.UsersId into infoGroup
                    from info in infoGroup.DefaultIfEmpty()
                    where (c.UsersPhotosId == req.Id)
                    select new
                    {
                        Comments = c,
                        information = info,
                    }
                    )
                    .Select(x => new GetUserPhotoCommentsServiceDto
                    {
                        Username = x.information.Username,
                        Avatar = x.information.Photo,
                        Comment = x.Comments.Comment,
                        InsertDate = x.Comments.InsertDate,
                    })
                    .OrderBy(x=>x.InsertDate)
                    .ToList();
                return new ResultGetUserPhotoCommentsServiceDto
                {
                    resultGetUserPhotoCommentsServiceDto = comments,
                };
            }
            else
            {
                return new ResultGetUserPhotoCommentsServiceDto
                {
                    resultGetUserPhotoCommentsServiceDto = null,
                };
            }
        }
    }
}
