using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.PostUsersPhotoComment
{
    public interface IPostUsersPhotoCommentService
    {
        ResultDto<PostUsersPhotoCommentServiceDto> Execute(RequestPostUsersPhotoCommentServiceDto req);
    }
}
