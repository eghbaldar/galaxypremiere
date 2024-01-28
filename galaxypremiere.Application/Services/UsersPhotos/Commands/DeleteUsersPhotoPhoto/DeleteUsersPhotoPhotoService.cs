﻿using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoPhoto
{
    public class DeleteUsersPhotoPhotoService : IDeleteUsersPhotoPhotoService
    {
        private readonly IDataBaseContext _context;
        public DeleteUsersPhotoPhotoService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestDeleteUsersPhotoPhotoServiceDto req)
        {
            if (req == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "Something went wrong"
                };
            }
            var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
            if (user != null)
            {
                var photo = _context.UsersPhotos.Where(ue => ue.Id == req.Id).FirstOrDefault();
                if (photo != null)
                {
                    _context.UsersPhotos.Remove(photo); // attention: the deletion not be happened because of changeover of DataBaseContext.cs
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
                        Message = "The photo does not exist"
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