using galaxypremiere.Common.DTOs;
using galaxypremiere.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername
{
    public interface IGetUsersInformationPhotosByUsernameService
    {
        ResultGetUsersInformationPhotosByUsernameServiceDto Execute(RequestGetUsersInformationPhotosByUsernameServiceDto req);
    }
}
