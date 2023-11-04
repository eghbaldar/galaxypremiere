using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersLoginLog
    {
        public long Id { get; set; }
        public virtual Users Users { get; set; }
        public long UsersId { get; set; }
        public string IP{ get; set; }
        public DateTime LoginDateTime{ get; set; } = DateTime.Now;
    }
}
