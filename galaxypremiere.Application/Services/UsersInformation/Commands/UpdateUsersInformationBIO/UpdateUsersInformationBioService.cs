using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System;
using System.Linq;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO
{
    public class UpdateUsersInformationBioService : IUpdateUsersInformationBioService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateUsersInformationBioService(
            IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestUpdateUsersInformationBioServiceDto req)
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
                var userBIO = _context
                    .UsersInformation
                    .Where(u => u.UsersId == req.UsersId).FirstOrDefault();
                // to check the match of entered position code with database ones
                int[] intArray;
                if (req.Position != null)
                {
                    intArray = req.Position.Split(',')
                        .Where(x => !string.IsNullOrEmpty(x))
                        .Select(int.Parse)
                        .ToArray();

                    if (checkPositions(intArray))
                    {
                        return new ResultDto
                        {
                            IsSuccess = false,
                            Message = "One of the item is invalid.",
                        };
                    }
                }
                else
                    intArray = null;

                if (userBIO == null) // Create for first time! (INSERT)
                {
                    galaxypremiere.Domain.Entities.Users.UsersInformation usersInfo
                        = new galaxypremiere.Domain.Entities.Users.UsersInformation();
                    usersInfo = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersInformation>(req);
                    if (intArray != null) usersInfo.Position = string.Join(",", intArray);
                    _context.UsersInformation.Add(usersInfo);
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been updated successfully.1"
                    };
                }
                else // The user already existed (UPDATE)
                {
                    var mappedDto = _mapper.Map<RequestUpdateUsersInformationBioServiceDto>(req);
                    if (intArray != null) mappedDto.Position = string.Join(",", intArray);
                    _mapper.Map(mappedDto, userBIO);
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been updated successfully.2"
                    };
                }
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "The user doesn't exist."
                };
            }
        }
        private bool checkPositions(int[] stringArray)
        {
            // this function will checking the entered position by client with database!
            var positionsFromDatabase = _context.UsersPositions.Select(x => x.Id).ToArray();
            return stringArray.Any(x=> !positionsFromDatabase.Contains(x));
        }
    }
}
