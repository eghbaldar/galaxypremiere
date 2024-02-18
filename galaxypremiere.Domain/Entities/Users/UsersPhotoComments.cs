using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersPhotoComments : BaseEntityComment
    {
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public long UsersPhotosId { get; set; }
        public virtual UsersPhotos UsersPhotos { get; set; }
    }
}
