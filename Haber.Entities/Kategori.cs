using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Entities
{
    public class Kategori
    {
        [Key]
        [Required]
        public int KategoriID { get; set; }

        [Required]
        public string KategoriName { get; set; }
        public List<Haber> Haberler { get; set; }
    }
}
