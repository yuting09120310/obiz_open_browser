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
using Alex_Component;


namespace obiz_open_browser
{
    public partial class browser : Form
    {
        public string text;
        Msg_log msg_Log = new Msg_log();
        string AppName = "obiz_open_browser_browser";
        public ChromiumWebBrowser browsers;

        public browser(string Url)
        {
            InitializeComponent();
            init_browser(Url);
        }

        public void init_browser(string Url)
        {
            try
            {
                Cef.Initialize(new CefSettings());
            }
            catch(Exception ex)
            {
                msg_Log.save_log(AppName, ex);
            }
            finally
            {
                browsers = new ChromiumWebBrowser(Url);
                this.Controls.Add(browsers);
                browsers.Dock = DockStyle.Fill;
            }
        }

        private void browser_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                browsers.Dispose();
                browsers = null;
            }catch(Exception ex)
            {
                msg_Log.save_log(AppName, ex);
            }
        }
    }
}
