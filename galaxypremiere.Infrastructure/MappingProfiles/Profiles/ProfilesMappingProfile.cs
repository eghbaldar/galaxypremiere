using AutoMapper;
using galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationByUsername;
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
                .ForMember(dest => dest.AccountType, act => act.MapFrom(src=> test()))
                .ReverseMap();
        }

        private string test()
        {
            return "342fff";
        }
        private string ChangeAccountType(byte type)
        {
            string variableName = "";
            foreach (var field in typeof(AccountTypeConstants).GetFields())
            {
                if (field.IsLiteral && field.FieldType == typeof(byte) && (byte)field.GetRawConstantValue() == type)
                {
                    variableName = field.Name;
                    break;
                }
            }
            return variableName;
        }
    }
}
