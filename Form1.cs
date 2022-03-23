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

namespace obiz_open_browser
{
    public partial class Form1 : Form
    {
        browser f;
        string pid;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                //建立新執行續
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));

                t.Start();
            }
            else
            {
                MessageBox.Show("請輸入網址");
            }
        }


        public void ThreadProc()
        {
            Application.Run(new browser(textBox1.Text));
        }

    }
}
