using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersLoginLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public string IP{ get; set; }
        public DateTime LoginDateTime{ get; set; } = DateTime.Now;
    }
}
