using AutoMapper;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
using galaxypremiere.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.UsersProfile
{
    public class UserProfileMappingProfile: Profile
    {
        public UserProfileMappingProfile()
        {
            CreateMap<UsersEducation, RequestPostUserProfileEducationServiceDto>().ReverseMap();
        }
    }
}
