using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client.ServiceReference;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChannelFactory<ICalculateContract> factory = new ChannelFactory<ICalculateContract>(new WSHttpBinding(), new EndpointAddress("http://localhost:8080/Calculator/ep1"));
            //ICalculateContract chanel = factory.CreateChannel();
            //Console.WriteLine("23+28="+chanel.Plus(23,28)+"\n23^2="+chanel.Sqr(23));
            CalculateContractClient proxy = new CalculateContractClient();
            DopContractClient proxy1 = new DopContractClient();
            Console.WriteLine("23+28=" + proxy.Plus(23, 28) + "\n23^2=" + proxy.Sqr(23)+"\nsin(2)+cos(3)="+proxy1.SinXCosY(2,3)+"\n10x3="+proxy1.TexX(3));
            Console.ReadKey();
        }
    }
}
