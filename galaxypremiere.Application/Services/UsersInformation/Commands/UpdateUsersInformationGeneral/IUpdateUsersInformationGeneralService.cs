using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral
{
    public class RequestUpdateUsersInformationGeneralDto
    {
        public long UsersId { get; set; }
        public string? Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public byte Gender { get; set; } = 0; // Check: [GenderConstants.cs]
        public int CountryId { get; set; } = 0; // derived from [Countries] entity
        public int LanguageId { get; set; }
        public string? BirthYear { get; set; } // 1989
        public string? BirthMonth { get; set; } // 09
        public string? BirthDay { get; set; } // 02
        public string? BirthCity { get; set; }
        public string? CurrentCity { get; set; }
    }
    public interface IUpdateUsersInformationGeneralService
    {
        ResultDto Execute(RequestUpdateUsersInformationGeneralDto req);
    }
    public class UsersInformationService : IUpdateUsersInformationGeneralService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UsersInformationService(IDataBaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDto Execute(RequestUpdateUsersInformationGeneralDto req)
        {
            try
            {
                var userInfo = _context.UsersInformation.Where(u => u.UsersId == req.UsersId).FirstOrDefault();
                if (userInfo == null) // Create for first time! (INSERT)
                {
                    galaxypremiere.Domain.Entities.Users.UsersInformation usersInformation
                        = new galaxypremiere.Domain.Entities.Users.UsersInformation();
                    usersInformation = _mapper.Map<galaxypremiere.Domain.Entities.Users.UsersInformation>(req);
                    _context.UsersInformation.Add(usersInformation);
                    _context.SaveChanges();

                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "Information has just been update successfully.1"
                    };
                }
                else // The user already existed (UPDATE)
                {
                    var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
                    if (user != null)
                    {
                        return new ResultDto
                        {
                            IsSuccess = true,
                            Message = "Information has just been update successfully.2"
                        };
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
            }
            catch(Exception ex)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
