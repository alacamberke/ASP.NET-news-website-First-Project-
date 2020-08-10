using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Entities
{
    public class Haber
    {
        [Key]
        [Required]
        public int HaberID { get; set; }

        [Required]
        public string HaberTitle { get; set; }

        [Required]
        public string HaberContent { get; set; }

        [Required]
        public string HaberOwner { get; set; }

        [Required]
        public string HaberSource { get; set; }

        [Required]
        public int KategoriId { get; set; }
        public Kategori Kategorisi { get; set; }

        [Required]
        public int View { get; set; }
        public List<Comment> Comments { get; set; }

        public List<string> Users { get; set; }
        public Haber()
        {
            Users = new List<string>();
        }
    }
}
