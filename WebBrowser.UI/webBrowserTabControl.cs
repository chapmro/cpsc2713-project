using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser.UI
{
    public partial class webBrowserTabControl : UserControl
    {
        public webBrowserTabControl()
        {
            InitializeComponent();
        }
        /*
        private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("coded by Richard Chapman, instructor CPSC2713");
        }

        */
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // back button
            if (backUrls.Count != 0)
            {
                string gotoUrl = backUrls.Pop();
                forwardUrls.Push(currentUrl);
                currentUrl = gotoUrl;
                webBrowser1.Navigate(currentUrl);
            }
        }

        private String homepage = "google.com";
        private String currentUrl = "";
        private Stack<String> backUrls = new Stack<String>();
        private Stack<String> forwardUrls = new Stack<String>();


        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // forward button
            if (forwardUrls.Count != 0)
            {
                string gotoUrl = forwardUrls.Pop();
                backUrls.Push(currentUrl);
                currentUrl = gotoUrl;
                webBrowser1.Navigate(currentUrl);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // refresh button
            if (currentUrl.Length != 0)
            {
                webBrowser1.Navigate(currentUrl);
            }


        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // go to web page
            backUrls.Push(currentUrl);
            currentUrl = toolStripTextBox1.Text;
            webBrowser1.Navigate(currentUrl);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                backUrls.Push(currentUrl);
                currentUrl = toolStripTextBox1.Text;
                webBrowser1.Navigate(currentUrl);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (currentUrl.Length != 0)
            {
                backUrls.Push(currentUrl);
            }
            currentUrl = homepage;
            webBrowser1.Navigate(currentUrl);
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
   
}
