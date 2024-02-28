using AutoMapper;
using galaxypremiere.Application.Services.Likes.Commands.PostLike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.Likes
{
    public class LikesMappingProfile:Profile
    {
        public LikesMappingProfile()
        {
            CreateMap<galaxypremiere.Domain.Common.Likes, RequestPostLikeServiceDto>().ReverseMap();
        }
    }
}
