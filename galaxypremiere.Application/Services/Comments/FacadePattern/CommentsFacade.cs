using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Comments.Commands.DeleteComment;
using galaxypremiere.Application.Services.Comments.Commands.PostComment;
using galaxypremiere.Application.Services.Comments.Queries.GetCommentsBySectionId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Comments.FacadePattern
{
    public class CommentsFacade: ICommentsFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public CommentsFacade(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        ///////////////// Post Comment
        private PostCommentService _postCommentService;
        public PostCommentService PostCommentService
        {
            get { return _postCommentService = _postCommentService ?? new PostCommentService(_context, _mapper);  }
        }   
        ///////////////// Delete Comment
        private DeleteCommentService _deleteCommentService;
        public DeleteCommentService DeleteCommentService
        {
            get { return _deleteCommentService = _deleteCommentService ?? new DeleteCommentService(_context);  }
        }       
        ///////////////// Get Comments List
        private GetCommentsBySectionIdService _getCommentsBySectionIdService;
        public GetCommentsBySectionIdService GetCommentsBySectionIdService
        {
            get { return _getCommentsBySectionIdService = _getCommentsBySectionIdService ?? new GetCommentsBySectionIdService(_context);  }
        }
    }
}
