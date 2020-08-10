using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models
{
    public class Register
    {
        public string UserID { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        [NotMapped]
        [Compare("Password")]
        public string RePassword { get; set; }
        public string PasswordHash { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Role { get; set; }
    }
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class Roles
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
