using AutoMapper;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationAboutByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContactByUsername;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername;
using galaxypremiere.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.Profiles
{
    public class ProfilesMappingProfile : Profile
    {
        public ProfilesMappingProfile()
        {
            CreateMap<Domain.Entities.Users.UsersInformation, GetUsersInformationByUsernameServiceDto>()
                .ForMember(dest => dest.AccountType, act => act.MapFrom(src => ChangeAccountType(src.AccountType)))
                .ReverseMap();
            CreateMap<Domain.Entities.Users.UsersInformation, GetUsersInformationAboutByUsernameServiceDto>()
                .ForMember(dest => dest.Fullname, act => act.MapFrom(src => $"{src.Firstname} {src.MiddleName} {src.Surname}"))
                .ForMember(dest => dest.GenderText, act => act.MapFrom(src => ChangeGender(src.Gender)))
                .ForMember(dest => dest.Age, act => act.MapFrom(src => CalcAge(src.BirthDay)))
                .ReverseMap();
            CreateMap<Domain.Entities.Users.UsersAddress, GetUsersInformationContactByUsernameServiceDto>()
                .ReverseMap();
            CreateMap<Domain.Entities.Users.UsersPhotos, GetUsersInformationPhotosByUsernameServiceDto>()
                .ReverseMap();
        }
        private string CalcAge(string? birtday)
        {
            if (birtday != null)
            {
                string year = Convert.ToDateTime(birtday).ToString("yyyy");
                string now = DateTime.Now.Year.ToString();
                return (Int64.Parse(now) - Int64.Parse(year)).ToString();
            }
            else
                return "0";
        }
        private string ChangeGender(byte gender)
        {
            string value = string.Empty;
            foreach (var field in typeof(GenderConstants).GetFields())
            {
                if (field.IsLiteral && field.FieldType == typeof(byte) && (byte)field.GetRawConstantValue() == gender)
                {
                    value = field.Name;
                    break;
                }
            }
            return value;
        }
        private string ChangeAccountType(byte type)
        {
            string value = string.Empty;
            foreach (var field in typeof(AccountTypeConstants).GetFields())
            {
                if (field.IsLiteral && field.FieldType == typeof(byte) && (byte)field.GetRawConstantValue() == type)
                {
                    value = field.Name;
                    break;
                }
            }
            return value;
        }
    }
}
