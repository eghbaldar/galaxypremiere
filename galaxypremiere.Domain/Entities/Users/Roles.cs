using System.ComponentModel.DataAnnotations;

namespace galaxypremiere.Domain.Entities.Users
{
    public class Roles
    {
        [Key]
        public byte Id { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        [MinLength(3, ErrorMessage = "Name characters should be more than 3 characters.")]
        public string Name { get; set; }
        public ICollection<UsersInRoles> UsersInRoles { get; set; }
    }
}
