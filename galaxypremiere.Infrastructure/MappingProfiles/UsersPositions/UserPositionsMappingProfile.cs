using AutoMapper;
using galaxypremiere.Application.Services.UserPosition.Commands.PostUsersPositionSuggestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.UsersPositions
{
    public class UserPositionsMappingProfile : Profile
    {
        public UserPositionsMappingProfile()
        {
            CreateMap<RequestPostUsersPositionSuggestionServiceDto, galaxypremiere.Domain.Entities.Users.UsersPositions>()
                .ForMember(dest => dest.InsertTime, act => act.Ignore())
                .BeforeMap((dto, user) =>
                {
                    user.InsertTime = DateTime.Now;
                    user.Suggestion = 1;// 0: The user's suggestion is verifed or already existed | 1: The user's suggestion is being under considered | 2: The user's suggestion is rejected.                
                })
                .ReverseMap();
        }
    }
}
