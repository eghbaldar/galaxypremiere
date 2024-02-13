using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername
{
    public class RequestGetUsersInformationContactByUsernameServiceDto
    {
        public string Username { get; set; }
    }
    public class GetUsersInformationContactByUsernameServiceDto
    {
        public int CountryId { get; set; } = 0; // derived from [Countries] entity
        public string CountryName { get; set; }
        public string? Address1 { get; set; } //line1
        public string? Address2 { get; set; } //lien2
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? RecoveryEmail { get; set; }
        public string? Website { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Stage32 { get; set; }
        public string? Youtube { get; set; }
        public string? Linkden { get; set; }
        public string? Vimeo { get; set; }
        public string? Imdb { get; set; }
    }
    public class ResultGetUsersInformationContactByUsernameServiceDto
    {
        public ResultDto<GetUsersInformationContactByUsernameServiceDto> resultGetUsersInformationContactByUsernameServiceDto { get; set; }
    }
    public interface IGetUsersInformationContactByUsernameService
    {
        ResultGetUsersInformationContactByUsernameServiceDto Execute(RequestGetUsersInformationContactByUsernameServiceDto req);
    }
    public class GetUsersInformationContactByUsernameService : IGetUsersInformationContactByUsernameService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetUsersInformationContactByUsernameService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultGetUsersInformationContactByUsernameServiceDto Execute(RequestGetUsersInformationContactByUsernameServiceDto req)
        {
            if (req == null)
                return new ResultGetUsersInformationContactByUsernameServiceDto
                {
                    resultGetUsersInformationContactByUsernameServiceDto = new ResultDto<GetUsersInformationContactByUsernameServiceDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "The information is not loaded, something went wrong.",
                    }
                };
            var userContact = (
                from i in _context.UsersAddress
                    join country in _context.Countries on i.CountryId equals country.Id into countryGroup
                        from country in countryGroup.DefaultIfEmpty()
                    join info in _context.UsersInformation on i.UsersId equals info.UsersId into infoGroup
                        from info in infoGroup.DefaultIfEmpty()
                where (info.Username == req.Username)
            select new
            {
                UserContact = i,
                CountryName = country.Name,
            }
            ).FirstOrDefault();
            if (userContact != null)
            {
                var mappedUserContact = _mapper.Map<GetUsersInformationContactByUsernameServiceDto>(userContact.UserContact);
                mappedUserContact.CountryName = userContact.CountryName;

                return new ResultGetUsersInformationContactByUsernameServiceDto
                {
                    resultGetUsersInformationContactByUsernameServiceDto = new ResultDto<GetUsersInformationContactByUsernameServiceDto>
                    {
                        Data = mappedUserContact,
                        IsSuccess = true,
                        Message = "Success!",
                    }
                };
            }
            else
            {
                return new ResultGetUsersInformationContactByUsernameServiceDto
                {
                    resultGetUsersInformationContactByUsernameServiceDto = new ResultDto<GetUsersInformationContactByUsernameServiceDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "The information is not loaded, something went wrong.",
                    }
                };
            }
        }
    }
}
