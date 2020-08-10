using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models
{
    public class KategoriModel
    {
        public int KategoriId { get; set; }
        public string KategoriName { get; set; }
        public List<Haber.Entities.Haber> Haberler { get; set; }
    }
}
