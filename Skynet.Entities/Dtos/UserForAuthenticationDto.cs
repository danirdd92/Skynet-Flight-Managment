using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Skynet.Entities.Dtos
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; set; }
    }
}
