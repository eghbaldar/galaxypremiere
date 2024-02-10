using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Services.UploadSmallFiles;
using galaxypremiere.Common.DTOs;
using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationHeader
{
    public class UpdateUsersInformationHeaderService: IUpdateUsersInformationHeaderService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateUsersInformationHeaderService(
            IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestUpdateUsersInformationHeaderServiceDto req)
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
                var userHeader = _context
                  .UsersInformation
                  .Where(u => u.UsersId == req.UsersId).FirstOrDefault();
                if (userHeader == null) // Create for first time! (INSERT)
                {
                    galaxypremiere.Domain.Entities.Users.UsersInformation usersInfo
                        = new galaxypremiere.Domain.Entities.Users.UsersInformation();
                    usersInfo = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersInformation>(req);
                    //========================= Upload Headshot
                    var file = CreateFilename(req.Header,req.UsersId);
                    switch (file.Success)
                    {
                        case true:
                            usersInfo.Header = file.Filename;
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
                        Message = "Header has just been updated successfully.1"
                    };
                }
                else // The user already existed (UPDATE)
                {
                    var mappedDto = _mapper.Map<RequestUpdateUsersInformationHeaderServiceDto>(req);
                    _mapper.Map(mappedDto, userHeader);
                    //========================= Upload Headshot
                    var file = CreateFilename(req.Header, req.UsersId);
                    switch (file.Success)
                    {
                        case true:
                            userHeader.Header = file.Filename;
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
                        Message = "Header has just been updated successfully.2"
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

        private ResultUploadDto CreateFilename(IFormFile file,long userId)
        {
            UploadSmallFilesService uploadSmallFilesService = new UploadSmallFilesService();
            var filename = uploadSmallFilesService.UploadFile(new RequestUploadSmallFilesServiceDto
            {
                DirectoryNameLevelParent = "images",
                DirectoryNameLevelChild = "user-header",
                Exension = new string[] { ".jpg", ".png", ".bmp", ".jpeg" }, // always must be in way of lowerCase()s
                FileSize = "5242880", // => 5 Mb
                File = file,
                UsersId=userId,
            });
            return filename;
        }
    }
}
