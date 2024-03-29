﻿using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPrivacy
{
    public class UpdateUsersInformationPrivacyService : IUpdateUsersInformationPrivacyService
    {
        private readonly IDataBaseContext _context;
        public UpdateUsersInformationPrivacyService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestUpdateUsersInformationPrivcayServiceDto req)
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
                var userInfo = _context
                   .UsersInformation
                   .Where(u => u.UsersId == req.UsersId).FirstOrDefault();
                if (userInfo == null) // Create for first time! (INSERT)
                {
                    galaxypremiere.Domain.Entities.Users.UsersInformation userPrivacy
                        = new galaxypremiere.Domain.Entities.Users.UsersInformation();
                    userPrivacy.UsersId = req.UsersId;
                    userPrivacy.Privacy = req.Privacy;
                    _context.UsersInformation.Add(userPrivacy);
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been update successfully.1"
                    };
                }
                else // The user already existed (UPDATE)
                {
                    userInfo.Privacy = req.Privacy;
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been update successfully.2"
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user does not exist",
                };
            }
        }
    }
}
