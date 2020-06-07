using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BankServiceProject;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(BankService));
            sh.Open();
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
            sh.Close();
        }
    }
}
