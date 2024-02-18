using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersPhotoComments : BaseEntityGuid
    {
        public Guid? Parent { get; set; } = null; // x=null=> main comment | x!=null => subComment
        public string Comment { get; set; }
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public Guid UsersPhotosId { get; set; }
        public virtual UsersPhotos UsersPhotos { get; set; }
    }
}
