using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public bool IsBefore { get; set; }
        public string LogCaption { get; set; }
        public string LogDetails { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
    }
}
