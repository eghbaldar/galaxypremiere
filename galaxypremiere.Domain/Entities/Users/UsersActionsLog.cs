using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersActionsLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }
        public string Entity { get; set; }
        public string? PrimaryKeyValue { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Action { get; set; }
        public bool Successful { get; set; } // [false]= failed [true]=successful
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
