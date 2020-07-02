using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using DesktopBlazor.Shared;
using CefSharp;
using CefSharp.WinForms;

namespace DesktopBlazor.Windows
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        ConnectionBrokerHandler handler;
        public ChromiumWebBrowser browser;
        public Form1()
        {
            InitializeComponent();
            handler = new ConnectionBrokerHandler("https://localhost:5001/");
            InitBrowser();
            Start();
            handler.MessageRecived += MessageRecived;
            handler.OnOpenForm += OpenForm;
            handler.OnOpenMessageBox += OpenMessageBox;
            handler.OnOpenURL += OpenURL;
            Core.CurrentForm = this;
        }
        public void InitBrowser()
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser("https://localhost:5001/");
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }
        async void Start()
        {
            await handler.Start();
        }
        void MessageRecived(string s)
        {
            MessageBox.Show(s, "Message received");
        }
        void OpenForm(DesktopBlazor.Shared.Form form, bool dialog, bool hideCurrent)
        {
            var mapper = new Mapper(Core.Configuration);
            var Form = mapper.Map<System.Windows.Forms.Form>(form);
            if (dialog) Form.ShowDialog();
            else Form.Show();
            if (hideCurrent && !dialog) Core.CurrentForm.Hide();
            Core.CurrentForm = Form;
        }
        void OpenMessageBox(string message, string title, Shared.MessageBoxButtons buttons, Shared.MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, (System.Windows.Forms.MessageBoxButtons)buttons, (System.Windows.Forms.MessageBoxIcon)icon);
        }
        void OpenURL(string url,DesktopBlazor.Shared.Form form)
        {
            var mapper = new Mapper(Core.Configuration);
            //var Form = mapper.Map<System.Windows.Forms.Form>(form);
            //Form.Show();
            browser = new ChromiumWebBrowser(url);
        }
    }
}
