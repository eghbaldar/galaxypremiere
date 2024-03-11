using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersPostsPhotos.FacadePattern
{
    public class UsersPostsPhotosFacade: IUsersPostsPhotosFacade
    {
        private readonly IDataBaseContext _context;
        public readonly IMapper _mapper;
        public UsersPostsPhotosFacade(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
