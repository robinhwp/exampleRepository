using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HelloWorldService;

namespace HelloWorldHost
{
    class HostApp
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(HelloWorldWCFService),
                new Uri("http://localhost/wcf/example/HelloWorldService"),
                new Uri("net.tcp://localhost/wcf/example/helloworldservice"));

            host.AddServiceEndpoint(typeof(IHelloWorld), new BasicHttpBinding(), "");

            host.AddServiceEndpoint(typeof(IHelloWorld), new NetTcpBinding(), "");

            host.Open();
            Console.WriteLine("Press key to stop the service.");
            Console.ReadKey(true);
            host.Close();

        }
    }
}
