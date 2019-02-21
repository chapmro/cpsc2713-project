using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

namespace WebBrowser.UI
{
    public partial class webBrowserTabControl : UserControl
    {
        public webBrowserTabControl()
        {
            InitializeComponent();
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
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
            // add to history 
            var item = new HistoryItem();
            item.URL = currentUrl;
            item.title = webBrowser1.DocumentTitle; // do better
            item.date = DateTime.Now;
            HistoryManager.AddItem(item);
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
                // add to history with Navigated event handler

            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Document.Body.MouseOver += new HtmlElementEventHandler(webBrowser1_MouseOver);

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            // homepage
            if (currentUrl.Length != 0)
            {
                backUrls.Push(currentUrl);
            }
            currentUrl = homepage;
            webBrowser1.Navigate(currentUrl);
            // will be added to history with Navigated event handler
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            // add a bookmark
            BookmarkItem item = new BookmarkItem();
            item.URL = currentUrl;
            item.title = webBrowser1.DocumentTitle; // better thing for the title? 
            BookmarkManager.AddItem(item);
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            // whenever  web page is loaded, add it to the history here
            var item = new HistoryItem();
            item.URL = currentUrl;
            item.title = webBrowser1.DocumentTitle;
            item.date = DateTime.Now;
            HistoryManager.AddItem(item);
            //webBrowser1.Document.Body.MouseOver += new HtmlElementEventHandler(webBrowser1_MouseOver);
        }






        private void webBrowser1_MouseOver(object sender, HtmlElementEventArgs e)
        {
            string element = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition).GetAttribute("href");

            toolStripStatusLabel2.Text = element;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value += 1;
        }
    }
       
}
