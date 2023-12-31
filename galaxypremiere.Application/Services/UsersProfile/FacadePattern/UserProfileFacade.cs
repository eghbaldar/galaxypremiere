using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UsersProfile.FacadePattern
{
    public class UserProfileFacade:IUserProfileFacade
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public UserProfileFacade(IDataBaseContext context, IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
        }
        // Post User Profile Education Service
        private PostUserProfileEducationService _postUserProfileEducationService;
        public PostUserProfileEducationService PostUserProfileEducationService
        {
            get { return _postUserProfileEducationService = _postUserProfileEducationService ?? new PostUserProfileEducationService(_context, _mapper); }
        }
    }
}
