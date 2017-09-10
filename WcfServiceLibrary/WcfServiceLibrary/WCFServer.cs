using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;

namespace WcfServiceLibrary
{
    [ServiceBehavior(ConcurrencyMode =  ConcurrencyMode.Reentrant)]
    public class WCFServer : ICommandService
    {
        public static ICommandServiceCallBack CallBack; 
        ActionLog alog = new ActionLog();
        private string _Ip;

        public WCFServer()
        {
            //Get Client IP 
            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint =
                    prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                _Ip = endpoint.Address;
            }
        }


        public void Command()
        {
            CallBack = OperationContext.Current.GetCallbackChannel<ICommandServiceCallBack>();

            //New thread to let go of client 
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Run();
            }).Start();
        }

        private void Run()
        {
            alog.MessageEvent += Alog_MessageEvent;
           
            Console.WriteLine("> Session Opende at {0} from ip:{1}", DateTime.Now,_Ip);

            //Run dir command in CMD and route output to callback message
            var processInfo = new ProcessStartInfo("cmd.exe", "/c dir" );
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;

            var process = Process.Start(processInfo);
            process.OutputDataReceived += (sender, e) => alog.AddMessage(e.Data);
            process.BeginOutputReadLine();
            process.ErrorDataReceived += (sender, args) => alog.AddMessage(args.Data);
            process.BeginErrorReadLine();
            process.WaitForExit();

            alog.AddMessage($"EXit code {process.ExitCode}");
            process.Close();

            //quit message for client to know to stop listening 
            alog.AddMessage("quit");
        }

        private void Alog_MessageEvent(object sender, EventArgs e)
        {
            var actionLog = (ActionLog)sender;
            CallBack.OnCallBack(actionLog.Message);
        }
    }
}
