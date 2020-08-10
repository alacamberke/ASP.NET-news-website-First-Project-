using Haber.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models
{
    public class HaberModel
    {
        public int HaberID { get; set; }
        public string HaberTitle { get; set; }
        public string HaberContent { get; set; }
        public string HaberOwner { get; set; }
        public string HaberSource { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategorisi { get; set; }
        public string KategoriName{ get; set; }
        public int View { get; set; }
        public List<string> Users { get; set; }
        public List<Comment> Comments { get; set; }
        public string HaberOwnerName { get; set; }
    }
}
