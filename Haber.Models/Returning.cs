using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models
{
    public class Returning
    {
        public IdentityResult Result { get; set; }
        public bool TrueOrFalse { get; set; }
    }
}
