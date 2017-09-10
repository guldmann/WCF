using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace WcfServiceLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(WCFServer));
            host.Open();

            Console.WriteLine("Server started at {0}", DateTime.Now);
            Console.WriteLine("press key to stop service.");
            Console.ReadLine();
            host.Close();
        }
    }
}
