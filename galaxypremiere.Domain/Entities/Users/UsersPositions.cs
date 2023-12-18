using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersPositions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Position { get; set; } // like: director, producer, actor,...
        public DateTime InsertTime { get; set; }
    }
}
