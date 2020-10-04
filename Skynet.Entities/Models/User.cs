using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skynet.Entities.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public User()
        {
            UserFlights = new HashSet<UserFlights>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<UserFlights> UserFlights { get; set; }
    }
}
