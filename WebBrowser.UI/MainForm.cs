using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("coded by Richard Chapman, instructor CPSC2713");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(toolStripTextBox1.Text);
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //webBrowser1.Navigate(toolStripTextBox1.Text);
            }
        }

        private void webBrowserTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("coded by Richard Chapman, instructor CPSC2713");
        }

        private void exitWebBrowserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("new tab");
            tabControl1.TabPages.Add(tp);
            webBrowserTabControl wbtc = new webBrowserTabControl();
            tp.Controls.Add(wbtc);
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void manageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var histMgrForm = new HistoryManagerForm();
            histMgrForm.ShowDialog();
        }

        private void manageBookMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bkmkMgrForm = new BookmarkManagerForm();
            bkmkMgrForm.ShowDialog();
        }
    }
}
