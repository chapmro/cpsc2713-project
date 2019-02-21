using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class BookmarkManagerForm : Form
    {

        public List<BookmarkItem> searchItems = new List<BookmarkItem>();
        bool search = false;

        public BookmarkManagerForm()
        {
            InitializeComponent();
        }

        private void BookmarkManagerForm_Load(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetAllItems();
            foreach (var item in items)
            {
                listBox1.Items.Add(item.URL+" "+item.title);
                // do better here
            }
        }

        // search
        private void button1_Click(object sender, EventArgs e)
        {
            List<BookmarkItem> items = BookmarkManager.GetAllItems();
            search = true;
            listBox1.Items.Clear();
            foreach (var item1 in items)
            {

                if (item1.title.Contains(textBox1.Text) || item1.URL.Contains(textBox1.Text))
                {
                    listBox1.Items.Add(item1.title + " " + item1.URL);
                    // do better here
                    searchItems.Add(item1);
                }
            }
        }

        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;

            if (!search)
            {
                var item = BookmarkManager.GetAllItems()[index];
                BookmarkManager.Delete(item);
            }
            else
            {
                var item = searchItems[index];
                BookmarkManager.Delete(item);
            }

            var items = BookmarkManager.GetAllItems();
            listBox1.Items.Clear();
            foreach (var item1 in items)
            {
                listBox1.Items.Add(item1.title + " " + item1.URL);
                // do better here
            }
        }
    }
}
