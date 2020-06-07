using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork6_1.Tariffs;
using HomeWork6_1.Clients;


namespace HomeWork6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool flag = true;
                int key;
                Tariff tariff1 = new Tariff();
                Tariff tariff2 = new Tariff();
                Tariff tariff3 = new Tariff();
                Tariff tariff4 = new LimitTariff();
                Tariff tariff5 = new LimitTariff();
                Tariff tariff6 = new LimitTariff();
                Tariff tariff7 = new PrivilegiosTariffOne();
                Tariff tariff8 = new PrivilegiosTariffOne();
                Tariff tariff9 = new PrivilegiosTariffOne();
                Tariff tariff10 = new PrivilegiosTariffTwo();
                Tariff tariff11 = new PrivilegiosTariffTwo();
                Tariff tariff12 = new PrivilegiosTariffTwo();
                Client[] cl =
                {
                    new ClientOrdinary("Гомельский ВСЗ",tariff1,3000),
                    new ClientLimit("Гомсельмаш",tariff4,12500),
                    new ClientOrdinary("Центролит",tariff3,6000),
                    new ClientLimit("InterVale",tariff6,5000),
                    new ClientPrivilegiosTariffOne("IBM",tariff7,15000),
                    new ClientPrivilegiosTariffOne("Sony",tariff8,17000),
                    new ClientPrivilegiosTariffTwo("MicroSoft",tariff10,14000),
                    new ClientOrdinary("ГорЭлектоТранспорт",tariff2,6000),
                    new ClientPrivilegiosTariffTwo("БМЗ",tariff11,20000),
                    new ClientPrivilegiosTariffOne("Каштан",tariff9,15000),
                    new ClientLimit("EPAM",tariff5,5000),
                    new ClientPrivilegiosTariffTwo("БелАЗ",tariff12,9200)
                };
                Console.Clear();
                Print("Потребители энергии ",cl);
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Отсортировать массив по количеству потреблённой клиентами энергии по убыванию.");
                    Console.WriteLine("2 - Отсортировать массив по величине оплаты клиентами по возрастанию.");
                    Console.WriteLine("3 - Упорядочить массив по типу клиентов");
                    Console.WriteLine("4 - Вычислить общую сумму SUM оплаты всех клиентов за потреблённую энергию.");
                    Console.WriteLine("5 - Вычислить общий размер льготы ");
                    Console.WriteLine("0 - Выход из приложения");
                    Console.Write("Ваш выбор : ");
                    key = Convert.ToInt32(Console.ReadLine());
                    switch (key)
                    {
                        case 1:
                            Array.Sort(cl);
                            Console.Clear();
                            Print("Упорядочен по количеству потреблённой энергии(по убыванию)",cl);
                            break;
                        case 2:
                            Array.Sort(cl, Compare);
                            Console.Clear();
                            Print("Упорядочен по величине оплаты (по возрастанию)",cl);
                            break;
                        case 3:
                            Array.Sort(cl, new ClientComparerByType());
                            Console.Clear();
                            Print("Упорядочен по типу клиентов",cl);
                            break;
                        case 4:
                            Console.WriteLine("Общая стоимость за энергию : "+$"{TotalCost(cl):f2}");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.WriteLine("Общий размер льгот : "+$"{(TotalSum(cl)-TotalCost(cl)):f2}");
                            Console.ReadKey();
                            break;
                        case 0:
                            flag = false;
                            Console.WriteLine("До свидания !!!");
                            break;
                        default:
                            Console.WriteLine("Ошибка, такой команды не существует !!!");
                            Console.ReadKey();
                            break;
                    }

                } while (flag);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        static int Compare(Client c1,Client c2)
        {
            return (c1.GetEnergyBill().CompareTo(c2.GetEnergyBill()));
        }
        static decimal TotalCost(params Client[] client)
        {
            decimal sum = 0;
            foreach (Client item in client)
            {
                sum += item.GetEnergyBill();
            }
            return sum;
        }
        static void ShowTablica()
        {
            Console.WriteLine("╔════════════════════╦══════════════════════╦════════════════════════════╦══════════════════════╗");
            Console.WriteLine("║        Адрес       ║        Тариф         ║  Потребленная энергия(кВТ) ║       К оплате       ║");
        }
        static void Print(string title,Client[] client)
        {
            Console.WriteLine(title);
            ShowTablica();
            foreach (Client item in client)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("╚════════════════════╩══════════════════════╩════════════════════════════╩══════════════════════╝");
            Console.WriteLine("Нажмите любую клавишу для продолжения ");
            Console.ReadKey();
        }
        static decimal TotalSum(params Client[] client)
        {
            decimal num = client[0].Tariff.EnergyPrice;
            decimal sum = 0;
            foreach (Client item in client)
            {
                sum += (num * item.EnergyCount);
            }
            return sum;
        }
    }
}
