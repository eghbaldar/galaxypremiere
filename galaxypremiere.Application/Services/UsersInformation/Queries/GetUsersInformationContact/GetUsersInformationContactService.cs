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
        public GetUsersInformationContactServiceDto Execute(RequestGetUsersInformationContactServiceDto req)
        {
            if (req != null)
            {
                var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
                if (user != null)
                {
                    var userInfo = _context.UsersAddress.Where(ui => ui.UsersId == req.UsersId).FirstOrDefault();
                    if(userInfo!=null)
                    {
                        var userInfoSelected = _context.UsersAddress
                         .Where(ui => ui.UsersId == req.UsersId)
                         .Select(ui => _imapper.Map<GetUsersInformationContactServiceDto>(ui))
                         .First();
                        return userInfoSelected;
                    }else
                        return null;
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}
