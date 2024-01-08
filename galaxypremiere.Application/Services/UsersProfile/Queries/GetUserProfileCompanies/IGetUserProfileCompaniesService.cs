using AutoMapper;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileCompanies
{
    public interface IGetUserProfileCompaniesService
    {
        ResultDto<ResultGetUserProfileCompaniesServiceDto> Execute(RequestGetUserProfileCompaniesDto req);
    }
}
