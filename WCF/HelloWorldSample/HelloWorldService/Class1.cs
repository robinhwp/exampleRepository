using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HelloWorldService
{
    [ServiceContract]
    public interface IHelloWorld
    {
        [OperationContract]
        string SayHello();
    }

    public class HelloWorldWCFService : IHelloWorld
    {
        public string SayHello()
        {
            return "Hello WCF World!";
        }
    }
}
