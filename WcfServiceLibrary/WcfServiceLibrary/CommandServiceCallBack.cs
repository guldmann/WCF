using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary
{
    public class CommandServiceCallBack : ICommandServiceCallBack
    {
        public void OnCallBack(string message)
        {
            Console.WriteLine("> Received callback at {0}", DateTime.Now);
        }
    }
}
