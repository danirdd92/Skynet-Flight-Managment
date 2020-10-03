using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skynet.Entities.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            UserFlights = new HashSet<UserFlights>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<UserFlights> UserFlights { get; set; }
    }
}
