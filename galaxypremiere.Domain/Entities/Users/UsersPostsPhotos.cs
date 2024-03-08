using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersPostsPhotos : BaseEntityGuid
    {
        public Guid UsersPostsId { get; set; }
        public virtual UsersPosts UsersPosts { get; set; }
        public string Filename { get; set; }
    }
}
