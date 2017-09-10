using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFClient.WCFServiceReference;


namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * string URL = "URL TO Service"; 
            // using endpoint from code 
            var adress = new EndpointAddress(URL);
            var callBack = new CommandServiceCallBack();
            var callbackInstance = new InstanceContext(callBack);
            var client = new CommandServiceClient(callbackInstance, "WSDualHttpBinding_ICommandService", adress);
            client.Command();
            Console.WriteLine("Closing connection");

            Console.ReadLine();
            */



            // Using endpoint from app.config
            Console.WriteLine("Press enter to continue once service is hosted.");
	        Console.ReadLine();
	        var callback = new CommandServiceCallBack();
	        var instanceContext = new InstanceContext(callback);
            var client = new CommandServiceClient(instanceContext);
	        client.Command();
	        Console.WriteLine("Closing connection"); 

	        Console.ReadLine();
	        
        }
    }
}
