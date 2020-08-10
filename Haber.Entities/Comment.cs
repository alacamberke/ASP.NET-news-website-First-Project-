using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Entities
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentOwner { get; set; }
        public string CommentContent { get; set; }
        public int HaberId { get; set; }
        public string CommentOwnerID { get; set; }
    }
}
