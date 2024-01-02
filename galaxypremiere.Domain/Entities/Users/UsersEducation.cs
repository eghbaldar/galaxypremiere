using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersEducation: BaseEntityGuid
    {
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public string Name { get; set; } // School, College, Institution or University Name
        public string Field { get; set; } // Computer Engineering, Cinema,....
        public DateTime From { get; set; } // starting date of education
        public DateTime To { get; set; } // ending date of education
    }
}
