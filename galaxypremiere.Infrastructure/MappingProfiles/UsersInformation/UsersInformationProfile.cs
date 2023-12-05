using AutoMapper;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationAccountType;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationBIO;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationContacat;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationPassword;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContact;
using galaxypremiere.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.UsersInformation
{
    public class UsersInformationProfile : Profile
    {
        public UsersInformationProfile()
        {
            CreateMap<Domain.Entities.Users.UsersInformation, RequestUpdateUsersInformationAccountDto>().ReverseMap();
            CreateMap<Domain.Entities.Users.UsersInformation, GetUsersInformationServiceDto>().ReverseMap();
            CreateMap<Domain.Entities.Users.UsersAddress, RequestUpdateUsersInformationContactServiceDto>().ReverseMap();
            CreateMap<Domain.Entities.Users.UsersAddress, GetUsersInformationContactServiceDto>().ReverseMap();
            CreateMap<Domain.Entities.Users.UsersInformation, RequestUpdateUsersInformationAccountTypeServiceDto>().ReverseMap();
            CreateMap<Domain.Entities.Users.UsersInformation, RequestUpdateUsersInformationBioServiceDto>().ReverseMap();

            PasswordHasher passwordHasher = new PasswordHasher();          
            CreateMap<RequestUpdateUsersInformationPasswordDto,Domain.Entities.Users.Users>()                 
                 .ForMember(dest => dest.Password, act => act.Ignore())
                 .BeforeMap((dto,user) =>
                 {
                     user.Password = passwordHasher.HashPassword(dto.Password);
                 })
           .ReverseMap();      
        }
    }
}
