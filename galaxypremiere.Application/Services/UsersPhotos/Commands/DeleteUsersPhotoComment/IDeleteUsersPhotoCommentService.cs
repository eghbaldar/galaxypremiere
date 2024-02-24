using AutoMapper;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPhotos.Commands.DeleteUsersPhotoComment
{
    public interface IDeleteUsersPhotoCommentService
    {
        ResultDto Execute(RequestDeleteUsersPhotoCommentServiceDto req);
    }
}
