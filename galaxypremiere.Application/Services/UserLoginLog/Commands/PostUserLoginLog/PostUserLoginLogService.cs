using AutoMapper;
using galaxypremiere.Application.Interfaces.Contexts;
using galaxypremiere.Domain.Entities.Users;

namespace galaxypremiere.Application.Services.UserLoginLog.Commands.PostUserLoginLog
{
    public class PostUserLoginLogService: IPostUserLoginLogService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public PostUserLoginLogService(
            IDataBaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool Execute(RequestPostUserLoginLogServiceDto req)
        {
            var user = _context.Users.Where(u=>u.Id== req.UsersId).FirstOrDefault();
            if (user != null)
            {
                UsersLoginLog _usersLoginLog = new UsersLoginLog();
                _usersLoginLog = _mapper.Map<UsersLoginLog>(req);

                _context.UsersLoginLog.Add(_usersLoginLog);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
