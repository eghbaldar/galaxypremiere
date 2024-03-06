using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    // SECTION ID:0 => SectionsConstants.cs
    public class UsersPhotos:BaseEntityGuid
    {
        public Guid UsersAlbumsId { get; set; }
        public virtual UsersAlbums UsersAlbums { get; set; }
        public string? Title { get; set; } // Title
        public string? Detail { get; set; } // Detail
        public string Filename { get; set; } // Filename
        public int DownloadCounter { get; set; } // How many times the file has been downloaded?
        public long VisitorCounter { get; set; } // How many times the file has been visted?
    }
}
