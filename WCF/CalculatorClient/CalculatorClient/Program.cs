using CalculatorClient.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ICalculatorContract> factory = new ChannelFactory<ICalculatorContract>(new WSHttpBinding(),
                new EndpointAddress("http://192.168.10.100:8080/CalculatorService/ep1"));
            ICalculatorContract channel = factory.CreateChannel();

            Console.WriteLine("23+67=" + channel.Plus(23, 67));
            Console.WriteLine("23^2=" + channel.Sqr(23));

            CalculatorContractClient proxy = new CalculatorContractClient();
            Console.WriteLine("23+67=" + proxy.Plus(23, 67));
            Console.WriteLine("23^2=" + proxy.Sqr(23));
            Console.ReadKey();
        }
    }
}
