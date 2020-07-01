using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesktopBlazor.Shared;
using System.Data;

namespace DesktopBlazor.Blazor.Data
{
    public class ConnectionBroker : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync(ActionType.SendMessage, message);
        }
        public async Task OpenMessageBox(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            await Clients.All.SendAsync(ActionType.OpenMessageBox, message, title, buttons, icon);
        }
        public async Task OpenForm(Form form, bool showDialog, bool HideCurrentForm)
        {
            await Clients.All.SendAsync(ActionType.OpenForm, form, showDialog, HideCurrentForm);
        }
        public async Task OpenUrl(string url, Form OpenIn)
        {
            await Clients.All.SendAsync(ActionType.OpenURL, url, OpenIn);
        }
    }
}
