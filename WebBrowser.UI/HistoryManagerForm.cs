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
    public partial class HistoryManagerForm : Form

    {

        public List<HistoryItem> searchItems = new List<HistoryItem>();

        bool search = false;
        public HistoryManagerForm()
        {
            InitializeComponent();
        }

        private void HistoryManagerForm_Load(object sender, EventArgs e)
        {
            var items = HistoryManager.GetAllItems();
            foreach (var item in items)
            {
                listBox1.Items.Add(item.date + ": " + item.title + " " + item.URL);
                // do better here
            }
            search = false;
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        // delete
        private void button2_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;

            if (!search) { 
                 var item = HistoryManager.GetAllItems()[index];
                 HistoryManager.Delete(item);
            } else { 
                var item = searchItems[index];
                HistoryManager.Delete(item);
            }

            var items = HistoryManager.GetAllItems();
            listBox1.Items.Clear();
            foreach (var item1 in items)
            {
                listBox1.Items.Add(item1.date + ": " + item1.title + " " + item1.URL);
                // do better here
            }
        }

        // search
        private void button1_Click(object sender, EventArgs e)
        {
           List<HistoryItem> items =  HistoryManager.GetAllItems();
            search = true;
            listBox1.Items.Clear();
            foreach (var item1 in items)
            {

                if (item1.title.Contains(textBox1.Text) || item1.URL.Contains(textBox1.Text)) {
                    listBox1.Items.Add(item1.date + ": " + item1.title + " " + item1.URL);
                    // do better here
                    searchItems.Add(item1);
                }
            }
        }


        // clear
        private void button3_Click(object sender, EventArgs e)
        {
            var items = HistoryManager.GetAllItems();
            foreach (var item in items)
            {
                HistoryManager.Delete(item);
            }
            listBox1.Items.Clear();
        }
    }
}
