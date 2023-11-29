using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;

namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationContact
{
    public class GetUsersInformationContactService : IGetUsersInformationContactService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _imapper;
        public GetUsersInformationContactService(
            IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _imapper = mapper;
        }
        public GetUsersInformationContactServiceDto Execute(long userId)
        {
            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            var userInfo = _context.UsersAddress.Where(ui => ui.UsersId == userId).FirstOrDefault();
            if (user != null && userInfo != null)
            {
                var userInfoSelected = _context.UsersAddress
                     .Where(ui => ui.UsersId == userId)
                     .Select(ui => _imapper.Map<GetUsersInformationContactServiceDto>(ui))
                     .First();
                return userInfoSelected;
            }
            return null;
        }
    }
}
