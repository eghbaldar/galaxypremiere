using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.UpdateUsersPhotosAlbumRename
{
    public class RequestUpdateUsersPhotosAlbumRenameServiceDto
    {
        public long UsersId{ get; set; }
        public Guid  Id { get; set; }
        public string Title { get; set; }
    }
    public interface IUpdateUsersPhotosAlbumRenameService
    {
        ResultDto Execute(RequestUpdateUsersPhotosAlbumRenameServiceDto req);
    }
    public class UpdateUsersPhotosAlbumRenameService : IUpdateUsersPhotosAlbumRenameService
    {
        private readonly IDataBaseContext _context;
        public UpdateUsersPhotosAlbumRenameService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUsersPhotosAlbumRenameServiceDto req)
        {
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var album = _context.UsersAlbums
                    .Where(ue => ue.Id == req.Id && ue.UsersId == req.UsersId).FirstOrDefault();
                if (album != null)
                {
                    album.Title= req.Title;
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "The information have been updated"
                    };
                }
                else
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "The album does not exist"
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist"
                };
            }
        }
    }
}
