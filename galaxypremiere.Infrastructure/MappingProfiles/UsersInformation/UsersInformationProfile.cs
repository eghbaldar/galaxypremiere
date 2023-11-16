﻿using AutoMapper;
using galaxypremiere.Application.Services.UsersInformation.Commands.UpdateUsersInformationGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Infrastructure.MappingProfiles.UsersInformation
{
    public class UsersInformationProfile: Profile
    {
        public UsersInformationProfile()
        {
            CreateMap<Domain.Entities.Users.UsersInformation, RequestUpdateUsersInformationGeneralDto>().ReverseMap();
        }
    }
}
