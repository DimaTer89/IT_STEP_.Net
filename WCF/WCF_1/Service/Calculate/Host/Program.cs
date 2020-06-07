using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Calculate;
using System.ServiceModel.Description;

namespace Host
{
    class Program
    {
        //const string Uri = "http://localhost:8080/";
        static void Main(string[] args)
        {
            Type serviceType = typeof(Calculator);
            //ServiceHost host = new ServiceHost(typeof(Calculator), new Uri(Uri))
            using (ServiceHost host = new ServiceHost(typeof(Calculator)))
            {
                try
                {
                    host.Open();
                    Console.Write("Служба ожидает запросов клиента...");
                    Console.ReadKey();
                    host.Close();
                }
                catch (TimeoutException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //using (ServiceHost host =
            //           new ServiceHost(serviceType))
            //{
            //    Console.WriteLine("Время выделенное на открытие : "+host.OpenTimeout.ToString());
            //    Console.WriteLine("Состояние:" + host.State);
            //    Console.WriteLine("Базовые адреса:");
            //    foreach (Uri uri in host.BaseAddresses)
            //        Console.WriteLine(uri.ToString());
            //    //Console.WriteLine(host.Description.Behaviors.Find<ServiceMetadataBehavior>());
            //    ServiceDescription svcDesc = host.Description;
            //    string configName = svcDesc.ConfigurationName;
            //    Console.WriteLine("Configuration name: {0}", configName);
            //    ServiceEndpointCollection sec = svcDesc.Endpoints;
            //    foreach (ServiceEndpoint se in sec)
            //    {
            //        Console.WriteLine("Endpoint:");
            //        Console.WriteLine("\tAddress: {0}", se.Address.ToString());
            //        Console.WriteLine("\tBinding: {0}", se.Binding.ToString());
            //        Console.WriteLine("\tContract: {0}", se.Contract.Name);
            //        KeyedByTypeCollection<IEndpointBehavior> behaviors = se.Behaviors;
            //        foreach (IEndpointBehavior behavior in behaviors)
            //        {
            //            Console.WriteLine("Behavior: {0}", behavior.ToString());
            //        }
            //    }
            //    host.Open();
            //    Console.WriteLine("Состояние:" + host.State);
            //    //Console.Write("Нажмите любую клавишу, чтобы закрыть хост");
            //    Console.ReadKey();
            //    host.Close();
            //    Console.WriteLine("Состояние:" + host.State);
            //    Console.ReadKey();
            //}
            //host.AddServiceEndpoint(typeof(ICalculateContract), new WSHttpBinding(), "Calculator/ep1");
            //host.AddServiceEndpoint(typeof(IDopContract), new WSHttpBinding(), "Calculator/ep2");
            ////Добавляем поведение mex-точки ServiceMetadataBehavior в коллекцию поведений основного приложения службы
            //host.Description.Behaviors.Add(new ServiceMetadataBehavior());
            ////Добавляем конечную точку обмена метаданными в ведущее приложение службы   
            //host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
            //                 MetadataExchangeBindings.CreateMexHttpBinding(),
            //                 "mex");


        }
    }
}
