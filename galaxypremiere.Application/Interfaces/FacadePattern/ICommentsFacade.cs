using galaxypremiere.Application.Services.Comments.Commands.DeleteComment;
using galaxypremiere.Application.Services.Comments.Commands.PostComment;
using galaxypremiere.Application.Services.Comments.Queries.GetCommentsBySectionId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Interfaces.FacadePattern
{
    public interface ICommentsFacade
    {
        public PostCommentService PostCommentService { get; }
        public DeleteCommentService DeleteCommentService { get; }
        public GetCommentsBySectionIdService GetCommentsBySectionIdService { get; }
    }
}
