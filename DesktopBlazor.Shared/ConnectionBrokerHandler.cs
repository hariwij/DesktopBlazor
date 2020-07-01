using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesktopBlazor.Shared
{
    public class ConnectionBrokerHandler : IAsyncDisposable
    {
        public const string BrokerUrl = "/ConnectionBroker";
        private HubConnection Connection;
        private readonly string AbsoluteUrl;

        private bool _started = false;

        public Action<string> MessageRecived;
        public Action<string, string, MessageBoxButtons, MessageBoxIcon> OnOpenMessageBox;
        public Action<Form, bool, bool> OnOpenForm;
        public Action<string, Form> OnOpenURL;
        public ConnectionBrokerHandler(string Url)
        {
            if (string.IsNullOrWhiteSpace(Url)) throw new ArgumentNullException(nameof(Url));
            AbsoluteUrl = Url.TrimEnd('/') + BrokerUrl;
        }
        public async Task Start()
        {
            if (!_started)
            {
                Connection = new HubConnectionBuilder().WithUrl(AbsoluteUrl).Build();
                Connection.On<string>(ActionType.SendMessage, (message) =>
                {
                    MessageRecived?.Invoke(message);
                });
                Connection.On<Form, bool, bool>(ActionType.OpenForm, (Form, showDialog, hideCurrent) =>
                  {
                      OnOpenForm?.Invoke(Form, showDialog, hideCurrent);
                  });
                Connection.On<string, string, MessageBoxButtons, MessageBoxIcon>(ActionType.OpenMessageBox, (message, title, buttons, icon) =>
                {
                    OnOpenMessageBox?.Invoke(message, title, buttons, icon);
                });
                Connection.On<string, Form>(ActionType.OpenURL, (url, Form) =>
                 {
                     OnOpenURL?.Invoke(url, Form);
                 });
                try
                {
                    await Connection.StartAsync();
                    Console.WriteLine("Broker : Started..");
                    _started = true;
                    // await Connection.SendAsync(Messages.SEND, _username, $"Join", "Join");
                }
                catch
                {
                    Console.WriteLine("Broker : Failed To Start...");
                }
            }
        }
        public async Task Stop()
        {
            if (_started)
            {
                await Connection.StopAsync();
                await Connection.DisposeAsync();
                Connection = null;
                _started = false;
            }
        }
        public async Task SendMessage(string message)
        {
            if (!_started)
                throw new InvalidOperationException("Broker : not started");
            try
            {
                await Connection.SendAsync(ActionType.SendMessage, message);
            }
            catch
            {

            }
        }
        public async Task OpenForm(Form form, bool showDialog = false, bool HideCurrntForm = false)
        {
            if (!_started)
                throw new InvalidOperationException("Broker : not started");
            try
            {
                await Connection.SendAsync(ActionType.OpenForm, form, showDialog, HideCurrntForm);
            }
            catch
            {

            }
        }
        public async Task OpenMessageBox(string message, string title = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            if (!_started)
                throw new InvalidOperationException("Broker : not started");
            try
            {
                await Connection.SendAsync(ActionType.OpenMessageBox, message, title, buttons, icon);
            }
            catch
            {

            }
        }
        public async Task OpenURL(string Url, Form form)
        {
            if (!_started)
                throw new InvalidOperationException("Broker : not started");
            try
            {
                await Connection.SendAsync(ActionType.OpenURL, Url, form);
            }
            catch
            {

            }
        }
        public async ValueTask DisposeAsync()
        {
            await Stop();
        }
    }
}
