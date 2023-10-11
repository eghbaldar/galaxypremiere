using AutoMapper;
using galaxypremiere.Application.Services.Users.Commands.PostUser;
using galaxypremiere.Application.Services.Users.Commands.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.Users
{
    public class UsersMappingProfile: Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<Domain.Entities.Users.Users, RequestPostUserServiceDto>().ReverseMap();
            CreateMap<Domain.Entities.Users.Users, RequestUpdateUserServiceDto>().ReverseMap();
        }
    }
}
