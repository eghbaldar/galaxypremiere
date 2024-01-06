using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersCompanies:BaseEntityAddress
    {
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public string Name { get; set; } // Company Name
        public string Position { get; set; } // Such as 'CEO','Digital Artist',...
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
