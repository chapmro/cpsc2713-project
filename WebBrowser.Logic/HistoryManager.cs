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
   
        public static HistoryTableAdapter adapter = new HistoryTableAdapter();

        public static void AddItem(HistoryItem item)
        {
           // HisC:\Users\chapmro\Source\Repos\cpsc2713-project\WebBrowser.Logic\HistoryManager.cstoryTableAdapter adapter = new HistoryTableAdapter();
            adapter.Insert(item.URL, item.title, item.date); 
        }
        public static List<HistoryItem> GetAllItems()
        {
            //var adapter = new HistoryTableAdapter();
            var results = new List<HistoryItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                HistoryItem item = new HistoryItem();
                item.URL = row.URL;
                item.id = row.Id;
                item.title = row.Title;
                item.date = row.Date;

                results.Add(item);
            }

            return results;
        }
    }
}
