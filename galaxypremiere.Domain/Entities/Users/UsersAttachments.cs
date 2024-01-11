using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersAttachments:BaseEntityGuid
    {
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public string Title { get; set; } // Title
        public string Filename { get; set; } // Filename
        public int DownloadCounter { get; set; } // How many times the file has been downloaded?
    }
}
