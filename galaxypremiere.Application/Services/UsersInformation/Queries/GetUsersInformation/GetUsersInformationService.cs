using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformation
{
    public class GetUsersInformationService : IGetUsersInformationService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _imapper;
        public GetUsersInformationService(
            IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _imapper = mapper;
        }
        public GetUsersInformationServiceDto Execute(long userId)
        {
            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            var userInfo = _context.UsersInformation.Where(ui => ui.UsersId == userId).FirstOrDefault();
            if (user != null && userInfo != null)
            {
                var userInfoSelected = _context.UsersInformation
                     .Where(ui => ui.UsersId == userId)
                     .Select(ui => _imapper.Map<GetUsersInformationServiceDto>(ui))
                     .First();
                return userInfoSelected;
            }
            return null;
        }
    }

}
