using galaxypremiere.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Common
{
    public class Comments
    {
        public Guid Id { get; set; }
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public Guid? Parent { get; set; } = null; // x=null=> main comment | x!=null => subComment
        public string Comment { get; set; }
        public byte Section { get; set; } // drived from "SectionsConstants.cs"
        public Guid SectionId { get; set; } // for example, when the section is related to USER-PHOTO, the ID of photo will be stored in it.
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? DeleteTime { get; set; } = null;
    }
}
