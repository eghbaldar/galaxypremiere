using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    // SECTION ID:1 => SectionsConstants.cs
    public class UsersPosts : BaseEntityGuid
    {
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public long From { get; set; } // who is posted the post? owner of the page or for example a festival?or a company?
        public string Post { get; set; }
        public bool Archive { get; set; } = false;
    }
}
