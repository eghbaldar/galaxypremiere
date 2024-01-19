using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoPhotos
{
    public class GetUsersPhotoPhotosService : IGetUsersPhotoPhotosService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _imapper;
        public GetUsersPhotoPhotosService(IDataBaseContext context, IMapper imapper)
        {
            _context = context;
            _imapper = imapper;
        }
        public ResultDto<ResultGetUsersPhotoPhotosServiceDto> Execute(RequestGetUsersPhotoPhotosServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultGetUsersPhotoPhotosServiceDto>
                {
                    Data = new ResultGetUsersPhotoPhotosServiceDto
                    {
                        resultGetUsersPhotoPhotosServiceDto = null,
                    },
                    IsSuccess = false,
                    Message = "Something went wrong.",
                };
            }

            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                if (req.AlbumId != null) // GET PHOTOS BY ALBUMID
                {
                    var album = _context.UsersAlbums
                        .Where(al => al.UsersId == req.UsersId && al.Id == req.AlbumId)
                        .FirstOrDefault();
                    if (album!=null)
                    {
                        var photos = _context.UsersPhotos
                            .Where(p=>p.UsersAlbumsId==req.AlbumId)
                            .OrderBy(p=>p.InsertDate)
                            .ToList();
                        return new ResultDto<ResultGetUsersPhotoPhotosServiceDto>
                        {
                            Data = new ResultGetUsersPhotoPhotosServiceDto
                            {
                                resultGetUsersPhotoPhotosServiceDto = new List<GetUsersPhotoPhotosServiceDto>()
                                {
                                    new GetUsersPhotoPhotosServiceDto
                                    {
                                        Filename=photos.First().Filename,
                                        PhotoId=photos.First().Id,
                                    }
                                }
                            },
                            IsSuccess = true,
                            Message = "Successful",
                        };
                    }
                    else
                    {
                        return new ResultDto<ResultGetUsersPhotoPhotosServiceDto>
                        {
                            Data = new ResultGetUsersPhotoPhotosServiceDto
                            {
                                resultGetUsersPhotoPhotosServiceDto = null,
                            },
                            IsSuccess = false,
                            Message = "There is no an album with this attribute.",
                        };
                    }
                }
                else // GET ALL PHOTOS
                {
                    var album = _context.UsersAlbums
                        .Where(al => al.UsersId == req.UsersId)
                        .Select(al => new { al.Id,al.UsersId })                        
                        .ToList();
                    if (album != null)
                    {
                        var photos = _context.UsersPhotos
                            .Where(p => p.UsersAlbumsId == album[0].Id)
                            .OrderBy(p => p.InsertDate)
                            .Select(p => _imapper.Map<GetUsersPhotoPhotosServiceDto>(p))                            
                            .ToList();
                        return new ResultDto<ResultGetUsersPhotoPhotosServiceDto>
                        {
                            Data = new ResultGetUsersPhotoPhotosServiceDto
                            {
                                resultGetUsersPhotoPhotosServiceDto = photos
                            },
                            IsSuccess = true,
                            Message = "Successful",
                        };
                    }
                    else
                    {
                        return new ResultDto<ResultGetUsersPhotoPhotosServiceDto>
                        {
                            Data = new ResultGetUsersPhotoPhotosServiceDto
                            {
                                resultGetUsersPhotoPhotosServiceDto = null,
                            },
                            IsSuccess = false,
                            Message = "There is no an album with this attribute.",
                        };
                    }
                }                
            }
            else
            {
                return new ResultDto<ResultGetUsersPhotoPhotosServiceDto>
                {
                    Data = new ResultGetUsersPhotoPhotosServiceDto
                    {
                        resultGetUsersPhotoPhotosServiceDto = null,
                    },
                    IsSuccess = false,
                    Message = "The user does not exist.",
                };
            }
        }
    }
}
