using galaxypremiere.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Comments.Commands.DeleteComment
{
    public interface IDeleteCommentService
    {
        ResultDto Execute(RequestDeleteCommentServiceDto req);
    }
}
