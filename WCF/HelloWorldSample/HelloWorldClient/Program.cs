using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using HelloWorldService;

namespace HelloWorldClient
{
    class Program
    {
        static void Main(string[] args)
        {
            InvokeUsingHttp();
            InvokeUsingTcp();
        }

        static void InvokeUsingHttp()
        {
            Uri uri = new Uri("http://localhost/wcf/example/helloworldservice");

            ServiceEndpoint ep = new ServiceEndpoint(ContractDescription.GetContract(typeof(IHelloWorld)),
                new BasicHttpBinding(),
                new EndpointAddress(uri));

            ChannelFactory<IHelloWorld> factory =
                new ChannelFactory<IHelloWorld>(ep);

            IHelloWorld proxy = factory.CreateChannel();
            string result = proxy.SayHello();

            (proxy as IDisposable).Dispose();

            Console.WriteLine(result);
        }

        static void InvokeUsingTcp()
        {
            Uri uri = new Uri("net.tcp://localhost/wcf/example/helloworldservice");

            ServiceEndpoint ep = new ServiceEndpoint(ContractDescription.GetContract(typeof(IHelloWorld)),
                new NetTcpBinding(),
                new EndpointAddress(uri));

            ChannelFactory<IHelloWorld> factory =
                new ChannelFactory<IHelloWorld>(ep);

            IHelloWorld proxy = factory.CreateChannel();
            string result = proxy.SayHello();

            (proxy as IDisposable).Dispose();

            Console.WriteLine(result);

        }
    }
}
