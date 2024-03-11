using AutoMapper;
using galaxypremiere.Application.Services.Comments.Commands.PostComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.Comments
{
    public class CommentsMappingProfile:Profile
    {
        public CommentsMappingProfile()
        {
            CreateMap<galaxypremiere.Domain.Common.Comments, RequestPostCommentServiceDto>().ReverseMap();
        }
    }
}
