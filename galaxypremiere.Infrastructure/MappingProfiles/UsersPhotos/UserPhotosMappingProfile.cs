﻿using AutoMapper;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoComment;
using galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotosPhoto;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoAlbum;
using galaxypremiere.Application.Services.UsersPhotos.Queries.GetUsersPhotoPhotos;
using galaxypremiere.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.UsersPhotos
{
    public class UserPhotosMappingProfile : Profile {
        public UserPhotosMappingProfile()
        {
            CreateMap<UsersAlbums, GetUsersPhotoAlbumServiceDto>().ReverseMap();
            CreateMap<galaxypremiere.Domain.Entities.Users.UsersPhotos, RequestPostUsersPhotosPhotoServiceDto>().ReverseMap();
            CreateMap<galaxypremiere.Domain.Entities.Users.UsersPhotos, GetUsersPhotoPhotosServiceDto>().ReverseMap();
            CreateMap<UsersPhotoComments, RequestPostUsersPhotoCommentServiceDto>().ReverseMap();
        }
    }
}
