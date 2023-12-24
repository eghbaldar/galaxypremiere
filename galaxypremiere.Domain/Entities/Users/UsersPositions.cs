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
        public byte Suggestion { get; set; } // 0: The user's suggestion is verifed | 1: The user's suggestion is under consideration | 2: The user's suggestion is rejected.
        public int UsersId { get; set; } // Who will suggest a new position title?
        public DateTime InsertTime { get; set; }
    }
}
