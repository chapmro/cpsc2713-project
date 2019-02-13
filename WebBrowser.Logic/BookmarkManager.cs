using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.BookmarksDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class BookmarkManager
    {
        public static void AddItem(BookmarkItem item)
        {
            BookmarksTableAdapter adapter = new BookmarksTableAdapter();
            adapter.Insert( item.URL, item.title); // why does this need an id parameter? 
        }
        public static List<HistoryItem> GetAllItems()
        {
            return null; 
        }
    }
}
