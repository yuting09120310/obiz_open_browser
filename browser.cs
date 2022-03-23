using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSettings = CefSharp.WinForms.CefSettings;
using ChromiumWebBrowser = CefSharp.WinForms.ChromiumWebBrowser;
using System.IO;
using System.Diagnostics;

namespace obiz_open_browser
{
    public partial class browser : Form
    {
        public string text;

        public browser(string Url)
        {
            InitializeComponent();
            InitBrowser(Url);
        }

        public ChromiumWebBrowser browsers;

        public void get_process()
        {
            Form1 parentForm = (Form1)this.Owner;
            Process currentProcess = Process.GetCurrentProcess();
            parentForm.ShowDialog();
        }
        

        public void InitBrowser(string url)
        {
            try
            {
                Cef.Initialize(new CefSettings());
            }
            catch(Exception ex)
            {
                File.AppendAllText(@"C:\Users\alex\Desktop\Homework\error.txt", DateTime.Now.ToString() + "\r\n" + ex.Message + "\r\n");
            }
            finally
            {
                browsers = new ChromiumWebBrowser(url);
                this.Controls.Add(browsers);
                browsers.Dock = DockStyle.Fill;
            }
        }

        private void browser_FormClosed(object sender, FormClosedEventArgs e)
        {
            browsers.Dispose();
            browsers = null;
        }
    }
}
