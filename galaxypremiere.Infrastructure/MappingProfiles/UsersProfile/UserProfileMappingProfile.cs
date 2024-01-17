using AutoMapper;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileAttachments;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileAttachments;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileFavoriteMovies;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileLinks;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews;
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
            CreateMap<UsersNews, GetUserProfileNewsDto>().ReverseMap();
            CreateMap<UsersLinks, GetUserProfileLinksDto>().ReverseMap();
            CreateMap<UsersFavoriteMovies, GetUserProfileFavoriteMoviesServiceDto>().ReverseMap();
            CreateMap<UsersEducation, GetUserProfileEducationsServiceDto>().ReverseMap();
            CreateMap<UsersCompanies, GetUserProfileCompaniesDto>().ReverseMap();
            CreateMap<UsersAttachments, GetUserProfileAttachmentsServiceDto>().ReverseMap();
            CreateMap<UsersAttachments, RequestPostUserProfileAttachmentServiceDto>().ReverseMap();
        }
    }
}
