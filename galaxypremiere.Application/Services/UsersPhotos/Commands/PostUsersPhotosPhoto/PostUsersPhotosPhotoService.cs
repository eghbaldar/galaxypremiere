using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Services.UploadSmallFiles;
using galaxypremiere.Common.DTOs;
using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosPhoto
{
    public class PostUsersPhotosPhotoService : IPostUsersPhotosPhotoService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostUsersPhotosPhotoService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto<ResultPostUsersPhotosPhotoServiceDto> Execute(RequestPostUsersPhotosPhotoServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto<ResultPostUsersPhotosPhotoServiceDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                galaxypremiere.Domain.Entities.Users.UsersPhotos usersPhotos
                    = new galaxypremiere.Domain.Entities.Users.UsersPhotos();
                usersPhotos = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersPhotos>(req);
                //========================= Upload Headshot
                var file = CreateFilename(req.Photo,req.UsersId);
                switch (file.Success)
                {
                    case true:
                        usersPhotos.Filename = file.Filename;
                        break;
                    case false:
                        return new ResultDto<ResultPostUsersPhotosPhotoServiceDto>
                        {
                            Data = null,
                            IsSuccess = false,
                            Message = file.Message,
                        };
                }
                //=========================
                _context.UsersPhotos.Add(usersPhotos);
                _context.SaveChanges();

                return new ResultDto<ResultPostUsersPhotosPhotoServiceDto>
                {
                    Data = new ResultPostUsersPhotosPhotoServiceDto
                    {
                        AlbumId = req.UsersAlbumsId,
                        Filename = file.Filename,
                        PhotoId= usersPhotos.Id,
                    },
                    IsSuccess = true,
                    Message = "Photo has just been updated successfully.1"
                };
            }
            else
            {
                return new ResultDto<ResultPostUsersPhotosPhotoServiceDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "The user doesn not exist."
                };
            }
        }
        private ResultUploadDto CreateFilename(IFormFile file, long userId)
        {
            UploadSmallFilesService uploadSmallFilesService = new UploadSmallFilesService();
            var filename = uploadSmallFilesService.UploadFile(new RequestUploadSmallFilesServiceDto
            {
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "user-photos",
                Exension = new string[] { ".jpg", ".png", ".bmp", ".jpeg" }, // always must be in way of lowerCase()s
                FileSize = "2097152", // => 2 Mb
                File = file,
                UsersId= userId,
            });
            return filename;
        }
    }
}
