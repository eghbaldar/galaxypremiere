using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Domain.Entities.Users;

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
        public GetUsersInformationServiceDto Execute(RequestGetUsersInformationServiceDto req)
        {
            if (req != null)
            {
                var user = _context.Users.Where(u => u.Id == req.UsersId).FirstOrDefault();
                if (user != null)
                {
                    var userInfo = _context.UsersInformation.Where(ui => ui.UsersId == req.UsersId).ToList();
                    if (userInfo.Any())
                    {
                        var userInfoSelected = userInfo
                         .Where(ui => ui.UsersId == req.UsersId)
                         .Select(ui => _imapper.Map<GetUsersInformationServiceDto>(ui)).First();
                        return userInfoSelected;
                    }
                    else
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
