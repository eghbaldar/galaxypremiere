using galaxypremiere.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersAddress:BaseEntityAddress
    {
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
    }
}
