using galaxypremiere.Common.Constants;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Likes.Commands.PostLike
{
    public interface IPostLikeService
    {
        ResultDto Execute(RequestPostLikeServiceDto req);
    }
}
