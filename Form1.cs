using CefSharp;
using CefSharp.WinForms;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSettings = CefSharp.WinForms.CefSettings;
using ChromiumWebBrowser = CefSharp.WinForms.ChromiumWebBrowser;
using Alex_Component;

namespace obiz_open_browser
{
    public partial class Form1 : Form
    {
        Msg_log msg_Log = new Msg_log();
        string AppName = "obiz_open_browser_from1";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //如果有輸入url
                if (textBox1.Text.Length > 0)
                {
                    //建立新執行續
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));

                    t.Start();
                }
                else
                {
                    MessageBox.Show("請輸入網址");
                }
            }catch(Exception ex)
            {
                msg_Log.save_log(AppName, ex);
            }
        }


        public void ThreadProc()
        {
            try
            {
                Application.Run(new browser(textBox1.Text));
            }catch(Exception ex)
            {
                msg_Log.save_log(AppName,ex);
            }
        }

    }
}
