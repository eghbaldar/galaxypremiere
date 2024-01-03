using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersFavoriteMovies : BaseEntityGuid
    {
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public string ImdbLink { get; set; }
    }
}
