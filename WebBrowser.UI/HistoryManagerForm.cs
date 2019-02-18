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
        public HistoryManagerForm()
        {
            InitializeComponent();
        }

        private void HistoryManagerForm_Load(object sender, EventArgs e)
        {
            var items = HistoryManager.GetAllItems();
            foreach (var item in items)
            {
                listBox1.Items.Add(item.date+": "+item.title+" "+item.URL);
                // do better here
            }
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
  
        }
    }
}
