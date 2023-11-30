using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersInformation
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public long UsersId { get; set; }
        public virtual Users Users { get; set; }

        /* Account*/
        public string? Firstname{ get; set; }/*=========*/
        public string? MiddleName{ get; set; }/*=========*/
        public string? Surname{ get; set; }/*=========*/
        public byte Gender { get; set; } = 0; // Check: [GenderConstants.cs]/*=========*/
        public int CountryId { get; set; } = 0; // derived from [Countries] entity/*=========*/
        public int LanguageId { get; set; }/*=========*/
        public string? BirthDay { get; set; } // 1989/02/09/*=========*/
        public string? BirthCity { get; set; }/*=========*/
        public string? CurrentCity { get; set; }/*=========*/

        /* Other */
        public string? Position { get; set; } // Director, Producer, Actor, etc.        
        public byte TimeZoneId{ get; set; }
        public byte CurrencyId { get; set; }

        /*Photo*/
        public string? Photo{ get; set; } // avatar
        public string? Header { get; set; } // header phone (landscape)

        /*About Me*/
        public string? Introduction { get; set; } //max length: 300
        public string? BIO{ get; set; } //max length: 7000
        public string? Note { get; set; } // it's Trivia

        /*Privacy*/
        [MinLength(3, ErrorMessage = "The characters of Username must be more than 3 characters.")]
        [MaxLength(30, ErrorMessage = "The characters of Username must not be more than 30 characters.")]
        public string? Username { get; set; } // www.galaxypremiere.com/Username
        public byte AccountType { get; set; } // check [AccountTypeConstants.cs]
        public byte Privacy { get; set; } = 0; // check [PrivacyConstants.cs]
    }
}
