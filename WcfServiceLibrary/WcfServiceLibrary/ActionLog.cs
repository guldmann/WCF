using System;
using System.ServiceModel.Security;

namespace WcfServiceLibrary
{
    public delegate void ActionLogEvent(object sender, EventArgs e);
    public class ActionLog
    {
        public string Message { get; set; }
        public event ActionLogEvent MessageEvent;

        public void AddMessage(string message)
        {
            Message = message;
            OnMessage(EventArgs.Empty); 
        }

        private void OnMessage(EventArgs e)
        {
            MessageEvent?.Invoke(this, e);
        }
    }
}