using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.Likes.Commands.PostLike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.Likes.FacadePattern
{
    public class LikesFacade: ILikesFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public LikesFacade(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private PostLikeService _postLikeService;
        public PostLikeService PostLikeService
        {
            get { return _postLikeService = _postLikeService ?? new PostLikeService(_context, _mapper); }
        }
    }
}
