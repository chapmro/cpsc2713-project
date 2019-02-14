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
        public static BookmarksTableAdapter adapter = new BookmarksTableAdapter();

        public static void AddItem(BookmarkItem item)
        {
           // BookmarksTableAdapter adapter = new BookmarksTableAdapter();
            adapter.Insert( item.URL, item.title.Substring(0,50)); // why does this need an id parameter? 
        }

        public static List<BookmarkItem> GetAllItems()
        {
           // var adapter = new BookmarksTableAdapter();
            var results = new List<BookmarkItem>();
            var rows = adapter.GetData();

            foreach (var row in rows)
            {
                BookmarkItem item = new BookmarkItem();
                item.URL = row.URL;
                item.id = row.Id;
                item.title = row.Title;

                results.Add(item);
            }

            return results;
        }
    }
}
