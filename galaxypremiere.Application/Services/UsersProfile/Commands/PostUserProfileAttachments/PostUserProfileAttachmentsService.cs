using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Services.UploadSmallFiles;
using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileAttachments
{
    public class PostUserProfileAttachmentsService : IPostUserProfileAttachmentsService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _imapper;
        public PostUserProfileAttachmentsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPostUserProfileAttachmentServiceDto req)
        {
            if (req.Title == null || req.File == null)
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
                UsersAttachments usersAttachments = new UsersAttachments();
                usersAttachments.UsersId = req.UsersId;
                usersAttachments.Title = req.Title;
                //========================= Upload Headshot
                var file = CreateFilename(req.File);
                switch (file.Success)
                {
                    case true:
                        usersAttachments.Filename = file.Filename;
                        break;
                    case false:
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = file.Message,
                        };
                }
                //=========================
                _context.UsersAttachments.Add(usersAttachments);
                _context.SaveChanges();

                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "Attachment has just been updated successfully.1"
                };
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist."
                };
            }
        }
        private ResultUploadDto CreateFilename(IFormFile file)
        {
            UploadSmallFilesService uploadSmallFilesService = new UploadSmallFilesService();
            var filename = uploadSmallFilesService.UploadFile(new RequestUploadSmallFilesServiceDto
            {
                DirectoryNameLevelParent = "files",
                DirectoryNameLevelChild = "user-attachments",
                Exension = new string[] { ".txt", ".docx", ".doc", ".pdf", ".jpg", ".png" }, // always must be in way of lowerCase()s
                FileSize = "2097152", // => 2 Mb
                File = file,
            });
            return filename;
        }
    }
}
