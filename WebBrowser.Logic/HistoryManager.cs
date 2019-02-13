using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.HistoryDataSetTableAdapters;

namespace WebBrowser.Logic
{
   public class HistoryManager
    {
        public static void AddItem(HistoryItem item)
        {
            HistoryTableAdapter adapter = new HistoryTableAdapter();
            //adapter.Insert(item.URL, item.title, item.date); // why does this need an id parameter? 
        }
        public static List<HistoryItem> GetAllItems()
        {
            return null;
        }
    }
}
