using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Services.UploadPhoto;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost
{
    public class PostUsersPostService : IPostUsersPostService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostUsersPostService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestPostUsersPostServiceDto req)
        {
            if (req == null) return new ResultDto { IsSuccess = false };
            galaxypremiere.Domain.Entities.Users.UsersPosts usersPosts = new galaxypremiere.Domain.Entities.Users.UsersPosts();            
            usersPosts = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersPosts>(req);
            _context.UsersPosts.Add(usersPosts);
            if (req.Photos != null && req.Photos.Count > 0)
            {
                if (req.Photos.Count > 4) { return new ResultDto { IsSuccess = false }; }
                foreach (var photo in req.Photos)
                {
                    galaxypremiere.Domain.Entities.Users.UsersPostsPhotos usersPostPhotos = new galaxypremiere.Domain.Entities.Users.UsersPostsPhotos();
                    usersPostPhotos.UsersPostsId = usersPosts.Id;
                    //========================= Upload
                    var file = CreateFilename(photo, req.UsersId);
                    switch (file.Success)
                    {
                        case true:
                            usersPostPhotos.Filename = file.Filename;
                            break;
                        case false:
                            return new ResultDto { IsSuccess = false };
                    }
                    //========================= 
                    //usersPostPhotos.Filename = photo.FileName;
                    _context.UsersPostsPhotos.Add(usersPostPhotos);                    
                }                
            }
            _context.SaveChanges();
            return new ResultDto { IsSuccess = true };
        }
        private ResultUploadDto CreateFilename(IFormFile file, long userId)
        {
            UploadPhotoService uploadPhotoService = new UploadPhotoService();
            var filename = uploadPhotoService.UploadFile(new RequestUploadPhotoServiceDto
            {
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "user-post-photos",
                Extension = new string[] { ".jpg", ".png", ".bmp", ".jpeg" }, // always must be in way of lowerCase()s
                FileSize = "2097152", // => 2 Mb
                File = file,
                UsersId = userId,
                Scales = new Dictionary<string, string>
                        {
                        {"original","700" },
                        {"thumb","250" },
                        }
            });
            return filename;
        }
    }
}
