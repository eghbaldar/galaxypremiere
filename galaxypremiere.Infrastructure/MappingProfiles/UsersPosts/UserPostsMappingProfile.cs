using AutoMapper;
using galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.UsersPosts
{
    public class UserPostsMappingProfile : Profile
    {
        public UserPostsMappingProfile()
        {
            CreateMap<galaxypremiere.Domain.Entities.Users.UsersPosts, RequestPostUsersPostServiceDto>().ReverseMap();
        }
    }
}
