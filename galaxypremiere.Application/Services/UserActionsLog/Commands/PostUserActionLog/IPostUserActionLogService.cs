using galaxypremiere.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Application.Services.UserActionsLog.Commands.PostUserActionLog
{
    public class RequestPostUserActionLogServiceDto
    {
        public long UserId { get; set; }
        public string Entity { get; set; }
        public string? PrimaryKeyValue { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Action { get; set; } // [0]=Added [1]=Modified [2]=Deleted
        public bool Successful { get; set; } // [false]= failed [true]=successful
    }
    public interface IPostUserActionLogService
    {
        bool Execute(RequestPostUserActionLogServiceDto req);
    }
    public class PostUserActionLogService: IPostUserActionLogService
    {
        private readonly IDataBaseContext _context;
        public PostUserActionLogService(IDataBaseContext context)
        {
            _context = context;
        }
        public bool Execute(RequestPostUserActionLogServiceDto req)
        {
            return true;
        }
    }
}
