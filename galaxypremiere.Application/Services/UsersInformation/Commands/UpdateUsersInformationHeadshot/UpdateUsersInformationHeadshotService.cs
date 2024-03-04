using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Services.UploadPhoto;
using galaxypremiere.Application.Services.UploadSmallFiles;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO;
using galaxypremiere.Common.DTOs;
using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeadshot
{
    public class UpdateUsersInformationHeadshotService : IUpdateUsersInformationHeadshotService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateUsersInformationHeadshotService(
            IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestUpdateUsersInformationHeadshotServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Something went wrong."
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var userHeadshot = _context
                                  .UsersInformation
                                  .Where(u => u.UsersId == req.UsersId).FirstOrDefault();
                if (userHeadshot == null) // Create for first time! (INSERT)
                {
                    galaxypremiere.Domain.Entities.Users.UsersInformation usersInfo
                        = new galaxypremiere.Domain.Entities.Users.UsersInformation();
                    usersInfo = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersInformation>(req);
                    //========================= Upload Headshot
                    var file = CreateFilename(req.Photo, req.UsersId);
                    switch (file.Success)
                    {
                        case true:
                            usersInfo.Photo = file.Filename;
                            break;
                        case false:
                            return new ResultDto
                            {
                                IsSuccess = false,
                                Message = file.Message,
                            };
                    }
                    //=========================
                    _context.UsersInformation.Add(usersInfo);
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Headshot has just been updated successfully.1"
                    };
                }
                else // The user already existed (UPDATE)
                {

                    var mappedDto = _mapper.Map<RequestUpdateUsersInformationHeadshotServiceDto>(req);
                    _mapper.Map(mappedDto, userHeadshot);
                    //========================= Upload Headshot
                    var file = CreateFilename(req.Photo, req.UsersId);
                    switch (file.Success)
                    {
                        case true:
                            userHeadshot.Photo = file.Filename;
                            break;
                        case false:
                            return new ResultDto
                            {
                                IsSuccess = false,
                                Message = file.Message,
                            };
                    }
                    //=========================
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Headshot has just been updated successfully.2"
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user doesn not exist."
                };
            }
        }
        private ResultUploadDto CreateFilename(IFormFile file, long userId)
        {
            UploadPhotoService uploadPhotoService = new UploadPhotoService();
            var filename = uploadPhotoService.UploadFile(new RequestUploadPhotoServiceDto
            {
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "user-headshot",
                Extension = new string[] { ".jpg", ".png", ".bmp", ".jpeg" }, // always must be in way of lowerCase()s
                FileSize = "2097152", // => 2 Mb
                File = file,
                UsersId = userId,
                Scales = new Dictionary<string, string>
                        {
                        {"original","600" },
                        {"thumb","150" },
                        }
            });
            return filename;
        }
    }
}
