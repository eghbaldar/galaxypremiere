using galaxypremiere.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class Users: BaseEntity
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [MinLength(10, ErrorMessage = "Name characters should be more than 10 characters.")]
        [MaxLength(50,ErrorMessage ="Name characters should not be more than 50 characters.")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Email Address is mandatory.")]
        [EmailAddress(ErrorMessage = "Email Address is invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory")]
        [MinLength(5, ErrorMessage = "Password characters should be more than 5 characters.")]
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public byte Provider { get; set; } = 0; // From where the user is registered? [ProviderConstants.cs]
        public ICollection<UsersInRoles> UsersInRoles { get; set; }
    }
}
