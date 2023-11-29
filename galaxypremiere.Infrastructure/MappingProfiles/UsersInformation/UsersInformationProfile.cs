using AutoMapper;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.UsersInformation
{
    public class UsersInformationProfile: Profile
    {
        public UsersInformationProfile()
        {
            CreateMap<Domain.Entities.Users.UsersInformation, RequestUpdateUsersInformationAccountDto>().ReverseMap();
            CreateMap<Domain.Entities.Users.UsersInformation, GetUsersInformationServiceDto>().ReverseMap();
            CreateMap<Domain.Entities.Users.UsersAddress, RequestUpdateUsersInformationContactServiceDto>().ReverseMap();
        }
    }
}
