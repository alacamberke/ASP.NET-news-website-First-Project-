using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Models
{
    public class CommentModel
    {
        public int CommentID { get; set; }
        public string CommentOwner { get; set; }
        public string CommentContent { get; set; }
        public int HaberId { get; set; }
        public string CommentOwnerId { get; set; }
    }
}
