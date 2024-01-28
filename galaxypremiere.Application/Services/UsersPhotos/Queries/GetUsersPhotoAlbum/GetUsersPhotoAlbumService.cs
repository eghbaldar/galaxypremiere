using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum
{
    public class GetUsersPhotoAlbumService : IGetUsersPhotoAlbumService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _imapper;
        public GetUsersPhotoAlbumService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _imapper = mapper;
        }
        public ResultDto<ResultGetUsersPhotoAlbumServiceDto> Execute(RequestGetUsersPhotoAlbumServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultGetUsersPhotoAlbumServiceDto>
                {
                    Data = new ResultGetUsersPhotoAlbumServiceDto
                    {
                        resultGetUsersPhotoAlbumServiceDto = null,
                    },
                    IsSuccess = false,
                    Message = "Something went wrong.",
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var result = _context.UsersAlbums
                    .Where(e => e.UsersId == req.UsersId)
                    .Include(t => t.UsersPhotos)
                    .Select( //_imapper.Map<GetUsersPhotoAlbumServiceDto>(al)
                    al => new GetUsersPhotoAlbumServiceDto
                    {
                        Id = al.Id,
                        RandomPhoto = al.UsersPhotos.Select(x => x.Filename).OrderBy(_ => Guid.NewGuid()).FirstOrDefault(),
                        Title = al.Title,
                    }
                    ).ToList();

                return new ResultDto<ResultGetUsersPhotoAlbumServiceDto>
                {
                    Data = new ResultGetUsersPhotoAlbumServiceDto
                    {
                        resultGetUsersPhotoAlbumServiceDto = result,
                    },
                    IsSuccess = true,
                    Message = "Everything went Okay.",
                };
            }
            else
            {
                return new ResultDto<ResultGetUsersPhotoAlbumServiceDto>
                {
                    Data = new ResultGetUsersPhotoAlbumServiceDto
                    {
                        resultGetUsersPhotoAlbumServiceDto = null,
                    },
                    IsSuccess = false,
                    Message = "The user does not exist.",
                };
            }
        }
    }
}
