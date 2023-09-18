﻿using galaxypremiere.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Users.PostUser.Commands
{
    public interface IPostUserService
    {
        ResultDto Execute(RequestPostUserServiceDto req);
    }
}
