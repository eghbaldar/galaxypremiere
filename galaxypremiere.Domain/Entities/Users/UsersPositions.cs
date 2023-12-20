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
        public bool Suggestion { get; set; } // True: The user's suggestion is verifed | False: The user's suggestion is under consideration
        public int UsersId { get; set; } // Who will suggest a new position title?
        public DateTime InsertTime { get; set; }
    }
}
