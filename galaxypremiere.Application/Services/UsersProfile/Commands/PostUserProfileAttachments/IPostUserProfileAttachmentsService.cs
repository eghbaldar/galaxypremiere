using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileNews;
using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileAttachments
{
    public interface IPostUserProfileAttachmentsService
    {
        ResultDto Execute(RequestPostUserProfileAttachmentServiceDto req);
    }
}
