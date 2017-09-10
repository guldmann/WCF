using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClient.WCFServiceReference;

namespace WCFClient
{
    class CommandServiceCallBack :ICommandServiceCallback
    {
        public void OnCallBack()
        {
            Console.WriteLine("> Received callback at {0}", DateTime.Now);
        }

        public void OnCallBack(string text)
        {

            if (text == "quit")
            {
                Console.WriteLine("init shut down...Eny key to quit");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("{0} {1}", DateTime.Now, text);
        }
    }
}
