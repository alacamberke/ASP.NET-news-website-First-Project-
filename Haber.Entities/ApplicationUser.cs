using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Entities
{
    public class ApplicationUser:IdentityUser
    {
        [NotMapped]
        public string RePassword { get; set; }
        public string Role { get; set; }
    }
}
