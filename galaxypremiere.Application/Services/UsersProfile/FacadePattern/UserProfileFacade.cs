using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Application.Interfaces.FacadePattern;
using galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileEducation;
using galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileEducations;
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
        // Post User Profile Education
        private PostUserProfileEducationService _postUserProfileEducationService;
        public PostUserProfileEducationService PostUserProfileEducationService
        {
            get { return _postUserProfileEducationService = _postUserProfileEducationService ?? new PostUserProfileEducationService(_context, _mapper); }
        }
        // Get User Profile Educations
        private GetUserProfileEducationsService _getUserProfileEducationsService;
        public GetUserProfileEducationsService GetUserProfileEducationsService
        {
            get { return _getUserProfileEducationsService = _getUserProfileEducationsService ?? new GetUserProfileEducationsService(_context, _mapper); }
        }
    }
}
