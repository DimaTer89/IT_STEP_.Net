using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Epam
{
    class Program
    {
        static void Main(string[] args)
        {
            Rate ordinaryRate = new OrdinaryRate();
            Rate withlimitRate = new WithLimitRate();
            Rate preferentialRate = new PreferentialRate();
            Rate forHeatingRate = new ForHeatingRate();
            Client ordinaryClient1 = new OrdinaryClient("Иванов Иван Иванович", 250, ordinaryRate);
            Client ordinaryClient2 = new OrdinaryClient("Петров Петр Петрович", 350, ordinaryRate);
            Client ordinaryClient3 = new OrdinaryClient("Сидоров Игорь Игоревич", 450, ordinaryRate);
            Client withLimitClient1 = new WithLimitClient("ЖКХ", 150, withlimitRate);
            Client withLimitClient2 = new WithLimitClient("ЖКУ", 450, withlimitRate);
            Client withLimitClient3 = new WithLimitClient("ЖКХ-9", 350, withlimitRate);
            Client prefenretialClient1 = new PreferentialClient("ЗАО Гомельский ВСЗ", 1000, preferentialRate);
            Client prefenretialClient2 = new PreferentialClient("ОАО Злин", 3000, preferentialRate);
            Client prefenretialClient3 = new PreferentialClient("ОАО Гомсельмаш ", 6000, preferentialRate);
            Client forHeatingClient1 = new ForHeatingClient("ЖЭК-1", 10000, forHeatingRate);
            Client forHeatingClient2 = new ForHeatingClient("ЖЭК-2", 12000, forHeatingRate);
            Client forHeatingClient3 = new ForHeatingClient("ЖЭК-3", 14000, forHeatingRate);
            Client[] mass = new Client[]
            {
                ordinaryClient3,
                withLimitClient1,
                withLimitClient3,
                prefenretialClient1,
                ordinaryClient1,
                ordinaryClient2,
                prefenretialClient2,
                forHeatingClient1,
                forHeatingClient2,
                prefenretialClient3,
                forHeatingClient3,
                withLimitClient2,
            };
            ClientCollection collection = new ClientCollection(mass);
            Console.WriteLine("Данные по умолчанию");
            collection.ShowData();
            Console.WriteLine("Сортировка по потреблённой энергии (по убыванию)");
            collection.SortByEnergeCount();
            Console.WriteLine("Сортировка по величине оплаты (по возрастанию)");
            collection.SortByValuePayment();
            Console.WriteLine("Сортировка по типу клиентов(обычные-с лимитом-льготные-для нужд отопления)");
            collection.SortByClientType();
            Console.WriteLine("Общий размер оплаты за энергию = " +$"{collection.TotalSumPaymentEnergy():f2}");
            Console.WriteLine("Общий размер льгот = "+$"{ collection.AmountOfBenefits():f2}");
            Console.ReadKey();
        }
    }
}
