using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Logic
{
    public class HistoryItem
    {
        public int id { get; set; }
        public string URL { get; set; } 
        public string title { get; set; }
        public DateTime date { get; set; }
    }
}
