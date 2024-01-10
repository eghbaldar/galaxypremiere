using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersNews:BaseEntityGuid
    {
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public string Title { get; set; } // The Title of news
        public string Reference { get; set; } // The Reference of news
        public string Link { get; set; } // The Link of news
        public DateTime PublishedDate{ get; set; } // When did this news publish?
    }
}
