using AutoMapper;
using galaxypremiere.Application.Services.UserLoginLog.Commands.PostUserLoginLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.UsersLoginLog
{
    public class UserLoginLogMappingProfile: Profile
    {
        public UserLoginLogMappingProfile()
        {
            CreateMap<galaxypremiere.Domain.Entities.Users.UsersLoginLog, RequestPostUserLoginLogServiceDto>().ReverseMap();
        }
    }
}
